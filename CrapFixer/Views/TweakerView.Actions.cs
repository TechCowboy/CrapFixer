using CrapFixer.Models;
using CrapFixer.Services;
using System.Diagnostics;
using System.Security.Principal;

namespace CrapFixer.Views;

//scan, apply and restore actions from buttons or the tree menu
public partial class TweakerView
{
    // --- CrapCheckThis handoff start ---
    // temporary Windows selection, no saved checkboxes or custom-tab tweaks get overwritten
    internal async Task<List<string>> AnalyzeCrapCheckThisHandoffAsync(HashSet<string> names)
    {
        if (_busy || !_loaded) throw new InvalidOperationException(Loc.Get("Handoff_NotReady"));
        tabCategories.SelectedTab = tabWindows;
        _menuNode = null;
        _contextNodes.Clear();
        _contextTweaks.Clear();
        _changingChecks = true;
        try
        {
            foreach (TreeNode category in treeWindows.Nodes)
            {
                foreach (TreeNode node in category.Nodes)
                    node.Checked = node.Tag is TweakItem tweak && names.Contains(tweak.Name);
                category.Checked = category.Nodes.Cast<TreeNode>().All(node => node.Checked);
            }
        }
        finally { _changingChecks = false; }

        var selected = GetCheckedTweaks(treeWindows);
        var skipped = names.Except(selected.Select(tweak => tweak.Name), StringComparer.OrdinalIgnoreCase).ToList();
        if (selected.Count == 0)
        {
            // an unknown selection must not leave old results or an active Run button
            ClearResults();
            ShowResultList();
            SetIssueMode(new List<TweakItem>());
        }
        await AnalyzeTweaksAsync(selected);
        if (!IsDisposed)
            // use the summary's blank line for the handoff note, keep its normal height
            txtSummary.Text = Loc.Format("Handoff_Received", selected.Count) + "\r\n" +
                txtSummary.Text.Replace("\r\n\r\n", "\r\n");
        return skipped;
    }
    // --- CrapCheckThis handoff end; normal actions below ---

    //menu actions use the right-click list, never the global selection
    private async void MiAnalyzeContext_Click(object? sender, EventArgs e)
    {
        if (_busy) return;
        await AnalyzeTweaksAsync(_contextTweaks);
    }

    private async void MiApplyContext_Click(object? sender, EventArgs e)
    {
        if (_busy) return;
        await ApplyTweaksAsync(_contextTweaks);
    }

    //dialog opens first, answer arrives without freezing the main view
    private void MiExplain_Click(object? sender, EventArgs e)
    {
        if (!(_menuNode?.Tag is TweakItem tweak)) return;
        using var dialog = new ExplainDialog(Loc.TweakName(tweak.Name));
        dialog.Shown += async (_, _) => await dialog.LoadAsync(tweak);
        dialog.ShowDialog(FindForm());
    }

    //analyze button follows the open tab
    private async void Analyze_Click(object? sender, EventArgs e)
    {
        if (_busy || !_loaded) return;
        await AnalyzeTweaksAsync();
    }

    //without a context scope only checked tweaks from the open tab are used
    private async Task AnalyzeTweaksAsync(IEnumerable<TweakItem>? scope = null)
    {
        var selected = scope == null ? GetCheckedTweaks() : scope.ToList();
        if (selected.Count == 0) { txtSummary.Text = Loc.Get("Tweaker_NothingSelected"); return; }
        SetBusy(true, Loc.Format("Tweaker_AnalyzingCount", selected.Count));
        ClearResults();
        ShowResultList();
        try
        {
            var done = 0;
            var issues = new List<TweakItem>();
            foreach (var tweak in selected)
            {
                //service checks every registry value belonging to this tweak
                txtSummary.Text = Loc.Format("Tweaker_AnalyzingItem", Loc.TweakName(tweak.Name), ++done, selected.Count);
                await _tweaker.ScanAsync(tweak);
                var isApplied = tweak.Status == TweakStatus.Applied;
                AddResult(tweak, isApplied ? Loc.Get("Tweaker_Applied") : Loc.Get("Tweaker_NotApplied"),
                    tweak.CurrentValue ?? Loc.Get("Common_NotSet"), isApplied ? Color.Gray : Color.Firebrick);
                SetNodeColor(tweak, isApplied ? Color.Gray : Color.Firebrick);
                if (!isApplied) issues.Add(tweak);
            }
            var applied = selected.Count(t => t.Status == TweakStatus.Applied);
            ShowAnalysisSummary(selected.Count, applied);
            SetIssueMode(issues);
        }
        catch (Exception ex) { txtSummary.Text = Loc.Format("Tweaker_AnalysisFailed", ex.Message); }
        finally { lvResults.Sort(); SetBusy(false); }
    }

    //bottom button applies checked tweaks from the open tab
    private async void Run_Click(object? sender, EventArgs e)
    {
        if (_busy || !_loaded) return;
        await ApplyTweaksAsync(_lastIssues);
    }

    private async Task ApplyTweaksAsync(IEnumerable<TweakItem>? scope = null)
    {
        var selected = scope == null ? GetCheckedTweaks() : scope.ToList();
        if (selected.Count == 0) { txtSummary.Text = Loc.Get("Tweaker_NothingSelected"); return; }
        if (selected.Any(t => t.RequiresAdmin) && !IsAdministrator())
        {
            AskForAdministratorRestart(selected);
            return;
        }
        if (AppSettings.Instance.ConfirmActions && MessageBox.Show(
            Loc.Format("Tweaker_ConfirmApply", selected.Count), Loc.Get("Tweaker_Run"),
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

        SetBusy(true, Loc.Get("Tweaker_Preparing"));
        ClearResults();
        ShowResultList();
        try
        {
            //backup is best effort, a missing value just has nothing to export
            string? backup = null;
            if (AppSettings.Instance.BackupBeforeApply) backup = await _tweaker.BackupAsync(selected);
            var failed = 0;
            var issues = new List<TweakItem>();
            for (var i = 0; i < selected.Count; i++)
            {
                var tweak = selected[i];
                txtSummary.Text = Loc.Format("Tweaker_ApplyingItem", Loc.TweakName(tweak.Name), i + 1, selected.Count);
                var error = await _tweaker.ApplyAsync(tweak);
                await _tweaker.ScanAsync(tweak);
                if (error != null)
                {
                    failed++;
                    issues.Add(tweak);
                    AddResult(tweak, Loc.Get("Tweaker_Failed"), error, Color.Firebrick);
                    SetNodeColor(tweak, Color.Firebrick);
                }
                else
                {
                    var isApplied = tweak.Status == TweakStatus.Applied;
                    AddResult(tweak, isApplied ? Loc.Get("Tweaker_Applied") : Loc.Get("Tweaker_NotApplied"),
                        tweak.CurrentValue ?? Loc.Get("Common_NotSet"), isApplied ? Color.Gray : Color.Firebrick);
                    SetNodeColor(tweak, isApplied ? Color.Gray : Color.Firebrick);
                    if (!isApplied) issues.Add(tweak);
                }
            }

            var message = Loc.Format("Tweaker_ApplyDone", selected.Count - failed, failed);
            if (backup != null) message += "\r\n" + Loc.Format("Tweaker_Backup", backup);
            if (selected.Any(t => t.RestartExplorer)) message += "\r\n" + Loc.Get("Tweaker_RestartExplorer");
            if (selected.Any(t => t.RestartRequired)) message += "\r\n" + Loc.Get("Tweaker_RestartWindows");
            txtSummary.Text = message;
            SetIssueMode(issues);
        }
        catch (Exception ex) { txtSummary.Text = Loc.Format("Tweaker_ApplyFailed", ex.Message); }
        finally { lvResults.Sort(); SetBusy(false); }
    }

    //restores one entry or a complete category
    private async void RestoreItem_Click(object? sender, EventArgs e)
    {
        if (_busy) return;

        //category restore uses all children, not just checked ones
        var targets = GetContextResetTargets();
        var resettable = targets.Where(HasDefaultValue).ToList();
        var skipped = targets.Count - resettable.Count;
        if (resettable.Count == 0)
        {
            MessageBox.Show(Loc.Get("Tweaker_NoDefaults"), Loc.Get("Tweaker_RestoreDefault"));
            return;
        }
        if (resettable.Any(tweak => tweak.RequiresAdmin) && !IsAdministrator())
        {
            AskForAdministratorRestart(resettable);
            return;
        }

        var label = _menuNode?.Tag is TweakItem single
            ? Loc.Format("Tweaker_ConfirmRestoreOne", Loc.TweakName(single.Name))
            : Loc.Format("Tweaker_ConfirmRestoreCategory", resettable.Count, _menuNode?.Text ?? "");
        if (MessageBox.Show(label, Loc.Get("Tweaker_RestoreDefault"),
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

        SetBusy(true, Loc.Get("Tweaker_Restoring"));
        ClearResults();
        ShowResultList();
        var failed = 0;
        try
        {
            for (var i = 0; i < resettable.Count; i++)
            {
                var tweak = resettable[i];
                txtSummary.Text = Loc.Format("Tweaker_RestoringItem", Loc.TweakName(tweak.Name), i + 1, resettable.Count);
                var error = await _tweaker.ResetAsync(tweak);
                await _tweaker.ScanAsync(tweak);
                if (error == null)
                    AddResult(tweak, Loc.Get("Tweaker_Restored"), tweak.CurrentValue ?? Loc.Get("Common_NotSet"), Color.Gray);
                else
                {
                    failed++;
                    AddResult(tweak, Loc.Get("Tweaker_Failed"), error, Color.Firebrick);
                }
            }

            txtSummary.Text = Loc.Format("Tweaker_RestoreDone", resettable.Count - failed, failed);
            if (skipped > 0) txtSummary.AppendText("\r\n" + Loc.Format("Tweaker_RestoreSkipped", skipped));
            if (resettable.Any(tweak => tweak.RestartExplorer))
                txtSummary.AppendText("\r\n" + Loc.Get("Tweaker_RestartExplorer"));
            if (resettable.Any(tweak => tweak.RestartRequired))
                txtSummary.AppendText("\r\n" + Loc.Get("Tweaker_RestartWindows"));
        }
        finally { lvResults.Sort(); SetBusy(false); }
    }

    //returns one tweak or all children from the clicked category
    private List<TweakItem> GetContextResetTargets()
    {
        if (_menuNode?.Tag is TweakItem tweak) return new List<TweakItem> { tweak };
        return _contextNodes.Select(node => node.Tag).OfType<TweakItem>().ToList();
    }

    private static bool HasDefaultValue(TweakItem tweak) =>
        tweak.AllEntries().Any(entry => !string.IsNullOrWhiteSpace(entry.DefaultValue));

    private static bool IsAdministrator()
    {
        using var identity = WindowsIdentity.GetCurrent();
        return new WindowsPrincipal(identity).IsInRole(WindowsBuiltInRole.Administrator);
    }

    //starts the same exe again through the normal Windows UAC dialog
    private void AskForAdministratorRestart(IEnumerable<TweakItem> selection)
    {
        if (MessageBox.Show(
            Loc.Get("Tweaker_AdminPrompt"),
            Loc.Get("Tweaker_AdminTitle"), MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning) != DialogResult.Yes) return;

        try
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = Application.ExecutablePath,
                WorkingDirectory = AppContext.BaseDirectory,
                // CrapCheckThis handoff start - carry this action's Windows selection through UAC
                Arguments = ActiveTree == treeWindows
                    ? CrapCheckHandoff.GetAdministratorRestartArguments(selection.Select(tweak => tweak.Name)) : "",
                // handoff ends here; elevation still follows the normal user confirmation
                Verb = "runas",
                UseShellExecute = true
            });
            FindForm()?.Close();
        }
        catch
        {
            txtSummary.Text = Loc.Get("Tweaker_AdminCanceled");
        }
    }
}
