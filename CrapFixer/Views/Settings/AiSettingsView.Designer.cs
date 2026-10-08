namespace CrapFixer.Views.Settings;

partial class AiSettingsView
{
    private System.ComponentModel.IContainer components = null;
    private GroupBox grpAi;
    private Label lblDescription;
    private Label lblProvider;
    private ComboBox cboProvider;
    private Label lblApiKey;
    private TextBox txtApiKey;
    private Button btnTest;
    private LinkLabel lnkGetKey;
    private Label lblTestResult;
    private Label lblEndpoint;
    private TextBox txtEndpoint;
    private Label lblModel;
    private TextBox txtModel;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    #region Component Designer generated code

    private void InitializeComponent()
    {
        this.grpAi = new System.Windows.Forms.GroupBox();
        this.txtModel = new System.Windows.Forms.TextBox();
        this.lblModel = new System.Windows.Forms.Label();
        this.txtEndpoint = new System.Windows.Forms.TextBox();
        this.lblEndpoint = new System.Windows.Forms.Label();
        this.lblTestResult = new System.Windows.Forms.Label();
        this.lnkGetKey = new System.Windows.Forms.LinkLabel();
        this.btnTest = new System.Windows.Forms.Button();
        this.txtApiKey = new System.Windows.Forms.TextBox();
        this.lblApiKey = new System.Windows.Forms.Label();
        this.cboProvider = new System.Windows.Forms.ComboBox();
        this.lblProvider = new System.Windows.Forms.Label();
        this.lblDescription = new System.Windows.Forms.Label();
        this.grpAi.SuspendLayout();
        this.SuspendLayout();
        // 
        // grpAi
        // 
        this.grpAi.Controls.Add(this.txtModel);
        this.grpAi.Controls.Add(this.lblModel);
        this.grpAi.Controls.Add(this.txtEndpoint);
        this.grpAi.Controls.Add(this.lblEndpoint);
        this.grpAi.Controls.Add(this.lblTestResult);
        this.grpAi.Controls.Add(this.lnkGetKey);
        this.grpAi.Controls.Add(this.btnTest);
        this.grpAi.Controls.Add(this.txtApiKey);
        this.grpAi.Controls.Add(this.lblApiKey);
        this.grpAi.Controls.Add(this.cboProvider);
        this.grpAi.Controls.Add(this.lblProvider);
        this.grpAi.Controls.Add(this.lblDescription);
        this.grpAi.Dock = System.Windows.Forms.DockStyle.Fill;
        this.grpAi.Location = new System.Drawing.Point(0, 0);
        this.grpAi.Name = "grpAi";
        this.grpAi.Size = new System.Drawing.Size(544, 447);
        this.grpAi.TabIndex = 0;
        this.grpAi.TabStop = false;
        // 
        // txtModel
        // 
        this.txtModel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.txtModel.Font = new System.Drawing.Font("Consolas", 8.25F);
        this.txtModel.Location = new System.Drawing.Point(389, 100);
        this.txtModel.Name = "txtModel";
        this.txtModel.Size = new System.Drawing.Size(139, 20);
        this.txtModel.TabIndex = 5;
        this.txtModel.Visible = false;
        // 
        // lblModel
        // 
        this.lblModel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.lblModel.AutoSize = true;
        this.lblModel.Location = new System.Drawing.Point(386, 84);
        this.lblModel.Name = "lblModel";
        this.lblModel.Size = new System.Drawing.Size(36, 13);
        this.lblModel.TabIndex = 4;
        this.lblModel.Text = "Model";
        this.lblModel.Visible = false;
        // 
        // txtEndpoint
        // 
        this.txtEndpoint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
        this.txtEndpoint.Font = new System.Drawing.Font("Consolas", 8.25F);
        this.txtEndpoint.Location = new System.Drawing.Point(183, 100);
        this.txtEndpoint.Name = "txtEndpoint";
        this.txtEndpoint.Size = new System.Drawing.Size(194, 20);
        this.txtEndpoint.TabIndex = 3;
        this.txtEndpoint.Visible = false;
        // 
        // lblEndpoint
        // 
        this.lblEndpoint.AutoSize = true;
        this.lblEndpoint.Location = new System.Drawing.Point(180, 84);
        this.lblEndpoint.Name = "lblEndpoint";
        this.lblEndpoint.Size = new System.Drawing.Size(49, 13);
        this.lblEndpoint.TabIndex = 2;
        this.lblEndpoint.Text = "Endpoint";
        this.lblEndpoint.Visible = false;
        // 
        // lblTestResult
        // 
        this.lblTestResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
        this.lblTestResult.AutoEllipsis = true;
        this.lblTestResult.Location = new System.Drawing.Point(15, 211);
        this.lblTestResult.Name = "lblTestResult";
        this.lblTestResult.Size = new System.Drawing.Size(513, 100);
        this.lblTestResult.TabIndex = 10;
        // 
        // lnkGetKey
        // 
        this.lnkGetKey.AutoEllipsis = true;
        this.lnkGetKey.Location = new System.Drawing.Point(15, 177);
        this.lnkGetKey.Name = "lnkGetKey";
        this.lnkGetKey.Size = new System.Drawing.Size(250, 16);
        this.lnkGetKey.TabIndex = 9;
        this.lnkGetKey.TabStop = true;
        this.lnkGetKey.Text = "Get a free key (console.groq.com)";
        this.lnkGetKey.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkGetKey_LinkClicked);
        // 
        // btnTest
        // 
        this.btnTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.btnTest.Location = new System.Drawing.Point(453, 147);
        this.btnTest.Name = "btnTest";
        this.btnTest.Size = new System.Drawing.Size(75, 23);
        this.btnTest.TabIndex = 8;
        this.btnTest.Text = "Test";
        this.btnTest.UseVisualStyleBackColor = true;
        this.btnTest.Click += new System.EventHandler(this.BtnTest_Click);
        // 
        // txtApiKey
        // 
        this.txtApiKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
        this.txtApiKey.Font = new System.Drawing.Font("Consolas", 8.25F);
        this.txtApiKey.Location = new System.Drawing.Point(15, 149);
        this.txtApiKey.Name = "txtApiKey";
        this.txtApiKey.PasswordChar = '●';
        this.txtApiKey.Size = new System.Drawing.Size(432, 20);
        this.txtApiKey.TabIndex = 7;
        // 
        // lblApiKey
        // 
        this.lblApiKey.AutoSize = true;
        this.lblApiKey.Location = new System.Drawing.Point(15, 133);
        this.lblApiKey.Name = "lblApiKey";
        this.lblApiKey.Size = new System.Drawing.Size(70, 13);
        this.lblApiKey.TabIndex = 6;
        this.lblApiKey.Text = "Groq API key";
        // 
        // cboProvider
        // 
        this.cboProvider.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cboProvider.FormattingEnabled = true;
        this.cboProvider.Items.AddRange(new object[] { "Groq", "OpenAI", "Anthropic", "OpenAI-compatible" });
        this.cboProvider.Location = new System.Drawing.Point(15, 100);
        this.cboProvider.Name = "cboProvider";
        this.cboProvider.Size = new System.Drawing.Size(150, 21);
        this.cboProvider.TabIndex = 1;
        this.cboProvider.SelectedIndexChanged += new System.EventHandler(this.CboProvider_SelectedIndexChanged);
        // 
        // lblProvider
        // 
        this.lblProvider.AutoSize = true;
        this.lblProvider.Location = new System.Drawing.Point(15, 84);
        this.lblProvider.Name = "lblProvider";
        this.lblProvider.Size = new System.Drawing.Size(58, 13);
        this.lblProvider.TabIndex = 0;
        this.lblProvider.Text = "AI provider";
        // 
        // lblDescription
        // 
        this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
        this.lblDescription.AutoEllipsis = true;
        this.lblDescription.Location = new System.Drawing.Point(12, 24);
        this.lblDescription.Name = "lblDescription";
        this.lblDescription.Size = new System.Drawing.Size(516, 52);
        this.lblDescription.TabIndex = 0;
        this.lblDescription.Text = "Right-click a tweak and choose Explain with AI. Your key is used only when you ask.";
        // 
        // AiSettingsView
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.AutoScroll = true;
        this.AutoScrollMinSize = new System.Drawing.Size(500, 310);
        this.BackColor = System.Drawing.Color.White;
        this.Controls.Add(this.grpAi);
        this.Name = "AiSettingsView";
        this.Size = new System.Drawing.Size(544, 447);
        this.grpAi.ResumeLayout(false);
        this.grpAi.PerformLayout();
        this.ResumeLayout(false);
    }

    #endregion
}
