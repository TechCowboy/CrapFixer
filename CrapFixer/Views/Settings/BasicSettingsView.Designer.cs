namespace CrapFixer.Views.Settings;

partial class BasicSettingsView
{
    private System.ComponentModel.IContainer components = null;
    private GroupBox grpSettings;
    private Label lblDatabases;
    private CheckBox chkBuiltInDb;
    private Label lblWintweak2Info;
    private Label lblWintweak2Desc;
    private Button btnUpdateWintweak2;
    private Label lblWinappx;
    private Label lblWinappxInfo;
    private Label lblWinappxDesc;
    private Button btnUpdateWinappx;
    private CheckBox chkCustomDb;
    private TextBox txtCustomPath;
    private Button btnBrowse;
    private Button btnReload;
    private Label lblDatabaseStatus;
    private Label lblLanguage;
    private ComboBox cboLanguage;
    private LinkLabel lnkOpenLocalization;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    #region Component Designer generated code

    private void InitializeComponent()
    {
        this.grpSettings = new System.Windows.Forms.GroupBox();
        this.lnkOpenLocalization = new System.Windows.Forms.LinkLabel();
        this.cboLanguage = new System.Windows.Forms.ComboBox();
        this.lblLanguage = new System.Windows.Forms.Label();
        this.lblDatabaseStatus = new System.Windows.Forms.Label();
        this.btnReload = new System.Windows.Forms.Button();
        this.btnBrowse = new System.Windows.Forms.Button();
        this.txtCustomPath = new System.Windows.Forms.TextBox();
        this.chkCustomDb = new System.Windows.Forms.CheckBox();
        this.btnUpdateWinappx = new System.Windows.Forms.Button();
        this.lblWinappxDesc = new System.Windows.Forms.Label();
        this.lblWinappxInfo = new System.Windows.Forms.Label();
        this.lblWinappx = new System.Windows.Forms.Label();
        this.btnUpdateWintweak2 = new System.Windows.Forms.Button();
        this.lblWintweak2Desc = new System.Windows.Forms.Label();
        this.lblWintweak2Info = new System.Windows.Forms.Label();
        this.chkBuiltInDb = new System.Windows.Forms.CheckBox();
        this.lblDatabases = new System.Windows.Forms.Label();
        this.grpSettings.SuspendLayout();
        this.SuspendLayout();
        // 
        // grpSettings
        // 
        this.grpSettings.Controls.Add(this.lnkOpenLocalization);
        this.grpSettings.Controls.Add(this.cboLanguage);
        this.grpSettings.Controls.Add(this.lblLanguage);
        this.grpSettings.Controls.Add(this.lblDatabaseStatus);
        this.grpSettings.Controls.Add(this.btnReload);
        this.grpSettings.Controls.Add(this.btnBrowse);
        this.grpSettings.Controls.Add(this.txtCustomPath);
        this.grpSettings.Controls.Add(this.chkCustomDb);
        this.grpSettings.Controls.Add(this.btnUpdateWinappx);
        this.grpSettings.Controls.Add(this.lblWinappxDesc);
        this.grpSettings.Controls.Add(this.lblWinappxInfo);
        this.grpSettings.Controls.Add(this.lblWinappx);
        this.grpSettings.Controls.Add(this.btnUpdateWintweak2);
        this.grpSettings.Controls.Add(this.lblWintweak2Desc);
        this.grpSettings.Controls.Add(this.lblWintweak2Info);
        this.grpSettings.Controls.Add(this.chkBuiltInDb);
        this.grpSettings.Controls.Add(this.lblDatabases);
        this.grpSettings.Dock = System.Windows.Forms.DockStyle.Fill;
        this.grpSettings.Location = new System.Drawing.Point(0, 0);
        this.grpSettings.Name = "grpSettings";
        this.grpSettings.Size = new System.Drawing.Size(544, 447);
        this.grpSettings.TabIndex = 0;
        this.grpSettings.TabStop = false;
        // 
        // lnkOpenLocalization
        // 
        this.lnkOpenLocalization.AutoSize = true;
        this.lnkOpenLocalization.Location = new System.Drawing.Point(272, 24);
        this.lnkOpenLocalization.Name = "lnkOpenLocalization";
        this.lnkOpenLocalization.Size = new System.Drawing.Size(123, 13);
        this.lnkOpenLocalization.TabIndex = 2;
        this.lnkOpenLocalization.TabStop = true;
        this.lnkOpenLocalization.Text = "Open localization folder";
        this.lnkOpenLocalization.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkOpenLocalization_LinkClicked);
        // 
        // cboLanguage
        // 
        this.cboLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cboLanguage.FormattingEnabled = true;
        this.cboLanguage.Location = new System.Drawing.Point(90, 20);
        this.cboLanguage.Name = "cboLanguage";
        this.cboLanguage.Size = new System.Drawing.Size(166, 21);
        this.cboLanguage.TabIndex = 1;
        this.cboLanguage.SelectedIndexChanged += new System.EventHandler(this.CboLanguage_SelectedIndexChanged);
        // 
        // lblLanguage
        // 
        this.lblLanguage.AutoSize = true;
        this.lblLanguage.Location = new System.Drawing.Point(18, 24);
        this.lblLanguage.Name = "lblLanguage";
        this.lblLanguage.Size = new System.Drawing.Size(58, 13);
        this.lblLanguage.TabIndex = 0;
        this.lblLanguage.Text = "Language:";
        // 
        // lblDatabaseStatus
        // 
        this.lblDatabaseStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
        this.lblDatabaseStatus.AutoEllipsis = true;
        this.lblDatabaseStatus.ForeColor = System.Drawing.Color.SeaGreen;
        this.lblDatabaseStatus.Location = new System.Drawing.Point(18, 263);
        this.lblDatabaseStatus.Name = "lblDatabaseStatus";
        this.lblDatabaseStatus.Size = new System.Drawing.Size(510, 32);
        this.lblDatabaseStatus.TabIndex = 16;
        // 
        // btnReload
        // 
        this.btnReload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.btnReload.Location = new System.Drawing.Point(453, 231);
        this.btnReload.Name = "btnReload";
        this.btnReload.Size = new System.Drawing.Size(75, 23);
        this.btnReload.TabIndex = 15;
        this.btnReload.Text = "Reload";
        this.btnReload.UseVisualStyleBackColor = true;
        this.btnReload.Click += new System.EventHandler(this.BtnReload_Click);
        // 
        // btnBrowse
        // 
        this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.btnBrowse.Location = new System.Drawing.Point(372, 231);
        this.btnBrowse.Name = "btnBrowse";
        this.btnBrowse.Size = new System.Drawing.Size(75, 23);
        this.btnBrowse.TabIndex = 14;
        this.btnBrowse.Text = "Browse...";
        this.btnBrowse.UseVisualStyleBackColor = true;
        this.btnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
        // 
        // txtCustomPath
        // 
        this.txtCustomPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
        this.txtCustomPath.Location = new System.Drawing.Point(18, 233);
        this.txtCustomPath.Name = "txtCustomPath";
        this.txtCustomPath.Size = new System.Drawing.Size(348, 20);
        this.txtCustomPath.TabIndex = 13;
        // 
        // chkCustomDb
        // 
        this.chkCustomDb.AutoSize = true;
        this.chkCustomDb.Location = new System.Drawing.Point(18, 209);
        this.chkCustomDb.Name = "chkCustomDb";
        this.chkCustomDb.Size = new System.Drawing.Size(259, 17);
        this.chkCustomDb.TabIndex = 12;
        this.chkCustomDb.Text = "Additional custom database (merged with built-in)";
        this.chkCustomDb.UseVisualStyleBackColor = true;
        this.chkCustomDb.CheckedChanged += new System.EventHandler(this.ChkCustomDb_CheckedChanged);
        // 
        // btnUpdateWinappx
        // 
        this.btnUpdateWinappx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.btnUpdateWinappx.Location = new System.Drawing.Point(453, 156);
        this.btnUpdateWinappx.Name = "btnUpdateWinappx";
        this.btnUpdateWinappx.Size = new System.Drawing.Size(75, 23);
        this.btnUpdateWinappx.TabIndex = 11;
        this.btnUpdateWinappx.Text = "Update...";
        this.btnUpdateWinappx.UseVisualStyleBackColor = true;
        this.btnUpdateWinappx.Click += new System.EventHandler(this.BtnUpdateWinappx_Click);
        // 
        // lblWinappxDesc
        // 
        this.lblWinappxDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
        this.lblWinappxDesc.AutoEllipsis = true;
        this.lblWinappxDesc.ForeColor = System.Drawing.SystemColors.GrayText;
        this.lblWinappxDesc.Location = new System.Drawing.Point(36, 181);
        this.lblWinappxDesc.Name = "lblWinappxDesc";
        this.lblWinappxDesc.Size = new System.Drawing.Size(492, 17);
        this.lblWinappxDesc.TabIndex = 10;
        this.lblWinappxDesc.Text = "Package database used by Tools > App Remover.";
        // 
        // lblWinappxInfo
        // 
        this.lblWinappxInfo.AutoSize = true;
        this.lblWinappxInfo.ForeColor = System.Drawing.SystemColors.GrayText;
        this.lblWinappxInfo.Location = new System.Drawing.Point(109, 161);
        this.lblWinappxInfo.Name = "lblWinappxInfo";
        this.lblWinappxInfo.Size = new System.Drawing.Size(0, 13);
        this.lblWinappxInfo.TabIndex = 9;
        // 
        // lblWinappx
        // 
        this.lblWinappx.AutoSize = true;
        this.lblWinappx.Location = new System.Drawing.Point(18, 161);
        this.lblWinappx.Name = "lblWinappx";
        this.lblWinappx.Size = new System.Drawing.Size(65, 13);
        this.lblWinappx.TabIndex = 8;
        this.lblWinappx.Text = "Winappx.ini";
        // 
        // btnUpdateWintweak2
        // 
        this.btnUpdateWintweak2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.btnUpdateWintweak2.Location = new System.Drawing.Point(453, 101);
        this.btnUpdateWintweak2.Name = "btnUpdateWintweak2";
        this.btnUpdateWintweak2.Size = new System.Drawing.Size(75, 23);
        this.btnUpdateWintweak2.TabIndex = 7;
        this.btnUpdateWintweak2.Text = "Update...";
        this.btnUpdateWintweak2.UseVisualStyleBackColor = true;
        this.btnUpdateWintweak2.Click += new System.EventHandler(this.BtnUpdateWintweak2_Click);
        // 
        // lblWintweak2Desc
        // 
        this.lblWintweak2Desc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
        this.lblWintweak2Desc.AutoEllipsis = true;
        this.lblWintweak2Desc.ForeColor = System.Drawing.SystemColors.GrayText;
        this.lblWintweak2Desc.Location = new System.Drawing.Point(36, 126);
        this.lblWintweak2Desc.Name = "lblWintweak2Desc";
        this.lblWintweak2Desc.Size = new System.Drawing.Size(492, 17);
        this.lblWintweak2Desc.TabIndex = 6;
        this.lblWintweak2Desc.Text = "Official Windows tweak database, recommended for normal use.";
        // 
        // lblWintweak2Info
        // 
        this.lblWintweak2Info.AutoSize = true;
        this.lblWintweak2Info.ForeColor = System.Drawing.SystemColors.GrayText;
        this.lblWintweak2Info.Location = new System.Drawing.Point(169, 106);
        this.lblWintweak2Info.Name = "lblWintweak2Info";
        this.lblWintweak2Info.Size = new System.Drawing.Size(0, 13);
        this.lblWintweak2Info.TabIndex = 5;
        // 
        // chkBuiltInDb
        // 
        this.chkBuiltInDb.AutoSize = true;
        this.chkBuiltInDb.Location = new System.Drawing.Point(18, 104);
        this.chkBuiltInDb.Name = "chkBuiltInDb";
        this.chkBuiltInDb.Size = new System.Drawing.Size(132, 17);
        this.chkBuiltInDb.TabIndex = 4;
        this.chkBuiltInDb.Text = "Wintweak2.ini (built-in)";
        this.chkBuiltInDb.UseVisualStyleBackColor = true;
        // 
        // lblDatabases
        // 
        this.lblDatabases.AutoSize = true;
        this.lblDatabases.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
        this.lblDatabases.Location = new System.Drawing.Point(15, 70);
        this.lblDatabases.Name = "lblDatabases";
        this.lblDatabases.Size = new System.Drawing.Size(63, 13);
        this.lblDatabases.TabIndex = 3;
        this.lblDatabases.Text = "Databases";
        // 
        // BasicSettingsView
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.AutoScroll = true;
        this.AutoScrollMinSize = new System.Drawing.Size(500, 310);
        this.BackColor = System.Drawing.Color.White;
        this.Controls.Add(this.grpSettings);
        this.Name = "BasicSettingsView";
        this.Size = new System.Drawing.Size(544, 447);
        this.grpSettings.ResumeLayout(false);
        this.grpSettings.PerformLayout();
        this.ResumeLayout(false);
    }

    #endregion
}
