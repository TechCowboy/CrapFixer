namespace CrapFixer.Views.Tools;

partial class CustomTweaksView
{
    private System.ComponentModel.IContainer components = null;
    private Label lblHint;
    private ListView lvCustom;
    private ColumnHeader colName;
    private ColumnHeader colStatus;
    private Button btnNew;
    private Button btnDelete;
    private Panel pnlBottom;
    private ContextMenuStrip cmCustom;
    private ToolStripMenuItem miEdit;
    private ToolStripSeparator sepCustom;
    private ToolStripMenuItem miDelete;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    #region Component Designer generated code

    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            this.lblHint = new System.Windows.Forms.Label();
            this.lvCustom = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmCustom = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.sepCustom = new System.Windows.Forms.ToolStripSeparator();
            this.miDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.cmCustom.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHint
            // 
            this.lblHint.AutoEllipsis = true;
            this.lblHint.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHint.Location = new System.Drawing.Point(4, 4);
            this.lblHint.Name = "lblHint";
            this.lblHint.Padding = new System.Windows.Forms.Padding(2, 5, 0, 0);
            this.lblHint.Size = new System.Drawing.Size(536, 30);
            this.lblHint.TabIndex = 0;
            this.lblHint.Text = "Check a custom tweak to show it on the Fixer page. Double-click to edit.";
            // 
            // lvCustom
            // 
            this.lvCustom.CheckBoxes = true;
            this.lvCustom.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colStatus});
            this.lvCustom.ContextMenuStrip = this.cmCustom;
            this.lvCustom.FullRowSelect = true;
            this.lvCustom.HideSelection = false;
            this.lvCustom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvCustom.Location = new System.Drawing.Point(4, 34);
            this.lvCustom.Name = "lvCustom";
            this.lvCustom.Size = new System.Drawing.Size(536, 365);
            this.lvCustom.TabIndex = 1;
            this.lvCustom.UseCompatibleStateImageBehavior = false;
            this.lvCustom.View = System.Windows.Forms.View.Details;
            this.lvCustom.ItemActivate += new System.EventHandler(this.LvCustom_ItemActivate);
            this.lvCustom.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.LvCustom_ItemCheck);
            this.lvCustom.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LvCustom_MouseDown);
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 360;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            this.colStatus.Width = 130;
            // 
            // cmCustom
            // 
            this.cmCustom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miEdit,
            this.sepCustom,
            this.miDelete});
            this.cmCustom.Name = "cmCustom";
            this.cmCustom.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.cmCustom.Size = new System.Drawing.Size(108, 54);
            this.cmCustom.Opening += new System.ComponentModel.CancelEventHandler(this.CmCustom_Opening);
            // 
            // miEdit
            // 
            this.miEdit.Name = "miEdit";
            this.miEdit.Size = new System.Drawing.Size(107, 22);
            this.miEdit.Text = "Edit...";
            this.miEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // sepCustom
            // 
            this.sepCustom.Name = "sepCustom";
            this.sepCustom.Size = new System.Drawing.Size(104, 6);
            // 
            // miDelete
            // 
            this.miDelete.Name = "miDelete";
            this.miDelete.Size = new System.Drawing.Size(107, 22);
            this.miDelete.Text = "Delete";
            this.miDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.Location = new System.Drawing.Point(374, 8);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 2;
            this.btnNew.Text = "New...";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(455, 8);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // pnlBottom
            //
            this.pnlBottom.Controls.Add(this.btnDelete);
            this.pnlBottom.Controls.Add(this.btnNew);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(4, 399);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(536, 40);
            this.pnlBottom.TabIndex = 2;
            //
            // CustomTweaksView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lvCustom);
            this.Controls.Add(this.lblHint);
            this.Controls.Add(this.pnlBottom);
            this.Name = "CustomTweaksView";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Size = new System.Drawing.Size(544, 443);
            this.cmCustom.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    #endregion
}
