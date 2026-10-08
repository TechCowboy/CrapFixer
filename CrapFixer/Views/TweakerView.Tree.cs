using CrapFixer.Models;
using CrapFixer.Services;

namespace CrapFixer.Views;

//everything around the two left trees stays here
public partial class TweakerView
{
    private void Tree_NodeMouseDoubleClick(object? sender, TreeNodeMouseClickEventArgs e) => ShowDetails(e.Node.Tag);

    private void MiCheckAll_Click(object? sender, EventArgs e) => SetContextNodesChecked(true);
    private void MiUncheckAll_Click(object? sender, EventArgs e) => SetContextNodesChecked(false);
    private void MiDetails_Click(object? sender, EventArgs e) => ShowDetails(_menuNode?.Tag);

    //prepares actions for the right-clicked entry/category only
    private void CmTree_Opening(object? sender, System.ComponentModel.CancelEventArgs e)
    {
        var resetTargets = GetContextResetTargets();
        miRestore.Visible = _menuNode != null;
        miRestore.Enabled = resetTargets.Any(HasDefaultValue);
        miDetails.Enabled = _menuNode?.Tag != null;
        miExplain.Enabled = _menuNode?.Tag is TweakItem;
        miAnalyze.Enabled = _contextTweaks.Count > 0;
        miApply.Enabled = miAnalyze.Enabled;
        miApply.Text = Loc.Get("Tweaker_Apply");
    }

    //both tabs use the same tree rules, only their source list is different
    private void PopulateTrees()
    {
        _changingChecks = true;
        PopulateTree(treeWindows, _windowsTweaks);
        PopulateTree(treeCustom, _customTweaks);
        _changingChecks = false;
    }

    //categories stay real nodes so their context actions still work
    private void PopulateTree(TreeView tree, IEnumerable<TweakItem> tweaks)
    {
        tree.BeginUpdate();
        tree.Nodes.Clear();
        var saved = AppSettings.Instance.SelectedTweaks;
        var useDefaults = !AppSettings.Instance.SelectionInitialized;

        foreach (var category in tweaks.GroupBy(t =>
            string.IsNullOrWhiteSpace(t.Category) ? Loc.Get("Tweaker_Other") : t.Category))
        {
            var root = new TreeNode(Loc.TweakCategory(category.Key))
            {
                NodeFont = new Font(Font, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 102, 170)
            };
            foreach (var tweak in category.OrderBy(t => Loc.TweakName(t.Name), StringComparer.CurrentCultureIgnoreCase))
            {
                //only display text changes, Tag keeps the original tweak
                var node = new TreeNode(Loc.TweakName(tweak.Name))
                {
                    Tag = tweak,
                    ToolTipText = Loc.TweakDescription(tweak.Name, tweak.Description),
                    Checked = useDefaults ? tweak.DefaultSelected : saved.Contains(tweak.Name)
                };
                root.Nodes.Add(node);
            }
            root.Checked = root.Nodes.Cast<TreeNode>().All(node => node.Checked);
            root.Expand();
            tree.Nodes.Add(root);
        }
        tree.EndUpdate();
    }

    //keeps category and child checkboxes in sync
    private void Tree_AfterCheck(object? sender, TreeViewEventArgs e)
    {
        if (_changingChecks) return;
        _changingChecks = true;
        if (e.Node.Tag == null)
            foreach (TreeNode child in e.Node.Nodes) child.Checked = e.Node.Checked;
        else if (e.Node.Parent != null)
            e.Node.Parent.Checked = e.Node.Parent.Nodes.Cast<TreeNode>().All(node => node.Checked);
        _changingChecks = false;
        SaveSelection();
    }

    private void Tree_NodeMouseClick(object? sender, TreeNodeMouseClickEventArgs e)
    {
        if (e.Button != MouseButtons.Right) return;
        if (!(sender is TreeView tree)) return;
        tree.SelectedNode = e.Node;
        _menuNode = e.Node;

        _contextNodes.Clear();
        _contextTweaks.Clear();

        if (e.Node.Tag is TweakItem tweak)
        {
            _contextNodes.Add(e.Node);
            _contextTweaks.Add(tweak); //entry runs even if its checkbox is off
        }
        else
        {
            //category check menu touches all, run actions only checked ones
            _contextNodes.AddRange(e.Node.Nodes.Cast<TreeNode>());
            _contextTweaks.AddRange(_contextNodes.Where(node => node.Checked)
                .Select(node => node.Tag).OfType<TweakItem>());
        }
    }

    //checks only nodes belonging to the opened context menu
    private void SetContextNodesChecked(bool value)
    {
        if (_contextNodes.Count == 0) return;
        _changingChecks = true;
        foreach (var node in _contextNodes) SetNodeCheck(node, value);
        _changingChecks = false;
        SaveSelection();
    }

    private static void SetNodeCheck(TreeNode node, bool value)
    {
        node.Checked = value;
        foreach (TreeNode child in node.Nodes) SetNodeCheck(child, value);
    }

    //keep checked entries from both tabs in the same small settings list
    private void SaveSelection()
    {
        if (!_loaded) return;
        ResetIssueMode();
        AppSettings.Instance.SelectedTweaks = new HashSet<string>(
            GetCheckedTweaks(treeWindows).Concat(GetCheckedTweaks(treeCustom))
                .Select(tweak => tweak.Name), StringComparer.OrdinalIgnoreCase);
        AppSettings.Instance.SelectionInitialized = true;
        AppSettings.Instance.Save();
    }

    //results belong to one tab, switching starts with its clean ready state
    private void TabCategories_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (!_loaded || _busy) return;
        _menuNode = null;
        _contextNodes.Clear();
        _contextTweaks.Clear();
        ClearResults();
        ShowResultList();
        ShowReadyText();
    }

    //the bottom buttons always follow the tree in the open tab
    private List<TweakItem> GetCheckedTweaks() => GetCheckedTweaks(ActiveTree);

    //collects checked tweaks from the simple category > tweak layout
    private static List<TweakItem> GetCheckedTweaks(TreeView tree)
    {
        var selected = new List<TweakItem>();
        foreach (TreeNode category in tree.Nodes)
            foreach (TreeNode node in category.Nodes)
                if (node.Checked && node.Tag is TweakItem tweak) selected.Add(tweak);
        return selected;
    }

    //find the exact object in either tab and color its node
    private void SetNodeColor(TweakItem tweak, Color color)
    {
        foreach (var tree in new[] { treeWindows, treeCustom })
            foreach (TreeNode category in tree.Nodes)
                foreach (TreeNode node in category.Nodes)
                    if (ReferenceEquals(node.Tag, tweak)) node.ForeColor = color;
    }
}
