using CrapFixer.Services;

namespace CrapFixer.Views;

// raw Wintweak2 block editor, easier to review than a pile of small fields
public partial class CustomTweakDialog : Form
{
    private readonly string? _existingPath;
    private readonly bool _wasEnabled;

    internal CustomTweakDialog(CustomTweakService.Entry? existing)
    {
        InitializeComponent();
        ApplyLocalization();
        if (existing == null)
        {
            Text = Loc.Get("CustomDialog_Create");
            _wasEnabled = true;
        }
        else
        {
            Text = Loc.Get("CustomDialog_Edit");
            _existingPath = existing.FilePath;
            _wasEnabled = existing.Enabled;
            txtName.Text = existing.Name;
            txtBody.Text = CustomTweakService.ReadBody(existing.FilePath);
        }
    }

    private void ApplyLocalization()
    {
        lblName.Text = Loc.Get("CustomDialog_Name");
        btnTemplate.Text = Loc.Get("CustomDialog_Template");
        btnSave.Text = Loc.Get("CustomDialog_Save");
        btnCancel.Text = Loc.Get("CustomDialog_Cancel");
    }

    private void BtnTemplate_Click(object? sender, EventArgs e) => txtBody.Text = CustomTweakService.Template;

    private void BtnSave_Click(object? sender, EventArgs e)
    {
        var name = txtName.Text.Trim();
        var body = txtBody.Text;
        if (name.Length == 0)
        {
            KeepOpen(Loc.Get("CustomDialog_NameRequired"));
            return;
        }
        if (!HasLine(body, "Path") || !HasLine(body, "ValueName") || !HasLine(body, "RecommendedValue"))
        {
            KeepOpen(Loc.Get("CustomDialog_FieldsRequired"));
            return;
        }

        try { CustomTweakService.Save(name, body, _existingPath, _wasEnabled); }
        catch (Exception ex) { KeepOpen(ex.Message); }
    }

    private static bool HasLine(string body, string key) => body.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
        .Any(line => line.TrimStart().StartsWith(key + "=", StringComparison.OrdinalIgnoreCase));

    private void KeepOpen(string text)
    {
        MessageBox.Show(this, text, Loc.Get("CustomDialog_Title"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
        DialogResult = DialogResult.None;
    }
}
