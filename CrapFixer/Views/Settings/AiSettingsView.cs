using System.Diagnostics;
using CrapFixer.Features.AI;
using CrapFixer.Services;

namespace CrapFixer.Views.Settings;

//provider and key page for the optional tweak explanation
public partial class AiSettingsView : UserControl, ISettingsPage
{
    private string _groqKey = "";
    private string _openAiKey = "";
    private string _anthropicKey = "";
    private string _compatibleKey = "";
    private string _compatibleEndpoint = "";
    private string _compatibleModel = "";
    private string _currentProvider = "Groq";
    private bool _loading;

    public AiSettingsView()
    {
        InitializeComponent();
        ApplyLocalization();
        LoadFromSettings();
    }

    private void ApplyLocalization()
    {
        lblDescription.Text = Loc.Get("Ai_Description");
        lblProvider.Text = Loc.Get("Ai_Provider");
        lblEndpoint.Text = Loc.Get("Ai_Endpoint");
        lblModel.Text = Loc.Get("Ai_Model");
        btnTest.Text = Loc.Get("Ai_Test");
    }

    public void LoadFromSettings()
    {
        _loading = true;
        try
        {
            _groqKey = AppSettings.Instance.GroqApiKey ?? "";
            _openAiKey = AppSettings.Instance.OpenAiApiKey ?? "";
            _anthropicKey = AppSettings.Instance.AnthropicApiKey ?? "";
            _compatibleKey = AppSettings.Instance.OpenAiCompatibleApiKey ?? "";
            _compatibleEndpoint = AppSettings.Instance.OpenAiCompatibleEndpoint;
            _compatibleModel = AppSettings.Instance.OpenAiCompatibleModel;
            _currentProvider = AppSettings.Instance.AiProvider is "OpenAI" or "Anthropic" or "OpenAI-compatible"
                ? AppSettings.Instance.AiProvider : "Groq";
            cboProvider.SelectedItem = _currentProvider;
            ApplyProviderToUi();
            lblTestResult.Text = "";
        }
        finally { _loading = false; }
    }

    public void Save()
    {
        KeepCurrentValues();
        AppSettings.Instance.AiProvider = _currentProvider;
        AppSettings.Instance.GroqApiKey = EmptyToNull(_groqKey);
        AppSettings.Instance.OpenAiApiKey = EmptyToNull(_openAiKey);
        AppSettings.Instance.AnthropicApiKey = EmptyToNull(_anthropicKey);
        AppSettings.Instance.OpenAiCompatibleApiKey = EmptyToNull(_compatibleKey);
        AppSettings.Instance.OpenAiCompatibleEndpoint = _compatibleEndpoint;
        AppSettings.Instance.OpenAiCompatibleModel = _compatibleModel;
    }

    private void CboProvider_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (_loading) return;
        KeepCurrentValues();
        _currentProvider = cboProvider.SelectedItem as string ?? "Groq";
        ApplyProviderToUi();
    }

    //dont lose edits when the provider is switched
    private void KeepCurrentValues()
    {
        switch (_currentProvider)
        {
            case "OpenAI": _openAiKey = txtApiKey.Text.Trim(); break;
            case "Anthropic": _anthropicKey = txtApiKey.Text.Trim(); break;
            case "OpenAI-compatible":
                _compatibleKey = txtApiKey.Text.Trim();
                _compatibleEndpoint = txtEndpoint.Text.Trim();
                _compatibleModel = txtModel.Text.Trim();
                break;
            default: _groqKey = txtApiKey.Text.Trim(); break;
        }
    }

    private void ApplyProviderToUi()
    {
        (txtApiKey.Text, lblApiKey.Text, lnkGetKey.Text) = _currentProvider switch
        {
            "OpenAI" => (_openAiKey, Loc.Get("Ai_OpenAiKey"), Loc.Get("Ai_GetOpenAiKey")),
            "Anthropic" => (_anthropicKey, Loc.Get("Ai_AnthropicKey"), Loc.Get("Ai_GetAnthropicKey")),
            "OpenAI-compatible" => (_compatibleKey, Loc.Get("Ai_ApiKey"), ""),
            _ => (_groqKey, Loc.Get("Ai_GroqKey"), Loc.Get("Ai_GetGroqKey"))
        };

        var custom = _currentProvider == "OpenAI-compatible";
        lblEndpoint.Visible = txtEndpoint.Visible = lblModel.Visible = txtModel.Visible = custom;
        lnkGetKey.Visible = !custom;
        if (custom)
        {
            txtEndpoint.Text = _compatibleEndpoint;
            txtModel.Text = _compatibleModel;
        }
        lblTestResult.Text = "";
    }

    private async void BtnTest_Click(object? sender, EventArgs e)
    {
        var key = txtApiKey.Text.Trim();
        if (key.Length == 0) { lblTestResult.Text = Loc.Get("Ai_EnterKey"); return; }
        if (_currentProvider == "OpenAI-compatible" &&
            (txtEndpoint.Text.Trim().Length == 0 || txtModel.Text.Trim().Length == 0))
        {
            lblTestResult.Text = Loc.Get("Ai_EnterEndpointModel");
            return;
        }

        SetTesting(true);
        try
        {
            lblTestResult.Text = await AiExplainer.TestKeyAsync(
                key, _currentProvider, txtEndpoint.Text.Trim(), txtModel.Text.Trim());
        }
        finally { SetTesting(false); }
    }

    private void SetTesting(bool testing)
    {
        btnTest.Enabled = cboProvider.Enabled = txtApiKey.Enabled = !testing;
        txtEndpoint.Enabled = txtModel.Enabled = !testing;
        if (testing) lblTestResult.Text = Loc.Get("Ai_Testing");
    }

    private void LnkGetKey_LinkClicked(object? sender, LinkLabelLinkClickedEventArgs e)
    {
        var url = _currentProvider switch
        {
            "OpenAI" => "https://platform.openai.com/api-keys",
            "Anthropic" => "https://console.anthropic.com/settings/keys",
            _ => "https://console.groq.com/keys"
        };
        try { Process.Start(new ProcessStartInfo(url) { UseShellExecute = true }); }
        catch { }
    }

    private static string? EmptyToNull(string value) => value.Length == 0 ? null : value;
}
