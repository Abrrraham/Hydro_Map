namespace Demo_Map
{
    partial class RasterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RasterForm));
            this.pnlLegend = new System.Windows.Forms.Panel();
            this.pnlOperations = new System.Windows.Forms.Panel();
            this.pnlMap = new System.Windows.Forms.Panel();
            this.btnLoadRaster = new System.Windows.Forms.Button();
            this.btnHillshade = new System.Windows.Forms.Button();
            this.btnMultiplyRaster = new System.Windows.Forms.Button();
            this.btnChangeColor = new System.Windows.Forms.Button();
            this.btnReclassify = new System.Windows.Forms.Button();
            this.lblElevation = new System.Windows.Forms.Label();
            this.lblRasterValue = new System.Windows.Forms.Label();
            this.chbRasterValue = new System.Windows.Forms.CheckBox();
            this.txtElevation = new System.Windows.Forms.TextBox();
            this.legend1 = new DotSpatial.Controls.Legend();
            this.legend2 = new DotSpatial.Controls.Legend();
            this.map1 = new DotSpatial.Controls.Map();
            this.appManager1 = new DotSpatial.Controls.AppManager();
            this.pnlLegend.SuspendLayout();
            this.pnlOperations.SuspendLayout();
            this.pnlMap.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLegend
            // 
            this.pnlLegend.Controls.Add(this.legend2);
            this.pnlLegend.Controls.Add(this.legend1);
            this.pnlLegend.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLegend.Location = new System.Drawing.Point(0, 0);
            this.pnlLegend.Name = "pnlLegend";
            this.pnlLegend.Size = new System.Drawing.Size(200, 450);
            this.pnlLegend.TabIndex = 0;
            // 
            // pnlOperations
            // 
            this.pnlOperations.Controls.Add(this.txtElevation);
            this.pnlOperations.Controls.Add(this.chbRasterValue);
            this.pnlOperations.Controls.Add(this.lblRasterValue);
            this.pnlOperations.Controls.Add(this.btnReclassify);
            this.pnlOperations.Controls.Add(this.lblElevation);
            this.pnlOperations.Controls.Add(this.btnChangeColor);
            this.pnlOperations.Controls.Add(this.btnHillshade);
            this.pnlOperations.Controls.Add(this.btnMultiplyRaster);
            this.pnlOperations.Controls.Add(this.btnLoadRaster);
            this.pnlOperations.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlOperations.Location = new System.Drawing.Point(200, 0);
            this.pnlOperations.Name = "pnlOperations";
            this.pnlOperations.Size = new System.Drawing.Size(841, 100);
            this.pnlOperations.TabIndex = 1;
            // 
            // pnlMap
            // 
            this.pnlMap.Controls.Add(this.map1);
            this.pnlMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMap.Location = new System.Drawing.Point(200, 100);
            this.pnlMap.Name = "pnlMap";
            this.pnlMap.Size = new System.Drawing.Size(841, 350);
            this.pnlMap.TabIndex = 2;
            // 
            // btnLoadRaster
            // 
            this.btnLoadRaster.Location = new System.Drawing.Point(6, 24);
            this.btnLoadRaster.Name = "btnLoadRaster";
            this.btnLoadRaster.Size = new System.Drawing.Size(135, 30);
            this.btnLoadRaster.TabIndex = 0;
            this.btnLoadRaster.Text = "&Load Raster";
            this.btnLoadRaster.UseVisualStyleBackColor = true;
            this.btnLoadRaster.Click += new System.EventHandler(this.btnLoadRaster_Click);
            // 
            // btnHillshade
            // 
            this.btnHillshade.Location = new System.Drawing.Point(147, 24);
            this.btnHillshade.Name = "btnHillshade";
            this.btnHillshade.Size = new System.Drawing.Size(128, 29);
            this.btnHillshade.TabIndex = 1;
            this.btnHillshade.Text = "&Hillshade";
            this.btnHillshade.UseVisualStyleBackColor = true;
            this.btnHillshade.Click += new System.EventHandler(this.btnHillshade_Click);
            // 
            // btnMultiplyRaster
            // 
            this.btnMultiplyRaster.Location = new System.Drawing.Point(427, 25);
            this.btnMultiplyRaster.Name = "btnMultiplyRaster";
            this.btnMultiplyRaster.Size = new System.Drawing.Size(164, 29);
            this.btnMultiplyRaster.TabIndex = 2;
            this.btnMultiplyRaster.Text = "&Multiply Raster";
            this.btnMultiplyRaster.UseVisualStyleBackColor = true;
            this.btnMultiplyRaster.Click += new System.EventHandler(this.btnMultiplyRaster_Click);
            // 
            // btnChangeColor
            // 
            this.btnChangeColor.Location = new System.Drawing.Point(281, 24);
            this.btnChangeColor.Name = "btnChangeColor";
            this.btnChangeColor.Size = new System.Drawing.Size(138, 27);
            this.btnChangeColor.TabIndex = 3;
            this.btnChangeColor.Text = "Change &Color";
            this.btnChangeColor.UseVisualStyleBackColor = true;
            this.btnChangeColor.Click += new System.EventHandler(this.btnChangeColor_Click);
            // 
            // btnReclassify
            // 
            this.btnReclassify.Location = new System.Drawing.Point(296, 65);
            this.btnReclassify.Name = "btnReclassify";
            this.btnReclassify.Size = new System.Drawing.Size(195, 29);
            this.btnReclassify.TabIndex = 4;
            this.btnReclassify.Text = "&Reclassify Raster";
            this.btnReclassify.UseVisualStyleBackColor = true;
            this.btnReclassify.Click += new System.EventHandler(this.btnReclassify_Click);
            // 
            // lblElevation
            // 
            this.lblElevation.AutoSize = true;
            this.lblElevation.Location = new System.Drawing.Point(28, 70);
            this.lblElevation.Name = "lblElevation";
            this.lblElevation.Size = new System.Drawing.Size(98, 18);
            this.lblElevation.TabIndex = 0;
            this.lblElevation.Text = "Elevation:";
            this.lblElevation.Click += new System.EventHandler(this.lblElevation_Click);
            // 
            // lblRasterValue
            // 
            this.lblRasterValue.AutoSize = true;
            this.lblRasterValue.Location = new System.Drawing.Point(609, 28);
            this.lblRasterValue.Name = "lblRasterValue";
            this.lblRasterValue.Size = new System.Drawing.Size(179, 18);
            this.lblRasterValue.TabIndex = 1;
            this.lblRasterValue.Text = "Row: Column: Value:";
            // 
            // chbRasterValue
            // 
            this.chbRasterValue.AutoSize = true;
            this.chbRasterValue.Location = new System.Drawing.Point(521, 65);
            this.chbRasterValue.Name = "chbRasterValue";
            this.chbRasterValue.Size = new System.Drawing.Size(295, 22);
            this.chbRasterValue.TabIndex = 0;
            this.chbRasterValue.Text = "Raster value at clicked point";
            this.chbRasterValue.UseVisualStyleBackColor = true;
            this.chbRasterValue.CheckedChanged += new System.EventHandler(this.chbRasterValue_CheckedChanged);
            // 
            // txtElevation
            // 
            this.txtElevation.Location = new System.Drawing.Point(132, 66);
            this.txtElevation.Name = "txtElevation";
            this.txtElevation.Size = new System.Drawing.Size(100, 28);
            this.txtElevation.TabIndex = 5;
            this.txtElevation.Text = "3000";
            // 
            // legend1
            // 
            this.legend1.BackColor = System.Drawing.Color.White;
            this.legend1.ControlRectangle = new System.Drawing.Rectangle(0, 0, 187, 428);
            this.legend1.DocumentRectangle = new System.Drawing.Rectangle(0, 0, 187, 428);
            this.legend1.HorizontalScrollEnabled = true;
            this.legend1.Indentation = 30;
            this.legend1.IsInitialized = false;
            this.legend1.Location = new System.Drawing.Point(0, 0);
            this.legend1.MinimumSize = new System.Drawing.Size(5, 5);
            this.legend1.Name = "legend1";
            this.legend1.ProgressHandler = null;
            this.legend1.ResetOnResize = false;
            this.legend1.SelectionFontColor = System.Drawing.Color.Black;
            this.legend1.SelectionHighlight = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(238)))), ((int)(((byte)(252)))));
            this.legend1.Size = new System.Drawing.Size(187, 428);
            this.legend1.TabIndex = 0;
            this.legend1.Text = "legend1";
            this.legend1.VerticalScrollEnabled = true;
            // 
            // legend2
            // 
            this.legend2.BackColor = System.Drawing.Color.White;
            this.legend2.ControlRectangle = new System.Drawing.Rectangle(0, 0, 200, 450);
            this.legend2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.legend2.DocumentRectangle = new System.Drawing.Rectangle(0, 0, 187, 428);
            this.legend2.HorizontalScrollEnabled = true;
            this.legend2.Indentation = 30;
            this.legend2.IsInitialized = false;
            this.legend2.Location = new System.Drawing.Point(0, 0);
            this.legend2.MinimumSize = new System.Drawing.Size(5, 5);
            this.legend2.Name = "legend2";
            this.legend2.ProgressHandler = null;
            this.legend2.ResetOnResize = false;
            this.legend2.SelectionFontColor = System.Drawing.Color.Black;
            this.legend2.SelectionHighlight = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(238)))), ((int)(((byte)(252)))));
            this.legend2.Size = new System.Drawing.Size(200, 450);
            this.legend2.TabIndex = 1;
            this.legend2.Text = "legend2";
            this.legend2.VerticalScrollEnabled = true;
            // 
            // map1
            // 
            this.map1.AllowDrop = true;
            this.map1.BackColor = System.Drawing.Color.White;
            this.map1.CollectAfterDraw = false;
            this.map1.CollisionDetection = false;
            this.map1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.map1.ExtendBuffer = false;
            this.map1.FunctionMode = DotSpatial.Controls.FunctionMode.None;
            this.map1.IsBusy = false;
            this.map1.IsZoomedToMaxExtent = false;
            this.map1.Legend = this.legend2;
            this.map1.Location = new System.Drawing.Point(0, 0);
            this.map1.Name = "map1";
            this.map1.ProgressHandler = null;
            this.map1.ProjectionModeDefine = DotSpatial.Controls.ActionMode.Prompt;
            this.map1.ProjectionModeReproject = DotSpatial.Controls.ActionMode.Prompt;
            this.map1.RedrawLayersWhileResizing = false;
            this.map1.SelectionEnabled = true;
            this.map1.Size = new System.Drawing.Size(841, 350);
            this.map1.TabIndex = 0;
            this.map1.Load += new System.EventHandler(this.map1_Load);
            this.map1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Map1_MouseUp);
            // 
            // appManager1
            // 
            this.appManager1.Directories = ((System.Collections.Generic.List<string>)(resources.GetObject("appManager1.Directories")));
            this.appManager1.DockManager = null;
            this.appManager1.HeaderControl = null;
            this.appManager1.Legend = this.legend2;
            this.appManager1.Map = this.map1;
            this.appManager1.ProgressHandler = null;
            this.appManager1.ShowExtensionsDialogMode = DotSpatial.Controls.ShowExtensionsDialogMode.Default;
            // 
            // RasterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 450);
            this.Controls.Add(this.pnlMap);
            this.Controls.Add(this.pnlOperations);
            this.Controls.Add(this.pnlLegend);
            this.Name = "RasterForm";
            this.Text = "RasterForm";
            this.pnlLegend.ResumeLayout(false);
            this.pnlOperations.ResumeLayout(false);
            this.pnlOperations.PerformLayout();
            this.pnlMap.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLegend;
        private System.Windows.Forms.Panel pnlOperations;
        private System.Windows.Forms.Panel pnlMap;
        private System.Windows.Forms.Button btnReclassify;
        private System.Windows.Forms.Button btnChangeColor;
        private System.Windows.Forms.Button btnMultiplyRaster;
        private System.Windows.Forms.Button btnHillshade;
        private System.Windows.Forms.Button btnLoadRaster;
        private System.Windows.Forms.Label lblRasterValue;
        private System.Windows.Forms.Label lblElevation;
        private System.Windows.Forms.CheckBox chbRasterValue;
        private System.Windows.Forms.TextBox txtElevation;
        private DotSpatial.Controls.Legend legend1;
        private DotSpatial.Controls.Legend legend2;
        private DotSpatial.Controls.Map map1;
        private DotSpatial.Controls.AppManager appManager1;
    }
}