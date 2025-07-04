using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DotSpatial.Controls;
using DotSpatial.Symbology;
// Avoid importing the entire Excel namespace because it defines a DataTable
// class that conflicts with System.Data.DataTable. We reference Excel types
// with their fully qualified names instead.

namespace Demo_Map
{
    public class AttributeTableForm : Form
    {
        private readonly Map _map;
        private ComboBox cmbLayer;
        private DataGridView dgvAttributes;
        private MenuStrip menuStrip;
        private ToolStripMenuItem addColumnMenuItem;
        private ToolStripMenuItem deleteColumnMenuItem;
        private ToolStripMenuItem updateTableMenuItem;
        private ToolStripMenuItem exportExcelMenuItem;

        public AttributeTableForm(Map map)
        {
            _map = map;
            InitializeComponent();
            LoadLayers();
        }

        private void InitializeComponent()
        {
            Text = "属性表";
            Size = new Size(600, 400);
            menuStrip = new MenuStrip { Dock = DockStyle.Top };
            addColumnMenuItem = new ToolStripMenuItem("插入列", null, addColumnMenuItem_Click);
            deleteColumnMenuItem = new ToolStripMenuItem("删除列", null, deleteColumnMenuItem_Click);
            updateTableMenuItem = new ToolStripMenuItem("更新列", null, updateTableMenuItem_Click);
            exportExcelMenuItem = new ToolStripMenuItem("导出Excel", null, exportExcelMenuItem_Click);
            menuStrip.Items.AddRange(new ToolStripItem[] { addColumnMenuItem, deleteColumnMenuItem, updateTableMenuItem, exportExcelMenuItem });

            cmbLayer = new ComboBox
            {
                Dock = DockStyle.Top,
                DropDownStyle = ComboBoxStyle.DropDownList,
                DisplayMember = "LegendText"
            };
            dgvAttributes = new DataGridView { Dock = DockStyle.Fill };

            Controls.Add(dgvAttributes);
            Controls.Add(cmbLayer);
            Controls.Add(menuStrip);

            cmbLayer.SelectedIndexChanged += (s, e) => ShowAttributes();
        }

        private void LoadLayers()
        {
            cmbLayer.Items.Clear();
            foreach (var layer in _map.Layers.OfType<IMapFeatureLayer>())
            {
                cmbLayer.Items.Add(layer);
            }
            if (cmbLayer.Items.Count > 0)
                cmbLayer.SelectedIndex = 0;
        }

        private void ShowAttributes()
        {
            var layer = cmbLayer.SelectedItem as IMapFeatureLayer;
            if (layer != null)
            {
                dgvAttributes.DataSource = layer.DataSet.DataTable;
            }
        }

        private void addColumnMenuItem_Click(object sender, EventArgs e)
        {
            var layer = cmbLayer.SelectedItem as IMapFeatureLayer;
            if (layer == null) { MessageBox.Show("请先选择图层"); return; }

            DataTable dt = layer.DataSet.DataTable;
            if (!dt.Columns.Contains("PercentMales"))
                dt.Columns.Add(new DataColumn("PercentMales"));

            foreach (DataRow row in dt.Rows)
            {
                double males = 0;
                double females = 0;
                if (dt.Columns.Contains("males")) males = Convert.ToDouble(row["males"]);
                if (dt.Columns.Contains("females")) females = Convert.ToDouble(row["females"]);

                row["PercentMales"] = (males > 0 || females > 0) ? males / (males + females) * 100 : 0;
            }
            dgvAttributes.DataSource = dt;
        }

        private void deleteColumnMenuItem_Click(object sender, EventArgs e)
        {
            var layer = cmbLayer.SelectedItem as IMapFeatureLayer;
            if (layer == null) { MessageBox.Show("请先选择图层"); return; }

            DataTable dt = layer.DataSet.DataTable;
            if (dt.Columns.Contains("PercentMales"))
                dt.Columns.Remove("PercentMales");
            dgvAttributes.DataSource = dt;
        }

        private void updateTableMenuItem_Click(object sender, EventArgs e)
        {
            var layer = cmbLayer.SelectedItem as IMapFeatureLayer;
            if (layer == null) { MessageBox.Show("请先选择图层"); return; }

            var result = MessageBox.Show("确定要更新属性表吗？", "确认更新", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                layer.DataSet.Save();
            }
        }

        private void exportExcelMenuItem_Click(object sender, EventArgs e)
        {
            var layer = cmbLayer.SelectedItem as IMapFeatureLayer;
            if (layer == null) { MessageBox.Show("请先选择图层"); return; }
            ExportToExcel(layer.DataSet.DataTable);
        }

        private void ExportToExcel(DataTable objDT)
        {
            var xlApp = new Microsoft.Office.Interop.Excel.Application();
            if (xlApp == null)
            {
                MessageBox.Show("需要安装Excel");
                return;
            }

            var saveDialog = new SaveFileDialog
            {
                Filter = "Excel文件|*.xls",
                FileName = "AttributeTable.xls"
            };
            if (saveDialog.ShowDialog() != DialogResult.OK)
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
                return;
            }

            string strFilename = saveDialog.FileName;

            try
            {
                xlApp.SheetsInNewWorkbook = 1;
                xlApp.Workbooks.Add();
                xlApp.Worksheets[1].Select();
                xlApp.Cells[1, 1].value = "Attribute table";
                xlApp.Cells[1, 1].EntireRow.Font.Bold = true;

                int intI = 1;
                for (int col = 0; col < objDT.Columns.Count; col++)
                {
                    xlApp.Cells[2, intI].value = objDT.Columns[col].ColumnName;
                    xlApp.Cells[2, intI].EntireRow.Font.Bold = true;
                    intI++;
                }

                intI = 3;
                int intK = 1;
                for (int col = 0; col < objDT.Columns.Count; col++)
                {
                    intI = 3;
                    for (int row = 0; row < objDT.Rows.Count; row++)
                    {
                        xlApp.Cells[intI, intK].Value = objDT.Rows[row].ItemArray[col];
                        intI++;
                    }
                    intK++;
                }

                xlApp.ActiveCell.Worksheet.SaveAs(strFilename);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
                xlApp = null;
                MessageBox.Show($"Excel已导出到 {strFilename}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            System.Diagnostics.Process[] pro = System.Diagnostics.Process.GetProcessesByName("EXCEL");
            foreach (var i in pro) i.Kill();
        }
    }
}