namespace Demo_Map
{
    partial class VectorForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapOperationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomToExtentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splcMapLegend = new System.Windows.Forms.SplitContainer();
            this.legend1 = new DotSpatial.Controls.Legend();
            this.Map1 = new DotSpatial.Controls.Map();
            this.splcDataOperation = new System.Windows.Forms.SplitContainer();
            this.gbOperations = new System.Windows.Forms.GroupBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtPopulation = new System.Windows.Forms.TextBox();
            this.lblPopulation = new System.Windows.Forms.Label();
            this.btnFilterByPopulation = new System.Windows.Forms.Button();
            this.btnViewAttributes = new System.Windows.Forms.Button();
            this.btnRandomColors = new System.Windows.Forms.Button();
            this.btnFilterByPopState = new System.Windows.Forms.Button();
            this.btnFilterByStateName = new System.Windows.Forms.Button();
            this.btnDisplayStateName = new System.Windows.Forms.Button();
            this.dgvAttributeTable = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splcMapLegend)).BeginInit();
            this.splcMapLegend.Panel1.SuspendLayout();
            this.splcMapLegend.Panel2.SuspendLayout();
            this.splcMapLegend.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splcDataOperation)).BeginInit();
            this.splcDataOperation.Panel1.SuspendLayout();
            this.splcDataOperation.Panel2.SuspendLayout();
            this.splcDataOperation.SuspendLayout();
            this.gbOperations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttributeTable)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.mapOperationToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(789, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadMapToolStripMenuItem,
            this.clearMapToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 21);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // loadMapToolStripMenuItem
            // 
            this.loadMapToolStripMenuItem.Name = "loadMapToolStripMenuItem";
            this.loadMapToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.loadMapToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.loadMapToolStripMenuItem.Text = "&Load Map";
            this.loadMapToolStripMenuItem.Click += new System.EventHandler(this.loadMapToolStripMenuItem_Click);
            // 
            // clearMapToolStripMenuItem
            // 
            this.clearMapToolStripMenuItem.Name = "clearMapToolStripMenuItem";
            this.clearMapToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.clearMapToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.clearMapToolStripMenuItem.Text = "&Clear Map";
            this.clearMapToolStripMenuItem.Click += new System.EventHandler(this.clearMapToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // mapOperationToolStripMenuItem
            // 
            this.mapOperationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomInToolStripMenuItem,
            this.zoomOutToolStripMenuItem,
            this.zoomToExtentToolStripMenuItem});
            this.mapOperationToolStripMenuItem.Name = "mapOperationToolStripMenuItem";
            this.mapOperationToolStripMenuItem.Size = new System.Drawing.Size(106, 21);
            this.mapOperationToolStripMenuItem.Text = "&MapOperation";
            // 
            // zoomInToolStripMenuItem
            // 
            this.zoomInToolStripMenuItem.Name = "zoomInToolStripMenuItem";
            this.zoomInToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Up)));
            this.zoomInToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.zoomInToolStripMenuItem.Text = "&Zoom In";
            this.zoomInToolStripMenuItem.Click += new System.EventHandler(this.zoomInToolStripMenuItem_Click);
            // 
            // zoomOutToolStripMenuItem
            // 
            this.zoomOutToolStripMenuItem.Name = "zoomOutToolStripMenuItem";
            this.zoomOutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Down)));
            this.zoomOutToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.zoomOutToolStripMenuItem.Text = "Zoom &Out";
            this.zoomOutToolStripMenuItem.Click += new System.EventHandler(this.zoomOutToolStripMenuItem_Click);
            // 
            // zoomToExtentToolStripMenuItem
            // 
            this.zoomToExtentToolStripMenuItem.Name = "zoomToExtentToolStripMenuItem";
            this.zoomToExtentToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.zoomToExtentToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.zoomToExtentToolStripMenuItem.Text = "Zoom to &Extent";
            this.zoomToExtentToolStripMenuItem.Click += new System.EventHandler(this.zoomToExtentToolStripMenuItem_Click);
            // 
            // splcMapLegend
            // 
            this.splcMapLegend.Dock = System.Windows.Forms.DockStyle.Top;
            this.splcMapLegend.Location = new System.Drawing.Point(0, 25);
            this.splcMapLegend.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splcMapLegend.Name = "splcMapLegend";
            // 
            // splcMapLegend.Panel1
            // 
            this.splcMapLegend.Panel1.Controls.Add(this.legend1);
            // 
            // splcMapLegend.Panel2
            // 
            this.splcMapLegend.Panel2.Controls.Add(this.Map1);
            this.splcMapLegend.Size = new System.Drawing.Size(789, 372);
            this.splcMapLegend.SplitterDistance = 138;
            this.splcMapLegend.SplitterWidth = 3;
            this.splcMapLegend.TabIndex = 1;
            // 
            // legend1
            // 
            this.legend1.BackColor = System.Drawing.Color.White;
            this.legend1.ControlRectangle = new System.Drawing.Rectangle(0, 0, 138, 372);
            this.legend1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.legend1.DocumentRectangle = new System.Drawing.Rectangle(0, 0, 187, 428);
            this.legend1.HorizontalScrollEnabled = true;
            this.legend1.Indentation = 30;
            this.legend1.IsInitialized = false;
            this.legend1.Location = new System.Drawing.Point(0, 0);
            this.legend1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.legend1.MinimumSize = new System.Drawing.Size(4, 4);
            this.legend1.Name = "legend1";
            this.legend1.ProgressHandler = null;
            this.legend1.ResetOnResize = false;
            this.legend1.SelectionFontColor = System.Drawing.Color.Black;
            this.legend1.SelectionHighlight = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(238)))), ((int)(((byte)(252)))));
            this.legend1.Size = new System.Drawing.Size(138, 372);
            this.legend1.TabIndex = 0;
            this.legend1.Text = "legend1";
            this.legend1.VerticalScrollEnabled = true;
            // 
            // Map1
            // 
            this.Map1.AllowDrop = true;
            this.Map1.BackColor = System.Drawing.Color.White;
            this.Map1.CollectAfterDraw = false;
            this.Map1.CollisionDetection = false;
            this.Map1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Map1.ExtendBuffer = false;
            this.Map1.FunctionMode = DotSpatial.Controls.FunctionMode.Pan;
            this.Map1.IsBusy = false;
            this.Map1.IsZoomedToMaxExtent = false;
            this.Map1.Legend = this.legend1;
            this.Map1.Location = new System.Drawing.Point(0, 0);
            this.Map1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Map1.Name = "Map1";
            this.Map1.ProgressHandler = null;
            this.Map1.ProjectionModeDefine = DotSpatial.Controls.ActionMode.Prompt;
            this.Map1.ProjectionModeReproject = DotSpatial.Controls.ActionMode.Prompt;
            this.Map1.RedrawLayersWhileResizing = false;
            this.Map1.SelectionEnabled = true;
            this.Map1.Size = new System.Drawing.Size(648, 372);
            this.Map1.TabIndex = 0;
            // 
            // splcDataOperation
            // 
            this.splcDataOperation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splcDataOperation.Location = new System.Drawing.Point(0, 397);
            this.splcDataOperation.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splcDataOperation.Name = "splcDataOperation";
            this.splcDataOperation.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splcDataOperation.Panel1
            // 
            this.splcDataOperation.Panel1.Controls.Add(this.gbOperations);
            // 
            // splcDataOperation.Panel2
            // 
            this.splcDataOperation.Panel2.Controls.Add(this.dgvAttributeTable);
            this.splcDataOperation.Size = new System.Drawing.Size(789, 279);
            this.splcDataOperation.SplitterDistance = 106;
            this.splcDataOperation.SplitterWidth = 3;
            this.splcDataOperation.TabIndex = 2;
            // 
            // gbOperations
            // 
            this.gbOperations.Controls.Add(this.lblTitle);
            this.gbOperations.Controls.Add(this.txtPopulation);
            this.gbOperations.Controls.Add(this.lblPopulation);
            this.gbOperations.Controls.Add(this.btnFilterByPopulation);
            this.gbOperations.Controls.Add(this.btnViewAttributes);
            this.gbOperations.Controls.Add(this.btnRandomColors);
            this.gbOperations.Controls.Add(this.btnFilterByPopState);
            this.gbOperations.Controls.Add(this.btnFilterByStateName);
            this.gbOperations.Controls.Add(this.btnDisplayStateName);
            this.gbOperations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbOperations.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbOperations.Location = new System.Drawing.Point(0, 0);
            this.gbOperations.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbOperations.Name = "gbOperations";
            this.gbOperations.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbOperations.Size = new System.Drawing.Size(789, 106);
            this.gbOperations.TabIndex = 0;
            this.gbOperations.TabStop = false;
            this.gbOperations.Text = "Operations";
            this.gbOperations.Enter += new System.EventHandler(this.gbOperations_Enter);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(4, 85);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(87, 15);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "Attribute Table";
            // 
            // txtPopulation
            // 
            this.txtPopulation.Location = new System.Drawing.Point(328, 57);
            this.txtPopulation.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPopulation.Name = "txtPopulation";
            this.txtPopulation.Size = new System.Drawing.Size(177, 21);
            this.txtPopulation.TabIndex = 7;
            // 
            // lblPopulation
            // 
            this.lblPopulation.AutoSize = true;
            this.lblPopulation.Location = new System.Drawing.Point(126, 60);
            this.lblPopulation.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPopulation.Name = "lblPopulation";
            this.lblPopulation.Size = new System.Drawing.Size(198, 15);
            this.lblPopulation.TabIndex = 6;
            this.lblPopulation.Text = "Enter the amount of population in 1990";
            // 
            // btnFilterByPopulation
            // 
            this.btnFilterByPopulation.Location = new System.Drawing.Point(510, 51);
            this.btnFilterByPopulation.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnFilterByPopulation.Name = "btnFilterByPopulation";
            this.btnFilterByPopulation.Size = new System.Drawing.Size(200, 32);
            this.btnFilterByPopulation.TabIndex = 5;
            this.btnFilterByPopulation.Text = "Filter by amount of &population";
            this.btnFilterByPopulation.UseVisualStyleBackColor = true;
            this.btnFilterByPopulation.Click += new System.EventHandler(this.btnFilterByPopulation_Click);
            // 
            // btnViewAttributes
            // 
            this.btnViewAttributes.Location = new System.Drawing.Point(5, 52);
            this.btnViewAttributes.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnViewAttributes.Name = "btnViewAttributes";
            this.btnViewAttributes.Size = new System.Drawing.Size(109, 31);
            this.btnViewAttributes.TabIndex = 4;
            this.btnViewAttributes.Text = "View &Attributes";
            this.btnViewAttributes.UseVisualStyleBackColor = true;
            this.btnViewAttributes.Click += new System.EventHandler(this.btnViewAttributes_Click);
            // 
            // btnRandomColors
            // 
            this.btnRandomColors.Location = new System.Drawing.Point(510, 20);
            this.btnRandomColors.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRandomColors.Name = "btnRandomColors";
            this.btnRandomColors.Size = new System.Drawing.Size(232, 28);
            this.btnRandomColors.TabIndex = 3;
            this.btnRandomColors.Text = "&Random colors based on State Name";
            this.btnRandomColors.UseVisualStyleBackColor = true;
            this.btnRandomColors.Click += new System.EventHandler(this.btnRandomColors_Click);
            // 
            // btnFilterByPopState
            // 
            this.btnFilterByPopState.Location = new System.Drawing.Point(279, 20);
            this.btnFilterByPopState.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnFilterByPopState.Name = "btnFilterByPopState";
            this.btnFilterByPopState.Size = new System.Drawing.Size(226, 28);
            this.btnFilterByPopState.TabIndex = 2;
            this.btnFilterByPopState.Text = "Filter by &Population and State Name";
            this.btnFilterByPopState.UseVisualStyleBackColor = true;
            this.btnFilterByPopState.Click += new System.EventHandler(this.btnFilterByPopState_Click);
            // 
            // btnFilterByStateName
            // 
            this.btnFilterByStateName.Location = new System.Drawing.Point(129, 20);
            this.btnFilterByStateName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnFilterByStateName.Name = "btnFilterByStateName";
            this.btnFilterByStateName.Size = new System.Drawing.Size(146, 28);
            this.btnFilterByStateName.TabIndex = 1;
            this.btnFilterByStateName.Text = "Filter by &State Name";
            this.btnFilterByStateName.UseVisualStyleBackColor = true;
            this.btnFilterByStateName.Click += new System.EventHandler(this.btnFilterByStateName_Click);
            // 
            // btnDisplayStateName
            // 
            this.btnDisplayStateName.Location = new System.Drawing.Point(5, 19);
            this.btnDisplayStateName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDisplayStateName.Name = "btnDisplayStateName";
            this.btnDisplayStateName.Size = new System.Drawing.Size(119, 29);
            this.btnDisplayStateName.TabIndex = 0;
            this.btnDisplayStateName.Text = "&Display State Name";
            this.btnDisplayStateName.UseVisualStyleBackColor = true;
            this.btnDisplayStateName.Click += new System.EventHandler(this.btnDisplayStateName_Click);
            // 
            // dgvAttributeTable
            // 
            this.dgvAttributeTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAttributeTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAttributeTable.Location = new System.Drawing.Point(0, 0);
            this.dgvAttributeTable.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvAttributeTable.Name = "dgvAttributeTable";
            this.dgvAttributeTable.RowHeadersWidth = 51;
            this.dgvAttributeTable.RowTemplate.Height = 27;
            this.dgvAttributeTable.Size = new System.Drawing.Size(789, 170);
            this.dgvAttributeTable.TabIndex = 0;
            this.dgvAttributeTable.SelectionChanged += new System.EventHandler(this.dgvAttributeTable_SelectionChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 676);
            this.Controls.Add(this.splcDataOperation);
            this.Controls.Add(this.splcMapLegend);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "VectorForm";
            this.Text = "VectorForm";
            this.Load += new System.EventHandler(this.VectorForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splcMapLegend.Panel1.ResumeLayout(false);
            this.splcMapLegend.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splcMapLegend)).EndInit();
            this.splcMapLegend.ResumeLayout(false);
            this.splcDataOperation.Panel1.ResumeLayout(false);
            this.splcDataOperation.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splcDataOperation)).EndInit();
            this.splcDataOperation.ResumeLayout(false);
            this.gbOperations.ResumeLayout(false);
            this.gbOperations.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttributeTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mapOperationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomToExtentToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splcMapLegend;
        private DotSpatial.Controls.Legend legend1;
        private DotSpatial.Controls.Map Map1;
        private System.Windows.Forms.SplitContainer splcDataOperation;
        private System.Windows.Forms.GroupBox gbOperations;
        private System.Windows.Forms.Button btnDisplayStateName;
        private System.Windows.Forms.TextBox txtPopulation;
        private System.Windows.Forms.Label lblPopulation;
        private System.Windows.Forms.Button btnFilterByPopulation;
        private System.Windows.Forms.Button btnViewAttributes;
        private System.Windows.Forms.Button btnRandomColors;
        private System.Windows.Forms.Button btnFilterByPopState;
        private System.Windows.Forms.Button btnFilterByStateName;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvAttributeTable;
    }
}