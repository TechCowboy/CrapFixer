using CrapFixer.Services;

namespace CrapFixer.Views.Tools;

public partial class CustomTweaksView : UserControl
{
    private bool _suppressChecks;

    public event EventHandler? CustomTweaksChanged;

    public CustomTweaksView()
    {
        InitializeComponent();
        ApplyLocalization();
        LoadEntries();
    }

    private void ApplyLocalization()
    {
        lblHint.Text = Loc.Get("Custom_Hint");
        colName.Text = Loc.Get("Custom_Name");
        colStatus.Text = Loc.Get("Custom_Status");
        miEdit.Text = Loc.Get("Custom_Edit");
        miDelete.Text = btnDelete.Text = Loc.Get("Custom_Delete");
        btnNew.Text = Loc.Get("Custom_New");
    }

    // reload the files from the custom tweak folder
    public void LoadEntries()
    {
        _suppressChecks = true;
        lvCustom.Items.Clear();
        foreach (var entry in CustomTweakService.ListAll())
        {
            var row = new ListViewItem(entry.Name) { Tag = entry, Checked = entry.Enabled };
            row.SubItems.Add(entry.Enabled ? Loc.Get("Custom_Enabled") : Loc.Get("Custom_Disabled"));
            lvCustom.Items.Add(row);
        }
        _suppressChecks = false;
    }

    // checking decides if it appears in the Fixer tree
    private void LvCustom_ItemCheck(object? sender, ItemCheckEventArgs e)
    {
        if (_suppressChecks) return;
        if (!(lvCustom.Items[e.Index].Tag is CustomTweakService.Entry entry)) return;
        try
        {
            CustomTweakService.SetEnabled(entry, e.NewValue == CheckState.Checked);
            lvCustom.Items[e.Index].SubItems[1].Text = entry.Enabled ? Loc.Get("Custom_Enabled") : Loc.Get("Custom_Disabled");
            CustomTweaksChanged?.Invoke(this, EventArgs.Empty);
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message, Loc.Get("Custom_Title"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            BeginInvoke(new Action(LoadEntries));
        }
    }

    private void LvCustom_ItemActivate(object? sender, EventArgs e) => EditSelected();

    // right click also selects its row
    private void LvCustom_MouseDown(object? sender, MouseEventArgs e)
    {
        if (e.Button != MouseButtons.Right) return;
        var hit = lvCustom.GetItemAt(e.X, e.Y);
        if (hit != null) hit.Selected = true;
    }

    private void CmCustom_Opening(object? sender, System.ComponentModel.CancelEventArgs e)
    {
        var selected = lvCustom.SelectedItems.Count > 0;
        miEdit.Enabled = selected;
        miDelete.Enabled = selected;
    }

    private void BtnNew_Click(object? sender, EventArgs e)
    {
        using var dialog = new CustomTweakDialog(null);
        if (dialog.ShowDialog(this) != DialogResult.OK) return;
        LoadEntries();
        CustomTweaksChanged?.Invoke(this, EventArgs.Empty);
    }

    private void BtnEdit_Click(object? sender, EventArgs e) => EditSelected();

    private void EditSelected()
    {
        if (lvCustom.SelectedItems.Count == 0) return;
        if (!(lvCustom.SelectedItems[0].Tag is CustomTweakService.Entry entry)) return;
        using var dialog = new CustomTweakDialog(entry);
        if (dialog.ShowDialog(this) != DialogResult.OK) return;
        LoadEntries();
        CustomTweaksChanged?.Invoke(this, EventArgs.Empty);
    }

    private void BtnDelete_Click(object? sender, EventArgs e)
    {
        if (lvCustom.SelectedItems.Count == 0) return;
        if (!(lvCustom.SelectedItems[0].Tag is CustomTweakService.Entry entry)) return;
        if (MessageBox.Show(this, Loc.Format("Custom_ConfirmDelete", entry.Name), Loc.Get("Custom_DeleteTitle"),
            MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

        CustomTweakService.Delete(entry);
        LoadEntries();
        CustomTweaksChanged?.Invoke(this, EventArgs.Empty);
    }
}
