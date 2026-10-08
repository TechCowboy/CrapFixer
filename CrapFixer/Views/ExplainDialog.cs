using CrapFixer.Features.AI;
using CrapFixer.Models;
using CrapFixer.Services;

namespace CrapFixer.Views;

//opens first, then fills the answer when the provider is done
public partial class ExplainDialog : Form
{
    internal ExplainDialog(string tweakName)
    {
        InitializeComponent();
        btnClose.Text = Loc.Get("Explain_Close");
        txtBody.Text = Loc.Get("Explain_Thinking");
        Text = tweakName;
    }

    internal async Task LoadAsync(TweakItem tweak)
    {
        var answer = await AiExplainer.ExplainAsync(tweak);
        if (!IsDisposed) txtBody.Text = answer;
    }
}
