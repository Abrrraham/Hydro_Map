namespace Demo_Map
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("查看属性表");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("按字段数值筛选");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("投影管理");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("面积计算");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("矢量操作", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("山体阴影渲染");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("栅格着色");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("栅格运算");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("栅格重分类");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("拾取像元值");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("绘制路径");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("查看高程");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("徒步路径高程剖面", new System.Windows.Forms.TreeNode[] {
            treeNode11,
            treeNode12});
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("栅格操作", new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode13});
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("填洼");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("计算初始流向");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("处理平坦区");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("导出结果");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("改进D8流向", new System.Windows.Forms.TreeNode[] {
            treeNode15,
            treeNode16,
            treeNode17,
            treeNode18});
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("输入排水密度");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("输出河网中心线");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("自适应排水密度驱动的DEM河网构建", new System.Windows.Forms.TreeNode[] {
            treeNode21,
            treeNode22});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openVectorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openRasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearLayersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomToExtentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createPointShapefileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.savePointShapefileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.polylineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createPolylineShapefileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.savePolylineShapefileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.polygonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createPolygonShapefileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.savePolygonShapefileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label = new System.Windows.Forms.TabControl();
            this.tabLegend = new System.Windows.Forms.TabPage();
            this.legend1 = new DotSpatial.Controls.Legend();
            this.tabTools = new System.Windows.Forms.TabPage();
            this.splitOperations = new System.Windows.Forms.SplitContainer();
            this.gbVectorOps = new System.Windows.Forms.GroupBox();
            this.treeVectorOps = new System.Windows.Forms.TreeView();
            this.dgvAttributes = new System.Windows.Forms.DataGridView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gbCustomAttribute = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtCustomAttribute = new System.Windows.Forms.TextBox();
            this.lblLabelName = new System.Windows.Forms.Label();
            this.gbShapeAttribute = new System.Windows.Forms.GroupBox();
            this.btnDisplayLabel = new System.Windows.Forms.Button();
            this.cmbFiledName = new System.Windows.Forms.ComboBox();
            this.lblFieldName = new System.Windows.Forms.Label();
            this.gbCustom = new System.Windows.Forms.GroupBox();
            this.btnsetColor = new System.Windows.Forms.Button();
            this.btnsetFont = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.map1 = new DotSpatial.Controls.Map();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.menuStrip1.SuspendLayout();
            this.label.SuspendLayout();
            this.tabLegend.SuspendLayout();
            this.tabTools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitOperations)).BeginInit();
            this.splitOperations.Panel1.SuspendLayout();
            this.splitOperations.Panel2.SuspendLayout();
            this.splitOperations.SuspendLayout();
            this.gbVectorOps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttributes)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.gbCustomAttribute.SuspendLayout();
            this.gbShapeAttribute.SuspendLayout();
            this.gbCustom.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.mapToolStripMenuItem,
            this.editorToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1000, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openVectorToolStripMenuItem,
            this.openRasterToolStripMenuItem,
            this.clearLayersToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(48, 26);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openVectorToolStripMenuItem
            // 
            this.openVectorToolStripMenuItem.Name = "openVectorToolStripMenuItem";
            this.openVectorToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.openVectorToolStripMenuItem.Text = "Open Vector";
            this.openVectorToolStripMenuItem.Click += new System.EventHandler(this.openVectorToolStripMenuItem_Click);
            // 
            // openRasterToolStripMenuItem
            // 
            this.openRasterToolStripMenuItem.Name = "openRasterToolStripMenuItem";
            this.openRasterToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.openRasterToolStripMenuItem.Text = "Open Raster";
            this.openRasterToolStripMenuItem.Click += new System.EventHandler(this.openRasterToolStripMenuItem_Click);
            // 
            // clearLayersToolStripMenuItem
            // 
            this.clearLayersToolStripMenuItem.Name = "clearLayersToolStripMenuItem";
            this.clearLayersToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.clearLayersToolStripMenuItem.Text = "Clear Layers";
            this.clearLayersToolStripMenuItem.Click += new System.EventHandler(this.clearLayersToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // mapToolStripMenuItem
            // 
            this.mapToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomInToolStripMenuItem,
            this.zoomOutToolStripMenuItem,
            this.zoomToExtentToolStripMenuItem,
            this.panToolStripMenuItem,
            this.infoToolStripMenuItem,
            this.selectToolStripMenuItem,
            this.noneToolStripMenuItem,
            this.printMapToolStripMenuItem});
            this.mapToolStripMenuItem.Name = "mapToolStripMenuItem";
            this.mapToolStripMenuItem.Size = new System.Drawing.Size(56, 26);
            this.mapToolStripMenuItem.Text = "Map";
            // 
            // zoomInToolStripMenuItem
            // 
            this.zoomInToolStripMenuItem.Name = "zoomInToolStripMenuItem";
            this.zoomInToolStripMenuItem.Size = new System.Drawing.Size(208, 26);
            this.zoomInToolStripMenuItem.Text = "Zoom In";
            this.zoomInToolStripMenuItem.Click += new System.EventHandler(this.zoomInToolStripMenuItem_Click);
            // 
            // zoomOutToolStripMenuItem
            // 
            this.zoomOutToolStripMenuItem.Name = "zoomOutToolStripMenuItem";
            this.zoomOutToolStripMenuItem.Size = new System.Drawing.Size(208, 26);
            this.zoomOutToolStripMenuItem.Text = "Zoom Out";
            this.zoomOutToolStripMenuItem.Click += new System.EventHandler(this.zoomOutToolStripMenuItem_Click);
            // 
            // zoomToExtentToolStripMenuItem
            // 
            this.zoomToExtentToolStripMenuItem.Name = "zoomToExtentToolStripMenuItem";
            this.zoomToExtentToolStripMenuItem.Size = new System.Drawing.Size(208, 26);
            this.zoomToExtentToolStripMenuItem.Text = "Zoom To Extent";
            this.zoomToExtentToolStripMenuItem.Click += new System.EventHandler(this.zoomToExtentToolStripMenuItem_Click);
            // 
            // panToolStripMenuItem
            // 
            this.panToolStripMenuItem.Name = "panToolStripMenuItem";
            this.panToolStripMenuItem.Size = new System.Drawing.Size(208, 26);
            this.panToolStripMenuItem.Text = "Pan";
            this.panToolStripMenuItem.Click += new System.EventHandler(this.panToolStripMenuItem_Click);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(208, 26);
            this.infoToolStripMenuItem.Text = "Info";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
            // 
            // selectToolStripMenuItem
            // 
            this.selectToolStripMenuItem.Name = "selectToolStripMenuItem";
            this.selectToolStripMenuItem.Size = new System.Drawing.Size(208, 26);
            this.selectToolStripMenuItem.Text = "Select";
            this.selectToolStripMenuItem.Click += new System.EventHandler(this.selectToolStripMenuItem_Click);
            // 
            // noneToolStripMenuItem
            // 
            this.noneToolStripMenuItem.Name = "noneToolStripMenuItem";
            this.noneToolStripMenuItem.Size = new System.Drawing.Size(208, 26);
            this.noneToolStripMenuItem.Text = "None";
            this.noneToolStripMenuItem.Click += new System.EventHandler(this.noneToolStripMenuItem_Click);
            // 
            // printMapToolStripMenuItem
            // 
            this.printMapToolStripMenuItem.Name = "printMapToolStripMenuItem";
            this.printMapToolStripMenuItem.Size = new System.Drawing.Size(208, 26);
            this.printMapToolStripMenuItem.Text = "Print Map";
            this.printMapToolStripMenuItem.Click += new System.EventHandler(this.printMapToolStripMenuItem_Click);
            // 
            // editorToolStripMenuItem
            // 
            this.editorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pointToolStripMenuItem,
            this.polylineToolStripMenuItem,
            this.polygonToolStripMenuItem});
            this.editorToolStripMenuItem.Name = "editorToolStripMenuItem";
            this.editorToolStripMenuItem.Size = new System.Drawing.Size(67, 26);
            this.editorToolStripMenuItem.Text = "Editor";
            // 
            // pointToolStripMenuItem
            // 
            this.pointToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createPointShapefileToolStripMenuItem1,
            this.savePointShapefileToolStripMenuItem1});
            this.pointToolStripMenuItem.Name = "pointToolStripMenuItem";
            this.pointToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.pointToolStripMenuItem.Text = "Point";
            // 
            // createPointShapefileToolStripMenuItem1
            // 
            this.createPointShapefileToolStripMenuItem1.Name = "createPointShapefileToolStripMenuItem1";
            this.createPointShapefileToolStripMenuItem1.Size = new System.Drawing.Size(253, 26);
            this.createPointShapefileToolStripMenuItem1.Text = "Create Point Shapefile";
            this.createPointShapefileToolStripMenuItem1.Click += new System.EventHandler(this.createPointShapefileToolStripMenuItem1_Click);
            // 
            // savePointShapefileToolStripMenuItem1
            // 
            this.savePointShapefileToolStripMenuItem1.Name = "savePointShapefileToolStripMenuItem1";
            this.savePointShapefileToolStripMenuItem1.Size = new System.Drawing.Size(253, 26);
            this.savePointShapefileToolStripMenuItem1.Text = "Save Point Shapefile";
            this.savePointShapefileToolStripMenuItem1.Click += new System.EventHandler(this.savePointShapefileToolStripMenuItem1_Click);
            // 
            // polylineToolStripMenuItem
            // 
            this.polylineToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createPolylineShapefileToolStripMenuItem,
            this.savePolylineShapefileToolStripMenuItem});
            this.polylineToolStripMenuItem.Name = "polylineToolStripMenuItem";
            this.polylineToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.polylineToolStripMenuItem.Text = "Polyline";
            // 
            // createPolylineShapefileToolStripMenuItem
            // 
            this.createPolylineShapefileToolStripMenuItem.Name = "createPolylineShapefileToolStripMenuItem";
            this.createPolylineShapefileToolStripMenuItem.Size = new System.Drawing.Size(272, 26);
            this.createPolylineShapefileToolStripMenuItem.Text = "Create Polyline Shapefile";
            this.createPolylineShapefileToolStripMenuItem.Click += new System.EventHandler(this.createPolylineShapefileToolStripMenuItem_Click);
            // 
            // savePolylineShapefileToolStripMenuItem
            // 
            this.savePolylineShapefileToolStripMenuItem.Name = "savePolylineShapefileToolStripMenuItem";
            this.savePolylineShapefileToolStripMenuItem.Size = new System.Drawing.Size(272, 26);
            this.savePolylineShapefileToolStripMenuItem.Text = "Save Polyline Shapefile";
            this.savePolylineShapefileToolStripMenuItem.Click += new System.EventHandler(this.savePolylineShapefileToolStripMenuItem_Click);
            // 
            // polygonToolStripMenuItem
            // 
            this.polygonToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createPolygonShapefileToolStripMenuItem,
            this.savePolygonShapefileToolStripMenuItem});
            this.polygonToolStripMenuItem.Name = "polygonToolStripMenuItem";
            this.polygonToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.polygonToolStripMenuItem.Text = "Polygon";
            // 
            // createPolygonShapefileToolStripMenuItem
            // 
            this.createPolygonShapefileToolStripMenuItem.Name = "createPolygonShapefileToolStripMenuItem";
            this.createPolygonShapefileToolStripMenuItem.Size = new System.Drawing.Size(275, 26);
            this.createPolygonShapefileToolStripMenuItem.Text = "Create Polygon Shapefile";
            this.createPolygonShapefileToolStripMenuItem.Click += new System.EventHandler(this.createPolygonShapefileToolStripMenuItem_Click);
            // 
            // savePolygonShapefileToolStripMenuItem
            // 
            this.savePolygonShapefileToolStripMenuItem.Name = "savePolygonShapefileToolStripMenuItem";
            this.savePolygonShapefileToolStripMenuItem.Size = new System.Drawing.Size(275, 26);
            this.savePolygonShapefileToolStripMenuItem.Text = "Save Polygon Shapefile";
            this.savePolygonShapefileToolStripMenuItem.Click += new System.EventHandler(this.savePolygonShapefileToolStripMenuItem_Click);
            // 
            // label
            // 
            this.label.Controls.Add(this.tabLegend);
            this.label.Controls.Add(this.tabTools);
            this.label.Controls.Add(this.tabPage1);
            this.label.Cursor = System.Windows.Forms.Cursors.Default;
            this.label.Dock = System.Windows.Forms.DockStyle.Left;
            this.label.Location = new System.Drawing.Point(0, 30);
            this.label.Name = "label";
            this.label.SelectedIndex = 0;
            this.label.Size = new System.Drawing.Size(231, 520);
            this.label.TabIndex = 1;
            this.label.Tag = "lanel";
            // 
            // tabLegend
            // 
            this.tabLegend.Controls.Add(this.legend1);
            this.tabLegend.Location = new System.Drawing.Point(4, 25);
            this.tabLegend.Name = "tabLegend";
            this.tabLegend.Padding = new System.Windows.Forms.Padding(3);
            this.tabLegend.Size = new System.Drawing.Size(223, 491);
            this.tabLegend.TabIndex = 0;
            this.tabLegend.Text = "Legend";
            this.tabLegend.UseVisualStyleBackColor = true;
            // 
            // legend1
            // 
            this.legend1.BackColor = System.Drawing.Color.White;
            this.legend1.ControlRectangle = new System.Drawing.Rectangle(0, 0, 217, 485);
            this.legend1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.legend1.DocumentRectangle = new System.Drawing.Rectangle(0, 0, 186, 487);
            this.legend1.HorizontalScrollEnabled = true;
            this.legend1.Indentation = 30;
            this.legend1.IsInitialized = false;
            this.legend1.Location = new System.Drawing.Point(3, 3);
            this.legend1.MinimumSize = new System.Drawing.Size(5, 5);
            this.legend1.Name = "legend1";
            this.legend1.ProgressHandler = null;
            this.legend1.ResetOnResize = false;
            this.legend1.SelectionFontColor = System.Drawing.Color.Black;
            this.legend1.SelectionHighlight = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(238)))), ((int)(((byte)(252)))));
            this.legend1.Size = new System.Drawing.Size(217, 485);
            this.legend1.TabIndex = 0;
            this.legend1.Text = "legend1";
            this.legend1.VerticalScrollEnabled = true;
            // 
            // tabTools
            // 
            this.tabTools.Controls.Add(this.splitOperations);
            this.tabTools.Location = new System.Drawing.Point(4, 25);
            this.tabTools.Name = "tabTools";
            this.tabTools.Padding = new System.Windows.Forms.Padding(3);
            this.tabTools.Size = new System.Drawing.Size(223, 493);
            this.tabTools.TabIndex = 1;
            this.tabTools.Text = "Tools";
            this.tabTools.UseVisualStyleBackColor = true;
            // 
            // splitOperations
            // 
            this.splitOperations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitOperations.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitOperations.IsSplitterFixed = true;
            this.splitOperations.Location = new System.Drawing.Point(3, 3);
            this.splitOperations.Name = "splitOperations";
            this.splitOperations.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitOperations.Panel1
            // 
            this.splitOperations.Panel1.Controls.Add(this.gbVectorOps);
            this.splitOperations.Panel1MinSize = 110;
            // 
            // splitOperations.Panel2
            // 
            this.splitOperations.Panel2.Controls.Add(this.dgvAttributes);
            this.splitOperations.Size = new System.Drawing.Size(217, 487);
            this.splitOperations.SplitterDistance = 110;
            this.splitOperations.TabIndex = 0;
            // 
            // gbVectorOps
            // 
            this.gbVectorOps.Controls.Add(this.treeVectorOps);
            this.gbVectorOps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbVectorOps.Location = new System.Drawing.Point(0, 0);
            this.gbVectorOps.Name = "gbVectorOps";
            this.gbVectorOps.Size = new System.Drawing.Size(217, 110);
            this.gbVectorOps.TabIndex = 0;
            this.gbVectorOps.TabStop = false;
            this.gbVectorOps.Text = "Tools";
            // 
            // treeVectorOps
            // 
            this.treeVectorOps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeVectorOps.Location = new System.Drawing.Point(3, 21);
            this.treeVectorOps.Name = "treeVectorOps";
            treeNode1.Name = "viewAttributes";
            treeNode1.Text = "查看属性表";
            treeNode2.Name = "filterNumeric";
            treeNode2.Text = "按字段数值筛选";
            treeNode3.Name = "projectionManager";
            treeNode3.Text = "投影管理";
            treeNode4.Name = "areaCalculator";
            treeNode4.Text = "面积计算";
            treeNode5.Name = "";
            treeNode5.Text = "矢量操作";
            treeNode6.Name = "hillshade";
            treeNode6.Text = "山体阴影渲染";
            treeNode7.Name = "rasterColor";
            treeNode7.Text = "栅格着色";
            treeNode8.Name = "rasterCalc";
            treeNode8.Text = "栅格运算";
            treeNode9.Name = "reclassify";
            treeNode9.Text = "栅格重分类";
            treeNode10.Name = "pickValue";
            treeNode10.Text = "拾取像元值";
            treeNode11.Name = "drawHiking";
            treeNode11.Text = "绘制路径";
            treeNode12.Name = "viewElevation";
            treeNode12.Text = "查看高程";
            treeNode13.Name = "";
            treeNode13.Text = "徒步路径高程剖面";
            treeNode14.Name = "";
            treeNode14.Text = "栅格操作";
            treeNode15.Name = "fillPits";
            treeNode15.Text = "填洼";
            treeNode16.Name = "calcInit";
            treeNode16.Text = "计算初始流向";
            treeNode17.Name = "resolveFlats";
            treeNode17.Text = "处理平坦区";
            treeNode18.Name = "exportFlow";
            treeNode18.Text = "导出结果";
            treeNode19.Name = "";
            treeNode19.Text = "改进D8流向";
            treeNode21.Name = "dd";
            treeNode21.Text = "输入排水密度";
            treeNode22.Name = "results";
            treeNode22.Text = "输出河网中心线";
            treeNode23.Name = "";
            treeNode23.Text = "自适应排水密度驱动的DEM河网构建";
            this.treeVectorOps.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode14,
            treeNode19,
            treeNode23});
            this.treeVectorOps.Size = new System.Drawing.Size(211, 86);
            this.treeVectorOps.TabIndex = 0;
            this.treeVectorOps.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeVectorOps_AfterSelect);
            this.treeVectorOps.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeVectorOps_NodeMouseDoubleClick);
            // 
            // dgvAttributes
            // 
            this.dgvAttributes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAttributes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAttributes.Location = new System.Drawing.Point(0, 0);
            this.dgvAttributes.Name = "dgvAttributes";
            this.dgvAttributes.RowHeadersWidth = 51;
            this.dgvAttributes.RowTemplate.Height = 27;
            this.dgvAttributes.Size = new System.Drawing.Size(217, 373);
            this.dgvAttributes.TabIndex = 0;
            this.dgvAttributes.SelectionChanged += new System.EventHandler(this.dgvAttributes_SelectionChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gbCustomAttribute);
            this.tabPage1.Controls.Add(this.gbShapeAttribute);
            this.tabPage1.Controls.Add(this.gbCustom);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(223, 493);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "label";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // gbCustomAttribute
            // 
            this.gbCustomAttribute.Controls.Add(this.btnDelete);
            this.gbCustomAttribute.Controls.Add(this.btnSave);
            this.gbCustomAttribute.Controls.Add(this.btnAdd);
            this.gbCustomAttribute.Controls.Add(this.txtCustomAttribute);
            this.gbCustomAttribute.Controls.Add(this.lblLabelName);
            this.gbCustomAttribute.Location = new System.Drawing.Point(5, 300);
            this.gbCustomAttribute.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbCustomAttribute.Name = "gbCustomAttribute";
            this.gbCustomAttribute.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbCustomAttribute.Size = new System.Drawing.Size(213, 197);
            this.gbCustomAttribute.TabIndex = 2;
            this.gbCustomAttribute.TabStop = false;
            this.gbCustomAttribute.Text = "Custom Attributes for existing shape file";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(108, 108);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(67, 23);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(24, 148);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(155, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(24, 108);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(68, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtCustomAttribute
            // 
            this.txtCustomAttribute.Location = new System.Drawing.Point(27, 63);
            this.txtCustomAttribute.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCustomAttribute.Name = "txtCustomAttribute";
            this.txtCustomAttribute.Size = new System.Drawing.Size(168, 25);
            this.txtCustomAttribute.TabIndex = 2;
            this.txtCustomAttribute.TextChanged += new System.EventHandler(this.txtCustomAttribute_TextChanged);
            // 
            // lblLabelName
            // 
            this.lblLabelName.AutoSize = true;
            this.lblLabelName.Location = new System.Drawing.Point(5, 33);
            this.lblLabelName.Name = "lblLabelName";
            this.lblLabelName.Size = new System.Drawing.Size(87, 15);
            this.lblLabelName.TabIndex = 1;
            this.lblLabelName.Text = "Label name";
            // 
            // gbShapeAttribute
            // 
            this.gbShapeAttribute.Controls.Add(this.btnDisplayLabel);
            this.gbShapeAttribute.Controls.Add(this.cmbFiledName);
            this.gbShapeAttribute.Controls.Add(this.lblFieldName);
            this.gbShapeAttribute.Location = new System.Drawing.Point(3, 138);
            this.gbShapeAttribute.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbShapeAttribute.Name = "gbShapeAttribute";
            this.gbShapeAttribute.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbShapeAttribute.Size = new System.Drawing.Size(220, 157);
            this.gbShapeAttribute.TabIndex = 1;
            this.gbShapeAttribute.TabStop = false;
            this.gbShapeAttribute.Text = "Display label from Attribute table";
            // 
            // btnDisplayLabel
            // 
            this.btnDisplayLabel.Location = new System.Drawing.Point(29, 101);
            this.btnDisplayLabel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDisplayLabel.Name = "btnDisplayLabel";
            this.btnDisplayLabel.Size = new System.Drawing.Size(126, 28);
            this.btnDisplayLabel.TabIndex = 5;
            this.btnDisplayLabel.Text = "Display Labels";
            this.btnDisplayLabel.UseVisualStyleBackColor = true;
            this.btnDisplayLabel.Click += new System.EventHandler(this.btnDisplayLabel_Click);
            // 
            // cmbFiledName
            // 
            this.cmbFiledName.FormattingEnabled = true;
            this.cmbFiledName.Location = new System.Drawing.Point(89, 55);
            this.cmbFiledName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbFiledName.Name = "cmbFiledName";
            this.cmbFiledName.Size = new System.Drawing.Size(108, 23);
            this.cmbFiledName.TabIndex = 4;
            this.cmbFiledName.SelectedIndexChanged += new System.EventHandler(this.cmbFiledName_SelectedIndexChanged);
            // 
            // lblFieldName
            // 
            this.lblFieldName.AutoSize = true;
            this.lblFieldName.Location = new System.Drawing.Point(14, 55);
            this.lblFieldName.Name = "lblFieldName";
            this.lblFieldName.Size = new System.Drawing.Size(55, 15);
            this.lblFieldName.TabIndex = 3;
            this.lblFieldName.Text = "Fields";
            // 
            // gbCustom
            // 
            this.gbCustom.Controls.Add(this.btnsetColor);
            this.gbCustom.Controls.Add(this.btnsetFont);
            this.gbCustom.Controls.Add(this.groupBox2);
            this.gbCustom.Location = new System.Drawing.Point(3, 5);
            this.gbCustom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbCustom.Name = "gbCustom";
            this.gbCustom.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbCustom.Size = new System.Drawing.Size(220, 128);
            this.gbCustom.TabIndex = 0;
            this.gbCustom.TabStop = false;
            this.gbCustom.Text = "Set the label properties";
            // 
            // btnsetColor
            // 
            this.btnsetColor.Location = new System.Drawing.Point(29, 82);
            this.btnsetColor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnsetColor.Name = "btnsetColor";
            this.btnsetColor.Size = new System.Drawing.Size(140, 28);
            this.btnsetColor.TabIndex = 2;
            this.btnsetColor.Text = "Set Color";
            this.btnsetColor.UseVisualStyleBackColor = true;
            this.btnsetColor.Click += new System.EventHandler(this.btnsetColor_Click);
            // 
            // btnsetFont
            // 
            this.btnsetFont.Location = new System.Drawing.Point(29, 41);
            this.btnsetFont.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnsetFont.Name = "btnsetFont";
            this.btnsetFont.Size = new System.Drawing.Size(140, 28);
            this.btnsetFont.TabIndex = 1;
            this.btnsetFont.Text = "Set Font Style and Size";
            this.btnsetFont.UseVisualStyleBackColor = true;
            this.btnsetFont.Click += new System.EventHandler(this.btnsetFont_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(-3, 133);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(224, 134);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // map1
            // 
            this.map1.AllowDrop = true;
            this.map1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.map1.CollectAfterDraw = false;
            this.map1.CollisionDetection = false;
            this.map1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.map1.ExtendBuffer = false;
            this.map1.FunctionMode = DotSpatial.Controls.FunctionMode.None;
            this.map1.IsBusy = false;
            this.map1.IsZoomedToMaxExtent = false;
            this.map1.Legend = this.legend1;
            this.map1.Location = new System.Drawing.Point(231, 30);
            this.map1.Name = "map1";
            this.map1.ProgressHandler = null;
            this.map1.ProjectionModeDefine = DotSpatial.Controls.ActionMode.Prompt;
            this.map1.ProjectionModeReproject = DotSpatial.Controls.ActionMode.Prompt;
            this.map1.RedrawLayersWhileResizing = false;
            this.map1.SelectionEnabled = true;
            this.map1.Size = new System.Drawing.Size(769, 520);
            this.map1.TabIndex = 2;
            this.map1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.map1_MouseDown);
            this.map1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.map1_MouseUp);
            // 
            // fontDialog1
            // 
            this.fontDialog1.Apply += new System.EventHandler(this.fontDialog1_Apply);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 550);
            this.Controls.Add(this.map1);
            this.Controls.Add(this.label);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Hydro Map";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.label.ResumeLayout(false);
            this.tabLegend.ResumeLayout(false);
            this.tabTools.ResumeLayout(false);
            this.splitOperations.Panel1.ResumeLayout(false);
            this.splitOperations.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitOperations)).EndInit();
            this.splitOperations.ResumeLayout(false);
            this.gbVectorOps.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttributes)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.gbCustomAttribute.ResumeLayout(false);
            this.gbCustomAttribute.PerformLayout();
            this.gbShapeAttribute.ResumeLayout(false);
            this.gbShapeAttribute.PerformLayout();
            this.gbCustom.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openVectorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openRasterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearLayersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomToExtentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem panToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pointToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createPointShapefileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem savePointShapefileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem polylineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createPolylineShapefileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem savePolylineShapefileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem polygonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createPolygonShapefileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem savePolygonShapefileToolStripMenuItem;
        private System.Windows.Forms.TabControl label;
        private System.Windows.Forms.TabPage tabLegend;
        private DotSpatial.Controls.Legend legend1;
        private System.Windows.Forms.TabPage tabTools;
        private DotSpatial.Controls.Map map1;
        private System.Windows.Forms.SplitContainer splitOperations;
        private System.Windows.Forms.GroupBox gbVectorOps;
        private System.Windows.Forms.TreeView treeVectorOps;
        private System.Windows.Forms.DataGridView dgvAttributes;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox gbCustom;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox gbShapeAttribute;
        private System.Windows.Forms.GroupBox gbCustomAttribute;
        private System.Windows.Forms.Button btnsetColor;
        private System.Windows.Forms.Button btnsetFont;
        private System.Windows.Forms.Button btnDisplayLabel;
        private System.Windows.Forms.ComboBox cmbFiledName;
        private System.Windows.Forms.Label lblFieldName;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtCustomAttribute;
        private System.Windows.Forms.Label lblLabelName;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}