namespace CrapFixer.Views.Settings;

partial class AboutSettingsView
{
    private System.ComponentModel.IContainer components = null;
    private GroupBox grpAbout;
    private PictureBox picIcon;
    private Label lblAppName;
    private Label lblVersion;
    private Label lblPortableMode;
    private Label lblCopyright;
    private Label lblDescription;
    private LinkLabel lnkGitHub;
    private LinkLabel lnkIssues;
    private LinkLabel lnkHelp;
    private Label lblSettingsBackupDesc;
    private Button btnExport;
    private Button btnImport;
    private Label lblSettingsStatus;
    private LinkLabel lnkTranslator;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    #region Component Designer generated code

    private void InitializeComponent()
    {
        this.grpAbout = new System.Windows.Forms.GroupBox();
        this.lnkTranslator = new System.Windows.Forms.LinkLabel();
        this.lblSettingsStatus = new System.Windows.Forms.Label();
        this.btnImport = new System.Windows.Forms.Button();
        this.btnExport = new System.Windows.Forms.Button();
        this.lblSettingsBackupDesc = new System.Windows.Forms.Label();
        this.lnkHelp = new System.Windows.Forms.LinkLabel();
        this.lnkIssues = new System.Windows.Forms.LinkLabel();
        this.lnkGitHub = new System.Windows.Forms.LinkLabel();
        this.lblDescription = new System.Windows.Forms.Label();
        this.lblCopyright = new System.Windows.Forms.Label();
        this.lblVersion = new System.Windows.Forms.Label();
        this.lblPortableMode = new System.Windows.Forms.Label();
        this.lblAppName = new System.Windows.Forms.Label();
        this.picIcon = new System.Windows.Forms.PictureBox();
        this.grpAbout.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
        this.SuspendLayout();
        // 
        // grpAbout
        // 
        this.grpAbout.Controls.Add(this.lnkTranslator);
        this.grpAbout.Controls.Add(this.lblSettingsStatus);
        this.grpAbout.Controls.Add(this.btnImport);
        this.grpAbout.Controls.Add(this.btnExport);
        this.grpAbout.Controls.Add(this.lblSettingsBackupDesc);
        this.grpAbout.Controls.Add(this.lnkHelp);
        this.grpAbout.Controls.Add(this.lnkIssues);
        this.grpAbout.Controls.Add(this.lnkGitHub);
        this.grpAbout.Controls.Add(this.lblDescription);
        this.grpAbout.Controls.Add(this.lblCopyright);
        this.grpAbout.Controls.Add(this.lblVersion);
        this.grpAbout.Controls.Add(this.lblPortableMode);
        this.grpAbout.Controls.Add(this.lblAppName);
        this.grpAbout.Controls.Add(this.picIcon);
        this.grpAbout.Dock = System.Windows.Forms.DockStyle.Fill;
        this.grpAbout.Location = new System.Drawing.Point(0, 0);
        this.grpAbout.Name = "grpAbout";
        this.grpAbout.Size = new System.Drawing.Size(544, 447);
        this.grpAbout.TabIndex = 0;
        this.grpAbout.TabStop = false;
        // 
        // lnkTranslator
        // 
        this.lnkTranslator.AutoSize = true;
        this.lnkTranslator.Location = new System.Drawing.Point(77, 87);
        this.lnkTranslator.Name = "lnkTranslator";
        this.lnkTranslator.Size = new System.Drawing.Size(64, 13);
        this.lnkTranslator.TabIndex = 4;
        this.lnkTranslator.TabStop = true;
        this.lnkTranslator.Text = "Translation";
        this.lnkTranslator.Visible = false;
        this.lnkTranslator.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkTranslator_LinkClicked);
        // 
        // lblSettingsStatus
        // 
        this.lblSettingsStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
        this.lblSettingsStatus.AutoEllipsis = true;
        this.lblSettingsStatus.ForeColor = System.Drawing.Color.SeaGreen;
        this.lblSettingsStatus.Location = new System.Drawing.Point(33, 282);
        this.lblSettingsStatus.Name = "lblSettingsStatus";
        this.lblSettingsStatus.Size = new System.Drawing.Size(495, 30);
        this.lblSettingsStatus.TabIndex = 12;
        // 
        // btnImport
        // 
        this.btnImport.Location = new System.Drawing.Point(129, 250);
        this.btnImport.Name = "btnImport";
        this.btnImport.Size = new System.Drawing.Size(90, 25);
        this.btnImport.TabIndex = 11;
        this.btnImport.Text = "Import";
        this.btnImport.UseVisualStyleBackColor = true;
        this.btnImport.Click += new System.EventHandler(this.BtnImport_Click);
        // 
        // btnExport
        // 
        this.btnExport.Location = new System.Drawing.Point(33, 250);
        this.btnExport.Name = "btnExport";
        this.btnExport.Size = new System.Drawing.Size(90, 25);
        this.btnExport.TabIndex = 10;
        this.btnExport.Text = "Export";
        this.btnExport.UseVisualStyleBackColor = true;
        this.btnExport.Click += new System.EventHandler(this.BtnExport_Click);
        // 
        // lblSettingsBackupDesc
        // 
        this.lblSettingsBackupDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
        this.lblSettingsBackupDesc.AutoEllipsis = true;
        this.lblSettingsBackupDesc.Location = new System.Drawing.Point(33, 228);
        this.lblSettingsBackupDesc.Name = "lblSettingsBackupDesc";
        this.lblSettingsBackupDesc.Size = new System.Drawing.Size(495, 16);
        this.lblSettingsBackupDesc.TabIndex = 9;
        this.lblSettingsBackupDesc.Text = "Export or import your settings as JSON. Place settings.json next to the app for portable mode.";
        // 
        // lnkHelp
        // 
        this.lnkHelp.AutoEllipsis = true;
        this.lnkHelp.Location = new System.Drawing.Point(216, 178);
        this.lnkHelp.Name = "lnkHelp";
        this.lnkHelp.Size = new System.Drawing.Size(103, 13);
        this.lnkHelp.TabIndex = 7;
        this.lnkHelp.TabStop = true;
        this.lnkHelp.Text = "Help";
        this.lnkHelp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkHelp_LinkClicked);
        // 
        // lnkIssues
        // 
        this.lnkIssues.AutoEllipsis = true;
        this.lnkIssues.Location = new System.Drawing.Point(107, 178);
        this.lnkIssues.Name = "lnkIssues";
        this.lnkIssues.Size = new System.Drawing.Size(103, 13);
        this.lnkIssues.TabIndex = 6;
        this.lnkIssues.TabStop = true;
        this.lnkIssues.Text = "Report an issue";
        this.lnkIssues.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkIssues_LinkClicked);
        // 
        // lnkGitHub
        // 
        this.lnkGitHub.AutoSize = true;
        this.lnkGitHub.Location = new System.Drawing.Point(33, 178);
        this.lnkGitHub.Name = "lnkGitHub";
        this.lnkGitHub.Size = new System.Drawing.Size(40, 13);
        this.lnkGitHub.TabIndex = 5;
        this.lnkGitHub.TabStop = true;
        this.lnkGitHub.Text = "GitHub";
        this.lnkGitHub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkGitHub_LinkClicked);
        // 
        // lblDescription
        // 
        this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
        this.lblDescription.AutoEllipsis = true;
        this.lblDescription.Location = new System.Drawing.Point(13, 122);
        this.lblDescription.Name = "lblDescription";
        this.lblDescription.Size = new System.Drawing.Size(515, 44);
        this.lblDescription.TabIndex = 4;
        this.lblDescription.Text = "CrapFixer is a lightweight Windows tweaking companion to FluentCleaner. It uses the Wintweak2.ini and Winappx.ini databases.";
        // 
        // lblCopyright
        // 
        this.lblCopyright.AutoSize = true;
        this.lblCopyright.Location = new System.Drawing.Point(77, 68);
        this.lblCopyright.Name = "lblCopyright";
        this.lblCopyright.Size = new System.Drawing.Size(190, 13);
        this.lblCopyright.TabIndex = 3;
        this.lblCopyright.Text = "Copyright © 2026 A Belim app creation";
        // 
        // lblVersion
        // 
        this.lblVersion.AutoSize = true;
        this.lblVersion.Location = new System.Drawing.Point(77, 50);
        this.lblVersion.Name = "lblVersion";
        this.lblVersion.Size = new System.Drawing.Size(69, 13);
        this.lblVersion.TabIndex = 2;
        this.lblVersion.Text = "Version 0.0.0";
        // 
        // lblPortableMode
        // 
        this.lblPortableMode.AutoSize = true;
        this.lblPortableMode.ForeColor = System.Drawing.Color.SeaGreen;
        this.lblPortableMode.Location = new System.Drawing.Point(146, 50);
        this.lblPortableMode.Name = "lblPortableMode";
        this.lblPortableMode.Size = new System.Drawing.Size(90, 13);
        this.lblPortableMode.TabIndex = 3;
        this.lblPortableMode.Text = "  ·  Portable mode";
        this.lblPortableMode.Visible = false;
        // 
        // lblAppName
        // 
        this.lblAppName.AutoSize = true;
        this.lblAppName.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
        this.lblAppName.Location = new System.Drawing.Point(72, 24);
        this.lblAppName.Name = "lblAppName";
        this.lblAppName.Size = new System.Drawing.Size(105, 17);
        this.lblAppName.TabIndex = 1;
        this.lblAppName.Text = "CrapFixer";
        // 
        // picIcon
        // 
        this.picIcon.Location = new System.Drawing.Point(10, 20);
        this.picIcon.Name = "picIcon";
        this.picIcon.Size = new System.Drawing.Size(60, 57);
        this.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        this.picIcon.TabIndex = 0;
        this.picIcon.TabStop = false;
        // 
        // AboutSettingsView
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.AutoScroll = true;
        this.AutoScrollMinSize = new System.Drawing.Size(400, 300);
        this.BackColor = System.Drawing.Color.White;
        this.Controls.Add(this.grpAbout);
        this.Name = "AboutSettingsView";
        this.Size = new System.Drawing.Size(544, 447);
        this.grpAbout.ResumeLayout(false);
        this.grpAbout.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
        this.ResumeLayout(false);
    }

    #endregion
}
