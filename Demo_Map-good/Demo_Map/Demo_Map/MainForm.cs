using System;
using System.Drawing;
using System.Windows.Forms;
using DotSpatial.Controls;
using DotSpatial.Data;
using DotSpatial.Symbology;
using DotSpatial.Data.Rasters.GdalExtension;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using Microsoft.VisualBasic;
using DotSpatial.Topology;
using OSGeo.GDAL;
using DotSpatial.Projections;
using System.Linq;
using Microsoft.Office.Interop.Excel;
using System.IO;

namespace Demo_Map
{
    public partial class MainForm : Form
    {
        private IRaster _demRaster;
        private int[,] _flowDir;
        private bool _pickValueMode = false;

        // --- Editor variables for drawing shapefiles ---
        private string _shapeType = string.Empty;

        private FeatureSet _pointF = new FeatureSet(FeatureType.Point);
        private int _pointID = 0;
        private bool _pointDrawing = false;

        private MapLineLayer _lineLayer = null;
        private FeatureSet _lineF = new FeatureSet(FeatureType.Line);
        private int _lineID = 0;
        private bool _firstClick = false;
        private bool _lineDrawing = false;

        private FeatureSet _polygonF = new FeatureSet(FeatureType.Polygon);
        private int _polygonID = 0;
        private bool _polygonDrawing = false;

        // --- Hiking path variables ---
        private FeatureSet _hikingPathF = new FeatureSet(FeatureType.Line);
        private MapLineLayer _hikingLayer = null;
        private bool _hikingFirstClick = false;
        private bool _hikingDrawing = false;

        // 保存初始投影信息
        private readonly Dictionary<IMapLayer, ProjectionInfo> _layerOriginalProjections = new Dictionary<IMapLayer, ProjectionInfo>();
        private ProjectionInfo _mapOriginalProjection;

        public MainForm()
        {
            InitializeComponent();
            SetupOperationsTree();
        }

        private void openVectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //map1.AddLayer();
            // 清除现有图层和 combobox 内容
            if (map1.Layers.Count > 0)
            {
                // 清理现有图层并释放资源
                foreach (var layer in map1.Layers)
                {
                    if (layer is IFeatureSet featureSet && featureSet != null)
                    {
                        featureSet.Dispose();
                    }
                }
                map1.Layers.Clear();
            }
            cmbFiledName.Items.Clear();

            // 打开文件对话框选择 Shapefile
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Shapefiles|*.shp";
            fileDialog.Title = "选择要加载的 Shapefile";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // 打开 Shapefile
                    IFeatureSet featureSet = FeatureSet.OpenFile(fileDialog.FileName);
                    var originalProj = featureSet.Projection;

                    // 填充属性列名到 combobox
                    if (featureSet.DataTable != null && featureSet.DataTable.Columns.Count > 0)
                    {
                        foreach (DataColumn column in featureSet.DataTable.Columns)
                        {
                            cmbFiledName.Items.Add(column.ColumnName);
                        }

                        // 如果有列，默认选择第一列
                        if (cmbFiledName.Items.Count > 0)
                        {
                            cmbFiledName.SelectedIndex = 0;
                        }
                    }
                    else
                    {
                        cmbFiledName.Items.Add("(无属性数据)");
                        cmbFiledName.SelectedIndex = 0;
                    }

                    // 投影转换（如果需要）
                    if (!featureSet.Projection.Equals(map1.Projection))
                    {
                        featureSet.Reproject(map1.Projection);
                    }

                    // 添加图层到地图
                    IMapLayer layer = map1.Layers.Add(featureSet);
                    _layerOriginalProjections[layer] = originalProj;
                    if (_mapOriginalProjection == null)
                        _mapOriginalProjection = map1.Projection;

                    // 设置图层名称
                    string layerName = Path.GetFileNameWithoutExtension(fileDialog.FileName);
                    layer.LegendText = layerName;

                    // 缩放至图层范围
                    map1.ZoomToMaxExtent();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"加载图层时出错: {ex.Message}", "错误",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // 统一的栅格加载入口，兼顾常规和水系分析所需的 DEM
        private void openRasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                GdalConfiguration.ConfigureGdal();
                GdalConfiguration.ConfigureOgr();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"GDAL init failed: {ex.Message}");
                return;
            }

            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "TIFF Files (*.tif;*.tiff)|*.tif;*.tiff|All Files (*.*)|*.*";
                dialog.Title = "选择DEM TIFF文件";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = dialog.FileName;

                    try
                    {
                        Dataset dataset = Gdal.Open(filePath, Access.GA_ReadOnly);

                        if (dataset != null)
                        {
                            IRaster raster = ConvertGdalDatasetToRaster(dataset, filePath);
                            var originalProj = raster.Projection;

                            if (raster != null)
                            {
                                // 将栅格以图层形式加入地图并记录其原始投影
                                IMapRasterLayer layer = new MapRasterLayer(raster);
                                map1.Layers.Add(layer);
                                _layerOriginalProjections[layer] = originalProj;
                                if (_mapOriginalProjection == null)
                                    _mapOriginalProjection = map1.Projection;

                                // 记录 DEM，用于后续水文分析模块
                                _demRaster = raster;
                                demRaster = raster;

                                map1.ZoomToMaxExtent();
                                MessageBox.Show("DEM 加载成功！");
                            }
                            else
                            {
                                MessageBox.Show("无法将GDAL数据集转换为DotSpatial栅格对象");
                            }

                            dataset.Dispose();
                        }
                        else
                        {
                            MessageBox.Show("GDAL无法打开指定的TIFF文件");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"加载DEM时出错: {ex.Message}");
                    }
                }
            }
        }

        private IRaster ConvertGdalDatasetToRaster(Dataset dataset, string filePath)
        {
            int width = dataset.RasterXSize;
            int height = dataset.RasterYSize;

            IRaster raster = Raster.CreateRaster(
                filePath + ".bgd", null, width, height, 1, typeof(float), new string[] { }
            );

            double[] geoTransform = new double[6];
            dataset.GetGeoTransform(geoTransform);
            double cellWidth = geoTransform[1];
            double cellHeight = geoTransform[5];
            double topLeftX = geoTransform[0];
            double topLeftY = geoTransform[3];

            double bottom = topLeftY + cellHeight * height;
            raster.Bounds = new RasterBounds(height, width, new Extent(
                topLeftX,
                bottom,
                topLeftX + cellWidth * width,
                topLeftY
            ));

            string wkt = dataset.GetProjection();
            if (!string.IsNullOrEmpty(wkt))
            {
                raster.Projection = ProjectionInfo.FromEsriString(wkt);
            }

            Band band = dataset.GetRasterBand(1);
            float[] buffer = new float[width * height];
            band.ReadRaster(0, 0, width, height, buffer, width, height, 0, 0);

            double noDataValue;
            band.GetNoDataValue(out noDataValue, out int hasNoData);
            if (hasNoData == 1)
            {
                raster.NoDataValue = noDataValue;
            }

            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    float value = buffer[row * width + col];

                    if (hasNoData == 1 && Math.Abs(value - noDataValue) < float.Epsilon)
                    {
                        raster.Value[row, col] = raster.NoDataValue;
                    }
                    else
                    {
                        raster.Value[row, col] = value;
                    }
                }
            }

            raster.Save();
            return raster;
        }

        private void clearLayersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            map1.Layers.Clear();
            legend1.RootNodes.Clear();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            map1.ZoomIn();
        }

        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            map1.ZoomOut();
        }

        private void zoomToExtentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            map1.ZoomToMaxExtent();
        }

        private void panToolStripMenuItem_Click(object sender, EventArgs e)
        {
            map1.FunctionMode = FunctionMode.Pan;
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            map1.FunctionMode = FunctionMode.Info;
        }

        private void selectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            map1.FunctionMode = FunctionMode.Select;
        }

        private void noneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            map1.FunctionMode = FunctionMode.None;
        }

        private void hillshadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (map1.Layers.Count > 0)
            {
                IMapRasterLayer layer = map1.Layers[0] as IMapRasterLayer;
                if (layer == null)
                {
                    MessageBox.Show("Please select a raster layer.");
                    return;
                }

                layer.Symbolizer.ShadedRelief.ElevationFactor = 1;
                layer.Symbolizer.ShadedRelief.IsUsed = true;
                layer.WriteBitmap();
            }
            else
            {
                MessageBox.Show("Please add a raster layer first.");
            }
        }
        
        string fname = "Tahoma";
        double fsize = 8.0;
        Color fcolor = Color.Black;

        private void btnDisplayStateName_Click(object sender, EventArgs e)
        {
            if (map1.Layers.Count == 0) { MessageBox.Show("Please add a layer first."); return; }

            MapPolygonLayer layer = map1.Layers[0] as MapPolygonLayer;
            if (layer == null)
            {
                MessageBox.Show("The layer is not a polygon layer.");
                return;
            }

            map1.AddLabels(layer, "[STATE_NAME]", new System.Drawing.Font("Tahoma", 8f), Color.Black);
        }

        private void btnFilterByStateName_Click(object sender, EventArgs e)
        {
            if (map1.Layers.Count == 0) { MessageBox.Show("Please add a layer first."); return; }

            MapPolygonLayer layer = map1.Layers[0] as MapPolygonLayer;
            if (layer == null)
            {
                MessageBox.Show("The layer is not a polygon layer.");
                return;
            }
            layer.SelectByAttribute("[STATE_NAME] = 'Texas'");
        }

        private void btnFilterByPopState_Click(object sender, EventArgs e)
        {
            if (map1.Layers.Count == 0) { MessageBox.Show("Please add a layer first."); return; }

            MapPolygonLayer layer = map1.Layers[0] as MapPolygonLayer;
            if (layer == null)
            {
                MessageBox.Show("The layer is not a polygon layer.");
                return;
            }

            layer.SelectByAttribute("[POP1990] > 10000000 OR [STATE_NAME] = 'Idaho'");
        }

        private void btnRandomColors_Click(object sender, EventArgs e)
        {
            if (map1.Layers.Count == 0) { MessageBox.Show("Please add a layer first."); return; }

            MapPolygonLayer layer = map1.Layers[0] as MapPolygonLayer;
            if (layer == null)
            {
                MessageBox.Show("The layer is not a polygon layer.");
                return;
            }

            PolygonScheme scheme = new PolygonScheme();
            scheme.EditorSettings.ClassificationType = ClassificationType.UniqueValues;
            scheme.EditorSettings.FieldName = "STATE_NAME";
            scheme.CreateCategories(layer.DataSet.DataTable);
            layer.Symbology = scheme;
        }

        private void btnViewAttributes_Click(object sender, EventArgs e)
        {
		if (map1.Layers.Count == 0)            
            {
                MessageBox.Show("Please add a layer first.");
                return;
            }

            using (var form = new AttributeTableForm(map1))
            {
                form.ShowDialog(this);
            }
        }

        private void dgvAttributes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAttributes.SelectedRows.Count == 0 || map1.Layers.Count == 0)
                return;

            MapPolygonLayer layer = map1.Layers[0] as MapPolygonLayer;
            if (layer == null)
                return;

            var row = dgvAttributes.SelectedRows[0];
            if (row.Cells["STATE_NAME"] != null)
            {
                layer.SelectByAttribute($"[STATE_NAME] = '{row.Cells["STATE_NAME"].Value}'");
            }
        }
	

        private void SetupOperationsTree()
        {
            treeVectorOps.Nodes.Clear();
            splitOperations.Panel2Collapsed = true;

            TreeNode vectorRoot = new TreeNode("矢量操作");
            vectorRoot.Nodes.Add(new TreeNode("查看属性表") { Name = "viewAttributes" });
            vectorRoot.Nodes.Add(new TreeNode("按字段数值筛选") { Name = "filterNumeric" });
            vectorRoot.Nodes.Add(new TreeNode("投影管理") { Name = "projectionManager" });
            vectorRoot.Nodes.Add(new TreeNode("面积计算") { Name = "areaCalculator" });

            TreeNode rasterRoot = new TreeNode("栅格操作");
           
            rasterRoot.Nodes.Add(new TreeNode("山体阴影渲染") { Name = "hillshade" });
            rasterRoot.Nodes.Add(new TreeNode("栅格着色") { Name = "rasterColor" });
            rasterRoot.Nodes.Add(new TreeNode("栅格运算") { Name = "rasterCalc" });
            rasterRoot.Nodes.Add(new TreeNode("栅格重分类") { Name = "reclassify" });
            rasterRoot.Nodes.Add(new TreeNode("拾取像元值") { Name = "pickValue" });
            TreeNode hiking = new TreeNode("徒步路径高程剖面");
            hiking.Nodes.Add(new TreeNode("绘制路径") { Name = "drawHiking" });
            hiking.Nodes.Add(new TreeNode("查看高程") { Name = "viewElevation" });
            rasterRoot.Nodes.Add(hiking);

            TreeNode newRoot = new TreeNode("水系专题功能");
            TreeNode d8 = new TreeNode("改进D8流向");
            d8.Nodes.Add(new TreeNode("填洼") { Name = "fillPits" });
            d8.Nodes.Add(new TreeNode("计算初始流向") { Name = "calcInit" });
            d8.Nodes.Add(new TreeNode("处理平坦区") { Name = "resolveFlats" });
            d8.Nodes.Add(new TreeNode("导出结果") { Name = "exportFlow" });
            // 水系专题工具节点 (DEM 数据通过 File 菜单加载)
            TreeNode hw = new TreeNode("自适应排水密度驱动的DEM河网构建");
            // 加载 Drainage Density 栅格
            hw.Nodes.Add(new TreeNode("输入排水密度") { Name = "dd" });
            // 生成河网结果
            hw.Nodes.Add(new TreeNode("输出河网中心线") { Name = "results" });
            newRoot.Nodes.Add(d8);
            newRoot.Nodes.Add(hw);
            
           

            treeVectorOps.Nodes.Add(vectorRoot);
            treeVectorOps.Nodes.Add(rasterRoot);
            treeVectorOps.Nodes.Add(newRoot);
            vectorRoot.Expand();
            rasterRoot.Expand();

        }

        private void treeVectorOps_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node == null) return;
            switch (e.Node.Name)
            {
                case "viewAttributes":
                    btnViewAttributes_Click(sender, e);
                    break;
                case "filterNumeric":
                    FilterByNumericField();
                    break;
                case "projectionManager":
                    using (var form = new ProjectionManagerForm(map1, _layerOriginalProjections, _mapOriginalProjection))
                        form.ShowDialog(this);
                    break;
                case "areaCalculator":
                    using (var form = new AreaCalculatorForm(map1))
                        form.ShowDialog(this);
                    break;
                case "fillPits":
                    DoFillPits();
                    break;
                case "calcInit":
                    DoCalcInitialFlow();
                    break;
                case "resolveFlats":
                    DoResolveFlats();
                    break;
                case "exportFlow":
                    DoExportFlow();
                    break;
                case "dd":
                    // 打开排水密度栅格
                    btnLoadDD();
                    break;
                case "results":
                    // 计算 UAL 并生成河网
                    DoResults();
                    break;
                case "hillshade":
                    DoHillshade();
                    break;
                case "rasterColor":
                    DoChangeColor();
                    break;
                case "rasterCalc":
                    DoRasterCalc();
                    break;
                case "reclassify":
                    DoReclassify();
                    break;
                case "pickValue":
                    TogglePickValueMode();
                    break;
                case "drawHiking":
                    DoDrawHikingPath();
                    break;
                case "viewElevation":
                    DoViewElevation();
                    break;
            }
        }

        private void EnsureOriginalProjection()
        {
            if (_mapOriginalProjection == null) return;
            if (_mapOriginalProjection.Equals(map1.Projection)) return;

            foreach (var layer in map1.Layers.ToList())
            {
                if (_layerOriginalProjections.TryGetValue(layer, out var proj))
                {
                    if (layer is IMapFeatureLayer fl && fl.DataSet is DotSpatial.Data.IReproject fs && fs.CanReproject)
                    {
                        fs.Reproject(proj);
                    }
                    else if (layer is IMapRasterLayer rl && rl.DataSet is DotSpatial.Data.IReproject rs && rs.CanReproject)
                    {
                        rs.Reproject(proj);
                    }
                }
            }

            map1.Projection = _mapOriginalProjection;
            map1.ZoomToMaxExtent();
            map1.ResetBuffer();
        }

        IRaster demRaster;
        IRaster ddRaster;
        IRaster ualRaster;

        private void ComputeUAL()
        {
            int width = demRaster.NumColumns;
            int height = demRaster.NumRows;
            ualRaster = Raster.CreateRaster("ual.bgd", null, width, height, 1, typeof(double), new[] { string.Empty });
            ualRaster.Bounds = demRaster.Bounds.Copy();
            ualRaster.NoDataValue = -9999;

            int[,] donorCount = new int[height, width];
            Queue<(int, int)> sourceCells = new Queue<(int, int)>();

            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    if (ddRaster.Value[row, col] == ddRaster.NoDataValue) continue;
                    (int dr, int dc) = GetFlowDirection(row, col, demRaster);
                    if (InBounds(dr, dc, height, width))
                        donorCount[dr, dc]++;
                }
            }

            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    if (donorCount[row, col] == 0)
                        sourceCells.Enqueue((row, col));

                    double area = demRaster.CellHeight * demRaster.CellWidth;
                    ualRaster.Value[row, col] = ddRaster.Value[row, col] * area;
                }
            }

            while (sourceCells.Count > 0)
            {
                (int r, int c) = sourceCells.Dequeue();
                (int dr, int dc) = GetFlowDirection(r, c, demRaster);
                if (InBounds(dr, dc, height, width))
                {
                    ualRaster.Value[dr, dc] += ualRaster.Value[r, c];
                    donorCount[dr, dc]--;
                    if (donorCount[dr, dc] == 0)
                        sourceCells.Enqueue((dr, dc));
                }
            }

            map1.Layers.Add(ualRaster);
            
        }

        private (int, int) GetFlowDirection(int row, int col, IRaster dem)
        {
            double minElev = dem.Value[row, col];
            int dr = row, dc = col;
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0) continue;
                    int r2 = row + i, c2 = col + j;
                    if (!InBounds(r2, c2, dem.NumRows, dem.NumColumns)) continue;
                    double elev = dem.Value[r2, c2];
                    if (elev < minElev)
                    {
                        minElev = elev;
                        dr = r2;
                        dc = c2;
                    }
                }
            }
            return (dr, dc);
        }

        private bool InBounds(int r, int c, int rows, int cols)
        {
            return r >= 0 && r < rows && c >= 0 && c < cols;
        }

        private void BuildRiverShapefile()
        {
            if (ualRaster == null)
            {
                MessageBox.Show("请先计算 UAL！");
                return;
            }

            double ualThreshold = 100.0;
            FeatureSet fs = new FeatureSet(FeatureType.Line);
            fs.Projection = ProjectionInfo.FromProj4String(ualRaster.Projection.ToProj4String());

            int rows = ualRaster.NumRows;
            int cols = ualRaster.NumColumns;
            bool[,] visited = new bool[rows, cols];

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (visited[r, c]) continue;
                    double ual = ualRaster.Value[r, c];
                    if (ual < ualThreshold) continue;

                    bool isHeadwater = true;
                    for (int i = -1; i <= 1 && isHeadwater; i++)
                    {
                        for (int j = -1; j <= 1 && isHeadwater; j++)
                        {
                            if (i == 0 && j == 0) continue;
                            int rr = r + i, ccc = c + j;
                            if (!InBounds(rr, ccc, rows, cols)) continue;
                            (int dr, int dc) = GetFlowDirection(rr, ccc, demRaster);
                            if (dr == r && dc == c && ualRaster.Value[rr, ccc] >= ualThreshold)
                                isHeadwater = false;
                        }
                    }
                    if (!isHeadwater) continue;

                    List<Coordinate> coords = new List<Coordinate>();
                    int cr = r, cc = c;
                    while (true)
                    {
                        visited[cr, cc] = true;
                        double x = ualRaster.CellToProj(cc, cr).X;
                        double y = ualRaster.CellToProj(cc, cr).Y;
                        coords.Add(new Coordinate(x, y));

                        (int nr, int nc) = GetFlowDirection(cr, cc, demRaster);
                        if ((nr == cr && nc == cc) || !InBounds(nr, nc, rows, cols) || ualRaster.Value[nr, nc] < ualThreshold)
                            break;
                        cr = nr;
                        cc = nc;
                    }

                    if (coords.Count > 1)
                    {
                        LineString line = new LineString(coords.ToArray());
                        fs.AddFeature(line);
                    }
                }
            }
            string shpPath = "output/RiverNetwork.shp";
            fs.SaveAs(shpPath, true);
            map1.Layers.Add(fs);
            MessageBox.Show($"河网已保存至 {shpPath}");
        }

        private void DoResults()
        {
            if (demRaster == null || ddRaster == null)
            {
                MessageBox.Show("请先加载 DEM 和 Drainage Density");
                return;
            }
            ComputeUAL();
            BuildRiverShapefile();

        }


        private void btnLoadDD()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "GeoTIFF files (*.tif)|*.tif";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ddRaster = Raster.Open(ofd.FileName);
                map1.Layers.Add(ddRaster);
                MessageBox.Show("Drainage Density 加载成功！");
            }
        }

        private void FilterByNumericField()
        {
            if (map1.Layers.Count == 0)
            {
                MessageBox.Show("Please add a layer first.");
                return;
            }

            using (var form = new NumericFilterForm(map1))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    var layer = form.SelectedLayer;
                    var field = form.SelectedField;
                    double minVal = form.Threshold;

                    if (layer != null && !string.IsNullOrEmpty(field))
                    {
                        layer.DataSet.FillAttributes();
                        layer.SelectByAttribute($"[{field}] >= {minVal}");
                    }
                }
            }
        }

        private void DoFillPits()
        {
            if (_demRaster == null)
            {
                MessageBox.Show("请先加载DEM栅格。");
                return;
            }
            var filled = Services.FlowDirectionTools.FillPits(_demRaster);
            map1.Layers.Add(filled);
            _demRaster = filled;
        }

        private void DoCalcInitialFlow()
        {
            if (_demRaster == null)
            {
                MessageBox.Show("请先加载DEM栅格。");
                return;
            }
            _flowDir = Services.FlowDirectionTools.ComputeInitialFlow(_demRaster);
            var flowRaster = Services.FlowDirectionTools.FlowArrayToRaster(_flowDir, _demRaster);
            map1.Layers.Add(flowRaster);
        }

        private void DoResolveFlats()
        {
            if (_demRaster == null || _flowDir == null)
            {
                MessageBox.Show("请先计算初始流向。");
                return;
            }
            _flowDir = Services.FlowDirectionTools.ResolveFlats(_demRaster, _flowDir);
            var flowRaster = Services.FlowDirectionTools.FlowArrayToRaster(_flowDir, _demRaster);
            map1.Layers.Add(flowRaster);
        }

        private void DoExportFlow()
        {
            if (_flowDir == null)
            {
                MessageBox.Show("没有流向结果可导出。");
                return;
            }
            using (var dlg = new SaveFileDialog { Filter = "ASCII Grid (*.asc)|*.asc" })
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    Services.FlowDirectionTools.ExportFlowDirectionAsc(dlg.FileName, _flowDir);
                    MessageBox.Show("已导出: " + dlg.FileName);
                }
            }
        }

        private void DoHillshade()
        {
            IMapRasterLayer layer = map1.Layers.SelectedLayer as IMapRasterLayer ??
                                  (map1.Layers.Count > 0 ? map1.Layers[0] as IMapRasterLayer : null);
            if (layer == null)
            {
                MessageBox.Show("请先选择栅格图层。");
                return;
            }
            layer.Symbolizer.ShadedRelief.ElevationFactor = 1;
            layer.Symbolizer.ShadedRelief.IsUsed = true;
            layer.WriteBitmap();
        }

        private void DoChangeColor()
        {
            IMapRasterLayer layer = map1.Layers.SelectedLayer as IMapRasterLayer ??
                                  (map1.Layers.Count > 0 ? map1.Layers[0] as IMapRasterLayer : null);
            if (layer == null)
            {
                MessageBox.Show("请先选择栅格图层。");
                return;
            }

            ColorScheme scheme = new ColorScheme();
            ColorCategory c1 = new ColorCategory(2500, 3000, Color.Red, Color.Yellow)
            { LegendText = "Elevation 2500 - 3000" };
            ColorCategory c2 = new ColorCategory(1000, 2500, Color.Blue, Color.Green)
            { LegendText = "Elevation 1000 - 2500" };
            scheme.AddCategory(c1);
            scheme.AddCategory(c2);

            layer.Symbolizer.Scheme = scheme;
            layer.WriteBitmap();
        }

        private void DoRasterCalc()
        {
            IMapRasterLayer layer = map1.Layers.SelectedLayer as IMapRasterLayer ??
                                  (map1.Layers.Count > 0 ? map1.Layers[0] as IMapRasterLayer : null);
            if (layer == null)
            {
                MessageBox.Show("请先选择栅格图层。");
                return;
            }

            string expr = Interaction.InputBox(
                "输入表达式，使用x表示像元值，例如:\n  x*2\n  x+100\n  (x-1)/2",
                "栅格运算");
            if (string.IsNullOrWhiteSpace(expr)) return;

            IRaster src = layer.DataSet;
            string[] opts = new string[1];
            IRaster result = Raster.CreateRaster("calc.bgd", null, src.NumColumns, src.NumRows, 1, src.DataType, opts);
            result.Bounds = src.Bounds.Copy();
            result.NoDataValue = src.NoDataValue;
            result.Projection = src.Projection;

            var dt = new System.Data.DataTable();
            for (int i = 0; i < src.NumRows; i++)
            {
                for (int j = 0; j < src.NumColumns; j++)
                {
                    double val = src.Value[i, j];
                    if (val == src.NoDataValue)
                    {
                        result.Value[i, j] = src.NoDataValue;
                        continue;
                    }
                    string e = expr.Replace("x", val.ToString(CultureInfo.InvariantCulture));
                    try
                    {
                        object r = dt.Compute(e, "");
                        result.Value[i, j] = Convert.ToDouble(r);
                    }
                    catch
                    {
                        result.Value[i, j] = val;
                    }
                }
            }
            result.Save();
            map1.Layers.Add(result);
        }

        private void DoReclassify()
        {
            IMapRasterLayer layer = map1.Layers.SelectedLayer as IMapRasterLayer ??
                                  (map1.Layers.Count > 0 ? map1.Layers[0] as IMapRasterLayer : null);
            if (layer == null)
            {
                MessageBox.Show("请先选择栅格图层。");
                return;
            }

            string input = Interaction.InputBox("请输入阈值：高于该值为1，低于该值为0", "栅格重分类");
            if (!double.TryParse(input, out double threshold)) return;

            IRaster src = layer.DataSet;
            string[] opts = new string[1];
            IRaster result = Raster.CreateRaster("reclass.bgd", null, src.NumColumns, src.NumRows, 1, src.DataType, opts);
            result.Bounds = src.Bounds.Copy();
            result.NoDataValue = src.NoDataValue;
            result.Projection = src.Projection;

            for (int i = 0; i < src.NumRows; i++)
            {
                for (int j = 0; j < src.NumColumns; j++)
                {
                    double val = src.Value[i, j];
                    if (val == src.NoDataValue)
                    {
                        result.Value[i, j] = src.NoDataValue;
                    }
                    else
                    {
                        result.Value[i, j] = val >= threshold ? 1 : 0;
                    }
                }
            }
            result.Save();
            map1.Layers.Add(result);
        }

        private void TogglePickValueMode()
        {
            _pickValueMode = !_pickValueMode;
            map1.Cursor = _pickValueMode ? Cursors.Cross : Cursors.Default;
            if (_pickValueMode)
                MessageBox.Show("请在地图上点击以获取像元值");
        }

        private void map1_MouseUp(object sender, MouseEventArgs e)
        {
            if (!_pickValueMode) return;

            IMapRasterLayer layer = map1.Layers.SelectedLayer as IMapRasterLayer ??
                                  (map1.Layers.Count > 0 ? map1.Layers[0] as IMapRasterLayer : null);
            if (layer == null) return;

            IRaster raster = layer.DataSet;
            Coordinate coord = map1.PixelToProj(e.Location);
            RcIndex rc = raster.Bounds.ProjToCell(coord);
            int row = rc.Row;
            int col = rc.Column;
            if (col >= 0 && col < raster.NumColumns && row >= 0 && row < raster.NumRows)
            {
                double value = raster.Value[row, col];
                MessageBox.Show($"Row: {row} Col: {col} Value: {value}", "像元值");
            }
        }

        private void map1_MouseDown(object sender, MouseEventArgs e)
        {
            if (_hikingDrawing)
            {
                if (e.Button == MouseButtons.Left)
                {
                    Coordinate coord = map1.PixelToProj(e.Location);
                    if (_hikingFirstClick)
                    {
                        var list = new List<Coordinate>();
                        LineString geom = new LineString(list);
                        IFeature f = _hikingPathF.AddFeature(geom);
                        f.Coordinates.Add(coord);
                        f.DataRow["ID"] = 1;
                        _hikingFirstClick = false;
                    }
                    else
                    {
                        IFeature existing = _hikingPathF.Features[_hikingPathF.Features.Count - 1];
                        existing.Coordinates.Add(coord);
                        if (existing.Coordinates.Count >= 2)
                        {
                            _hikingPathF.InitializeVertices();
                            map1.ResetBuffer();
                        }
                    }
                }
                else
                {
                    _hikingFirstClick = true;
                    _hikingDrawing = false;
                    map1.Cursor = Cursors.Default;
                }
                return;
            }
            switch (_shapeType)
            {
                case "Point":
                    if (e.Button == MouseButtons.Left && _pointDrawing)
                    {
                        Coordinate coord = map1.PixelToProj(e.Location);
                        var point = new DotSpatial.Topology.Point(coord);
                        IFeature f = _pointF.AddFeature(point);
                        _pointID++;
                        f.DataRow["PointID"] = _pointID;
                        map1.ResetBuffer();
                    }
                    else if (e.Button != MouseButtons.Left)
                    {
                        map1.Cursor = Cursors.Default;
                        _pointDrawing = false;
                    }
                    break;
                case "line":
                    if (e.Button == MouseButtons.Left && _lineDrawing)
                    {
                        Coordinate coord = map1.PixelToProj(e.Location);
                        if (_firstClick)
                        {
                            List<Coordinate> list = new List<Coordinate>();
                            LineString geom = new LineString(list);
                            IFeature lf = _lineF.AddFeature(geom);
                            lf.Coordinates.Add(coord);
                            _lineID++;
                            lf.DataRow["LineID"] = _lineID;
                            _firstClick = false;
                        }
                        else
                        {
                            IFeature existing = _lineF.Features[_lineF.Features.Count - 1];
                            existing.Coordinates.Add(coord);
                            if (existing.Coordinates.Count >= 2)
                            {
                                _lineF.InitializeVertices();
                                map1.ResetBuffer();
                            }
                        }
                    }
                    else if (e.Button != MouseButtons.Left)
                    {
                        _firstClick = true;
                        map1.ResetBuffer();
                    }
                    break;
                case "polygon":
                    if (e.Button == MouseButtons.Left && _polygonDrawing)
                    {
                        Coordinate coord = map1.PixelToProj(e.Location);
                        if (_firstClick)
                        {
                            List<Coordinate> list = new List<Coordinate>();
                            LinearRing geom = new LinearRing(list);
                            IFeature pf = _polygonF.AddFeature(geom);
                            pf.Coordinates.Add(coord);
                            _polygonID++;
                            pf.DataRow["PolygonID"] = _polygonID;
                            _firstClick = false;
                        }
                        else
                        {
                            IFeature existing = _polygonF.Features[_polygonF.Features.Count - 1];
                            existing.Coordinates.Add(coord);
                            if (existing.Coordinates.Count >= 3)
                            {
                                _polygonF.InitializeVertices();
                                map1.ResetBuffer();
                            }
                        }
                    }
                    else if (e.Button != MouseButtons.Left)
                    {
                        _firstClick = true;
                    }
                    break;
            }
        }

        private void createPointShapefileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            map1.Cursor = Cursors.Cross;
            _shapeType = "Point";
            _pointF.Projection = map1.Projection;
            if (!_pointF.DataTable.Columns.Contains("PointID"))
                _pointF.DataTable.Columns.Add(new DataColumn("PointID"));
            MapPointLayer lyr = (MapPointLayer)map1.Layers.Add(_pointF);
            lyr.Symbolizer = new PointSymbolizer(Color.Red, DotSpatial.Symbology.PointShape.Ellipse, 3);
            lyr.LegendText = "point";
            _pointDrawing = true;
        }

        private void savePointShapefileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "Shapefile|*.shp";
                dlg.FileName = "point.shp";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _pointF.SaveAs(dlg.FileName, true);
                    MessageBox.Show("The point shapefile has been saved.");
                }
            }
            map1.Cursor = Cursors.Arrow;
        }

        private void createPolylineShapefileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            map1.Cursor = Cursors.Cross;
            _shapeType = "line";
            _lineF.Projection = map1.Projection;
            if (!_lineF.DataTable.Columns.Contains("LineID"))
                _lineF.DataTable.Columns.Add(new DataColumn("LineID"));
            _lineLayer = (MapLineLayer)map1.Layers.Add(_lineF);
            _lineLayer.Symbolizer = new LineSymbolizer(Color.Blue, 2);
            _lineLayer.LegendText = "line";
            _firstClick = true;
            _lineDrawing = true;
        }

        private void savePolylineShapefileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "Shapefile|*.shp";
                dlg.FileName = "line.shp";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _lineF.SaveAs(dlg.FileName, true);
                    MessageBox.Show("The polyline shapefile has been saved.");
                }
            }
            map1.Cursor = Cursors.Arrow;
            _lineDrawing = false;
        }

        private void createPolygonShapefileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            map1.Cursor = Cursors.Cross;
            _shapeType = "polygon";
            _polygonF.Projection = map1.Projection;
            if (!_polygonF.DataTable.Columns.Contains("PolygonID"))
                _polygonF.DataTable.Columns.Add(new DataColumn("PolygonID"));
            MapPolygonLayer lyr = (MapPolygonLayer)map1.Layers.Add(_polygonF);
            lyr.Symbolizer = new PolygonSymbolizer(Color.Green);
            lyr.LegendText = "polygon";
            _firstClick = true;
            _polygonDrawing = true;
        }

        private void savePolygonShapefileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "Shapefile|*.shp";
                dlg.FileName = "polygon.shp";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _polygonF.SaveAs(dlg.FileName, true);
                    MessageBox.Show("The polygon shapefile has been saved.");
                }
            }
            map1.Cursor = Cursors.Arrow;
            _polygonDrawing = false;
        }

        private void printMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new DotSpatial.Controls.LayoutForm
            {
                MapControl = map1
            };
            frm.Show();
        }

        private void DoDrawHikingPath()
        {
            foreach (var lyr in map1.GetLineLayers())
            {
                if (lyr == _hikingLayer)
                    map1.Layers.Remove(lyr);
            }

            _hikingPathF = new FeatureSet(FeatureType.Line)
            {
                Projection = map1.Projection
            };
            if (!_hikingPathF.DataTable.Columns.Contains("ID"))
                _hikingPathF.DataTable.Columns.Add(new DataColumn("ID"));
            _hikingLayer = (MapLineLayer)map1.Layers.Add(_hikingPathF);
            _hikingLayer.Symbolizer = new LineSymbolizer(Color.Blue, 2);
            _hikingLayer.LegendText = "Hiking path";
            _hikingFirstClick = true;
            _hikingDrawing = true;
            _pickValueMode = false;
            map1.Cursor = Cursors.Cross;
        }

        private List<PathPoint> ExtractElevation(Coordinate start, Coordinate end, IMapRasterLayer raster)
        {
            var list = new List<PathPoint>();
            int steps = 100;
            double dx = (end.X - start.X) / steps;
            double dy = (end.Y - start.Y) / steps;
            double x = start.X;
            double y = start.Y;
            for (int i = 0; i <= steps; i++)
            {
                Coordinate c = new Coordinate(x, y);
                RcIndex rc = raster.DataSet.Bounds.ProjToCell(c);
                double elev = raster.DataSet.NoDataValue;
                if (rc.Row >= 0 && rc.Row < raster.DataSet.NumRows && rc.Column >= 0 && rc.Column < raster.DataSet.NumColumns)
                    elev = raster.DataSet.Value[rc.Row, rc.Column];
                list.Add(new PathPoint { X = x, Y = y, Elevation = elev });
                x += dx;
                y += dy;
            }
            return list;
        }

        private void DoViewElevation()
        {
            IMapRasterLayer rasterLayer = map1.Layers.SelectedLayer as IMapRasterLayer ??
                                           (map1.GetRasterLayers().Count() > 0 ? map1.GetRasterLayers()[0] : null);
            if (rasterLayer == null)
            {
                MessageBox.Show("请先添加DEM栅格图层");
                return;
            }

            if (_hikingPathF == null || _hikingPathF.Features.Count == 0)
            {
                MessageBox.Show("请先绘制徒步路径");
                return;
            }

            IList<Coordinate> coords = _hikingPathF.Features[0].Coordinates;
            var allPoints = new List<PathPoint>();
            for (int i = 0; i < coords.Count - 1; i++)
            {
                allPoints.AddRange(ExtractElevation(coords[i], coords[i + 1], rasterLayer));
            }

            double dist = 0;
            for (int i = 1; i < allPoints.Count; i++)
            {
                double dx = allPoints[i].X - allPoints[i - 1].X;
                double dy = allPoints[i].Y - allPoints[i - 1].Y;
                dist += Math.Sqrt(dx * dx + dy * dy);
                allPoints[i].Distance = dist;
            }

            var frm = new HikingChartForm(allPoints);
            frm.Show();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnsetColor_Click(object sender, EventArgs e)
        {
            if (this.colorDialog1.ShowDialog() == DialogResult.OK)
            {
                fcolor = colorDialog1.Color;
            }
        }

        private void btnsetFont_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fname = fontDialog1.Font.Name;
                fsize = fontDialog1.Font.Size;
            }
        }

        private void cmbFiledName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void DisplayLabels(string attributename)
        {
            if (map1.Layers.Count > 0 && map1.Layers[0] is IMapFeatureLayer featureLayer)
            {
                // 使用新的标签添加方法
                featureLayer.AddLabels("[" + attributename + "]", new System.Drawing.Font(fname, (float)fsize), fcolor);
            }
            else
            {
                MessageBox.Show("Please add a layer to the map.");
            }
        }
        private void FillColumnNames(FeatureSet featureSet)
        {
            if (featureSet != null && featureSet.DataTable != null)
            {
                foreach (DataColumn column in featureSet.DataTable.Columns)
                {
                    cmbFiledName.Items.Add(column.ColumnName);
                }
            }
        }

        private void FillColumnNames(IFeatureSet featureSet)
        {
            foreach (DataColumn column in featureSet.DataTable.Columns)
            {
                cmbFiledName.Items.Add(column.ColumnName);
            }
        }

        private void DisplayLabels1(string attributename)
        {
            if (map1.Layers.Count > 0 && map1.Layers[0] is IMapFeatureLayer featureLayer)
            {
                // 使用新的标签添加方法
                featureLayer.AddLabels("[" + attributename + "]", new System.Drawing.Font(fname, (float)fsize), fcolor);
            }
            else
            {
                MessageBox.Show("Please add a layer to the map.");
            }
        }

        private void btnDisplayLabel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbFiledName.Text))
            {
                MessageBox.Show("Please select an attribute from the dropdown");
                return;
            }

            DisplayLabels1(cmbFiledName.Text);
        }

        private void fontDialog1_Apply(object sender, EventArgs e)
        {

        }

        private void txtCustomAttribute_TextChanged(object sender, EventArgs e)
        {
            map1.FunctionMode = FunctionMode.Select;
        }

        [Obsolete]
        private void DisplayCustomLabel(string attributeValue)
        {
            if (string.IsNullOrEmpty(txtCustomAttribute.Text))
            {
                MessageBox.Show("Please enter the label text");
                return;
            }

            IMapFeatureLayer selectedLayer = (IMapFeatureLayer)map1.Layers[0];
            if (selectedLayer == null)
            {
                MessageBox.Show("Please add a layer to the map");
                return;
            }

            int numSelectedFeatures = selectedLayer.Selection.Count;
            if (numSelectedFeatures == 0)
            {
                MessageBox.Show("Please select a shape in the map");
                return;
            }

            //create new column in attribute table
            System.Data.DataTable table = selectedLayer.DataSet.DataTable;


            if (!(table.Columns.Contains("new_label")))
            {
                table.Columns.Add(new DataColumn("new_label"));
            }


            List<IFeature> selectedFeatureList = selectedLayer.Selection.ToFeatureList();
            IFeature selectedFeature = selectedFeatureList[0];

            selectedFeature.DataRow["new_label"] = txtCustomAttribute.Text;

            //display labels in the map
            map1.AddLabels(selectedLayer, "[new_label]", new System.Drawing.Font("" + fname + "", (float)fsize), fcolor);

            //reset map selection mode
            map1.FunctionMode = FunctionMode.None;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DisplayCustomLabel(txtCustomAttribute.Text);
            txtCustomAttribute.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (map1.Layers.Count > 0)
            {
                IMapFeatureLayer stateLayer = default(IMapFeatureLayer);
                stateLayer = (IMapFeatureLayer)map1.Layers[0];
                stateLayer.DataSet.Save();
                MessageBox.Show("Attribute has been saved in the shapefile.");
            }
            else
            {
                MessageBox.Show("Please add a layer to the map.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Declare a datatable
            System.Data.DataTable dt = null;
            if (map1.Layers.Count > 0)
            {
                IMapFeatureLayer stateLayer = default(IMapFeatureLayer);
                stateLayer = (IMapFeatureLayer)map1.Layers[0];
                //Get the shapefile's attribute table to our datatable dt
                dt = stateLayer.DataSet.DataTable;
                //Remove a column
                dt.Columns.Remove("new_label");
                stateLayer.DataSet.Save();
                MessageBox.Show("Attribute has been removed in the shapefile.");
            }
            else
            {
                MessageBox.Show("Please add a layer to the map.");
            }
        }

        private void treeVectorOps_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}