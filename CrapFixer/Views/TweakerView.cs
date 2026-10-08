using CrapFixer.Models;
using CrapFixer.Services;

namespace CrapFixer.Views;

/*
 * One Tweaker view, just split by job
 * Tree = nodes and checks
 * Actions = scan/apply/restore
 * Results = summary and details
 * Designer.cs owns the UI. the other parts are normal code files
 */
public partial class TweakerView : UserControl
{
    private readonly Wintweak2Parser _tweakParser = new Wintweak2Parser(); //reads our tweak ini files
    private readonly TweakerService _tweaker = new TweakerService();       //scan, apply and restore work
    private readonly RegistryService _registry = new RegistryService();   //used by the detail view
    private readonly SemaphoreSlim _loadGate = new SemaphoreSlim(1, 1);   //only one database load at a time
    private List<TweakItem> _windowsTweaks = new List<TweakItem>();        //built-in and extra database
    private List<TweakItem> _customTweaks = new List<TweakItem>();         //enabled tweaks made under Tools
    private List<TweakItem>? _lastIssues;                                  //null until a scan gives Run a smaller scope
    private bool _changingChecks;                                          //stops checkbox event loops
    private bool _busy;                                                    //blocks another action for now
    private bool _loaded;                                                  //trees have their data
    private TreeNode? _menuNode;                                           //last node opened by right click
    private readonly ListViewColumnSorter _resultSorter = new ListViewColumnSorter(); //red rows first or column sort

    //right-click scope, one entry or checked entries below a category
    private readonly List<TreeNode> _contextNodes = new List<TreeNode>();
    private readonly List<TweakItem> _contextTweaks = new List<TweakItem>();

    //the open tab is the complete scope for the two bottom buttons
    private TreeView ActiveTree => tabCategories.SelectedTab == tabCustom ? treeCustom : treeWindows;
    private List<TweakItem> ActiveTweaks => ActiveTree == treeCustom ? _customTweaks : _windowsTweaks;

    //sets up the default red-first result sorting
    public TweakerView()
    {
        InitializeComponent();
        ApplyLocalization();
        cboResultActions.SelectedIndex = 0;
        _resultSorter.KeySelector = (item, column) => column == 1
            ? (item.ForeColor == Color.Firebrick ? 0 : 1)
            : item.SubItems[column].Text;
        _resultSorter.SortColumn = 1;
        lvResults.ListViewItemSorter = _resultSorter;
    }

    private void ApplyLocalization()
    {
        tabWindows.Text = Loc.Get("Tweaker_Windows");
        tabCustom.Text = Loc.Get("Tweaker_Custom");
        miCheckAll.Text = Loc.Get("Tweaker_CheckAll");
        miUncheckAll.Text = Loc.Get("Tweaker_UncheckAll");
        miAnalyze.Text = Loc.Get("Tweaker_Analyze");
        miApply.Text = Loc.Get("Tweaker_Apply");
        miDetails.Text = Loc.Get("Tweaker_ShowDetails");
        miExplain.Text = Loc.Get("Tweaker_ExplainAi");
        miRestore.Text = Loc.Get("Tweaker_RestoreDefault");
        colDetailType.Text = Loc.Get("Tweaker_DetailType");
        colDetailValue.Text = Loc.Get("Tweaker_DetailDetails");
        btnBack.Text = Loc.Get("Tweaker_Back");
        colEntry.Text = Loc.Get("Tweaker_Entry");
        colStatus.Text = Loc.Get("Tweaker_Status");
        colCurrent.Text = Loc.Get("Tweaker_Current");
        txtSummary.Text = Loc.Get("Tweaker_LoadingDatabases");
        cboResultActions.Items.Clear();
        cboResultActions.Items.AddRange(new object[] { Loc.Get("Tweaker_ResultActions"),
            Loc.Get("Tweaker_AnalyzeOnline"), Loc.Get("Tweaker_CopyResults") });
        btnAnalyze.Text = Loc.Get("Tweaker_Analyze");
        btnRun.Text = Loc.Get("Tweaker_Run");
    }

    //loads normal databases and Tools tweaks into their own lists
    public async Task LoadDatabasesAsync()
    {
        if (_loaded) return;
        await _loadGate.WaitAsync();
        if (_loaded)
        {
            _loadGate.Release();
            return;
        }
        SetBusy(true, Loc.Get("Tweaker_LoadingDatabases"));
        try
        {
            var windowsLoaded = new List<TweakItem>();
            if (AppSettings.Instance.EnableBuiltInDatabase)
                MergeTweaks(windowsLoaded, await _tweakParser.ParseFileAsync(DatabaseUpdateService.Wintweak2LocalPath));

            var customDb = AppSettings.Instance.CustomDbPath;
            if (!string.IsNullOrWhiteSpace(customDb) && File.Exists(customDb))
                MergeTweaks(windowsLoaded, await _tweakParser.ParseFileAsync(customDb!));

            //files made under Tools stay separate from the normal databases
            var customLoaded = new List<TweakItem>();
            foreach (var path in CustomTweakService.EnabledFiles())
                MergeTweaks(customLoaded, await _tweakParser.ParseFileAsync(path));

            _windowsTweaks = FilterForCurrentWindows(windowsLoaded);
            _customTweaks = FilterForCurrentWindows(customLoaded);
            PopulateTrees();
            _loaded = true;
            ShowReadyText();
        }
        catch (Exception ex)
        {
            txtSummary.Text = Loc.Format("Tweaker_DatabaseLoadFailed", ex.Message);
        }
        finally
        {
            SetBusy(false);
            _loadGate.Release();
        }
    }

    public async Task ReloadDatabasesAsync()
    {
        _loaded = false;
        await LoadDatabasesAsync();
    }

    //later sources win when a section uses the same name
    private static void MergeTweaks(List<TweakItem> target, IEnumerable<TweakItem> incoming)
    {
        foreach (var tweak in incoming)
        {
            target.RemoveAll(item => item.Name.Equals(tweak.Name, StringComparison.OrdinalIgnoreCase));
            target.Add(tweak);
        }
    }

    //OSVersion works the same for database and own tweaks
    private static List<TweakItem> FilterForCurrentWindows(IEnumerable<TweakItem> source)
    {
        var windows11 = Environment.OSVersion.Version.Build >= 22000;
        return source.Where(tweak =>
            string.IsNullOrWhiteSpace(tweak.OsVersion) ||
            (windows11 && tweak.OsVersion == "11") || (!windows11 && tweak.OsVersion == "10")).ToList();
    }
}
