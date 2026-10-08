namespace CrapFixer.Views.Settings;

partial class AdvancedSettingsView
{
    private System.ComponentModel.IContainer components = null;
    private GroupBox grpSettings;
    private CheckBox chkBackup;
    private CheckBox chkConfirm;
    private Button btnOpenBackup;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    #region Component Designer generated code

    private void InitializeComponent()
    {
        this.grpSettings = new System.Windows.Forms.GroupBox();
        this.btnOpenBackup = new System.Windows.Forms.Button();
        this.chkConfirm = new System.Windows.Forms.CheckBox();
        this.chkBackup = new System.Windows.Forms.CheckBox();
        this.grpSettings.SuspendLayout();
        this.SuspendLayout();
        // 
        // grpSettings
        // 
        this.grpSettings.Controls.Add(this.btnOpenBackup);
        this.grpSettings.Controls.Add(this.chkConfirm);
        this.grpSettings.Controls.Add(this.chkBackup);
        this.grpSettings.Dock = System.Windows.Forms.DockStyle.Fill;
        this.grpSettings.Location = new System.Drawing.Point(0, 0);
        this.grpSettings.Name = "grpSettings";
        this.grpSettings.Size = new System.Drawing.Size(544, 447);
        this.grpSettings.TabIndex = 0;
        this.grpSettings.TabStop = false;
        // 
        // btnOpenBackup
        // 
        this.btnOpenBackup.Location = new System.Drawing.Point(18, 74);
        this.btnOpenBackup.Name = "btnOpenBackup";
        this.btnOpenBackup.Size = new System.Drawing.Size(150, 25);
        this.btnOpenBackup.TabIndex = 2;
        this.btnOpenBackup.Text = "Open backup folder";
        this.btnOpenBackup.UseVisualStyleBackColor = true;
        this.btnOpenBackup.Click += new System.EventHandler(this.BtnOpenBackup_Click);
        // 
        // chkConfirm
        // 
        this.chkConfirm.AutoSize = true;
        this.chkConfirm.Location = new System.Drawing.Point(18, 48);
        this.chkConfirm.Name = "chkConfirm";
        this.chkConfirm.Size = new System.Drawing.Size(203, 17);
        this.chkConfirm.TabIndex = 1;
        this.chkConfirm.Text = "Confirm apply and removal actions";
        this.chkConfirm.UseVisualStyleBackColor = true;
        // 
        // chkBackup
        // 
        this.chkBackup.AutoSize = true;
        this.chkBackup.Location = new System.Drawing.Point(18, 22);
        this.chkBackup.Name = "chkBackup";
        this.chkBackup.Size = new System.Drawing.Size(259, 17);
        this.chkBackup.TabIndex = 0;
        this.chkBackup.Text = "Create a registry backup before applying tweaks";
        this.chkBackup.UseVisualStyleBackColor = true;
        // 
        // AdvancedSettingsView
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.AutoScroll = true;
        this.AutoScrollMinSize = new System.Drawing.Size(500, 120);
        this.BackColor = System.Drawing.Color.White;
        this.Controls.Add(this.grpSettings);
        this.Name = "AdvancedSettingsView";
        this.Size = new System.Drawing.Size(544, 447);
        this.grpSettings.ResumeLayout(false);
        this.grpSettings.PerformLayout();
        this.ResumeLayout(false);
    }

    #endregion
}
