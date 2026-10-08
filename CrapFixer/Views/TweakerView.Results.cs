using CrapFixer.Models;
using CrapFixer.Services;
using System.Diagnostics;

namespace CrapFixer.Views;

//summary, result rows and the small detail page
public partial class TweakerView
{
    private void Results_DoubleClick(object? sender, EventArgs e)
    {
        if (lvResults.SelectedItems.Count > 0) ShowDetails(lvResults.SelectedItems[0].Tag);
    }

    //sort results, same header again reverses it
    private void Results_ColumnClick(object? sender, ColumnClickEventArgs e)
    {
        _resultSorter.ToggleSort(e.Column);
        lvResults.Sort();
    }

    //hidden at startup just like CleanerView, shown after an action starts
    private void ShowResultList()
    {
        pnlDetail.Visible = false;
        pnlSummary.Visible = true;
        pnlSummary.BringToFront();
    }

    private void ShowReadyText()
    {
        if (!_loaded) return;
        txtSummary.ForeColor = Color.DimGray;
        txtSummary.Text = ActiveTree == treeCustom && _customTweaks.Count == 0
            ? Loc.Get("Tweaker_CustomEmpty")
            : Loc.Format("Tweaker_Ready", ActiveTweaks.Count);
    }

    //same compact summary block used by Cleaner Classic
    private void ShowAnalysisSummary(int total, int applied)
    {
        var problems = total - applied;
        var summaryKey = problems == 0 ? "Tweaker_AnalysisSummaryNone"
            : problems == 1 ? "Tweaker_AnalysisSummaryOne" : "Tweaker_AnalysisSummaryMany";
        var separator = ResultSeparator();

        txtSummary.ForeColor = Color.Black;
        txtSummary.Text = Loc.Get("Tweaker_AnalysisComplete") + "\r\n" +
            separator + "\r\n" +
            Loc.Format(summaryKey, applied, total, problems) + "\r\n" +
            separator + "\r\n\r\n" +
            Loc.Get("Tweaker_AnalysisDetails") + "\r\n" + separator;
    }

    //sizes the line roughly to the result columns
    private string ResultSeparator()
    {
        var width = lvResults.Columns.Cast<ColumnHeader>().Sum(column => column.Width);
        var sample = TextRenderer.MeasureText(new string('-', 100), txtSummary.Font,
            Size.Empty, TextFormatFlags.NoPadding).Width;
        return new string('-', Math.Max(1, width * 100 / Math.Max(1, sample)));
    }

    //blocks controls while registry work is running
    private void SetBusy(bool busy, string? text = null)
    {
        _busy = busy;
        progressBar.Visible = busy;
        btnAnalyze.Enabled = !busy;
        btnRun.Enabled = !busy && _loaded && (_lastIssues == null || _lastIssues.Count > 0);
        cboResultActions.Enabled = !busy && lvResults.Items.Count > 0;
        //result tools only make sense once some rows are ready
        pnlResultActions.Visible = !busy && lvResults.Items.Count > 0;
        tabCategories.Enabled = !busy;
        if (text != null)
        {
            if (busy) txtSummary.ForeColor = Color.DimGray;
            txtSummary.Text = text;
        }
    }

    //after a scan Run only touches what still needs attention
    private void SetIssueMode(List<TweakItem> issues)
    {
        _lastIssues = issues;
        if (issues.Count == 0) btnRun.Text = Loc.Get("Tweaker_NothingToFix");
        else if (issues.Count == 1) btnRun.Text = Loc.Get("Tweaker_FixOneIssue");
        else btnRun.Text = Loc.Format("Tweaker_FixIssues", issues.Count);
        btnRun.Enabled = !_busy && issues.Count > 0;
    }

    private void ResetIssueMode()
    {
        _lastIssues = null;
        btnRun.Text = Loc.Get("Tweaker_Run");
        btnRun.Enabled = !_busy && _loaded;
    }

    //adds one row to the result list
    private void AddResult(TweakItem tweak, string status, string value, Color color)
    {
        var row = new ListViewItem(new[] { Loc.TweakName(tweak.Name), status, value })
        {
            Tag = tweak,
            ForeColor = color
        };
        lvResults.Items.Add(row);
    }

    //clears old rows and restores the red-first sorting
    private void ClearResults()
    {
        ResetIssueMode();
        lvResults.Items.Clear();
        cboResultActions.SelectedIndex = 0;
        cboResultActions.Enabled = false;
        pnlResultActions.Visible = false;
        _resultSorter.SortColumn = 1; //red entries first for a fresh scan
        _resultSorter.Order = SortOrder.Ascending;
    }

    //copies current results or opens them in the web analyzer
    private void ResultActions_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (cboResultActions.SelectedIndex <= 0) return;
        var openAnalyzer = cboResultActions.SelectedIndex == 1;
        cboResultActions.SelectedIndex = 0;

        if (lvResults.Items.Count == 0)
        {
            MessageBox.Show(Loc.Get("Tweaker_AnalyzeFirst"), Loc.Get("Tweaker_ResultActions"));
            return;
        }

        try
        {
            Clipboard.SetText(AnalyzerReportBuilder.Build(lvResults.Items.Cast<ListViewItem>()));
            if (!openAnalyzer)
            {
                txtSummary.Text = Loc.Get("Tweaker_ResultsCopiedSummary");
                return;
            }

            Process.Start(new ProcessStartInfo(
                "https://builtbybel.github.io/CrapFixer/log-analyzer/index.html") { UseShellExecute = true });
            MessageBox.Show(
                Loc.Get("Tweaker_ResultsCopiedText"),
                Loc.Get("Tweaker_ResultsCopiedTitle"), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show(Loc.Format("Tweaker_ResultActionFailed", ex.Message),
                Loc.Get("Tweaker_ResultActions"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void BtnBack_Click(object? sender, EventArgs e) => ShowSummary();

    private void ShowSummary()
    {
        pnlDetail.Visible = false;
        pnlSummary.Visible = true;
        pnlSummary.BringToFront();
    }

    //same drill-down used by CleanerView, no dialog in front of the app
    private void ShowDetails(object? item)
    {
        lvDetail.BeginUpdate();
        lvDetail.Items.Clear();

        if (item is TweakItem tweak)
        {
            lblDetailTitle.Text = Loc.TweakName(tweak.Name);
            AddDetailRow(Loc.Get("Tweaker_Description"), Loc.TweakDescription(tweak.Name, tweak.Description));
            var entryNumber = 0;
            foreach (var entry in tweak.AllEntries())
            {
                entryNumber++;
                var path = entry.Hive + "\\" + entry.Key + "\\" + entry.ValueName;
                AddDetailRow(Loc.Format("Tweaker_Registry", entryNumber), path);
                AddDetailRow(Loc.Get("Tweaker_ValueType"), entry.ValueType);
                AddDetailRow(Loc.Get("Tweaker_Current"),
                    _registry.ReadValue(entry.Hive, entry.Key, entry.ValueName) ?? Loc.Get("Common_NotSet"));
                AddDetailRow(Loc.Get("Tweaker_Recommended"), entry.RecommendedValue);
                AddDetailRow(Loc.Get("Tweaker_Default"),
                    entry.DefaultValue.Length > 0 ? entry.DefaultValue : Loc.Get("Common_NotDefined"));
            }
            if (tweak.RequiresAdmin) AddDetailRow(Loc.Get("Tweaker_Info"), Loc.Get("Tweaker_RequiresAdmin"));
            if (tweak.RestartExplorer) AddDetailRow(Loc.Get("Tweaker_Info"), Loc.Get("Tweaker_ExplorerRestartRequired"));
            if (tweak.RestartRequired) AddDetailRow(Loc.Get("Tweaker_Info"), Loc.Get("Tweaker_WindowsRestartRequired"));
        }
        else
        {
            lvDetail.EndUpdate();
            return;
        }

        lvDetail.EndUpdate();
        pnlSummary.Visible = false;
        pnlDetail.Visible = true;
        pnlDetail.BringToFront();
    }

    private void AddDetailRow(string type, string details)
    {
        var row = new ListViewItem(type);
        row.SubItems.Add(details);
        lvDetail.Items.Add(row);
    }
}
