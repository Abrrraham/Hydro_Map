using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DotSpatial.Controls;
using DotSpatial.Symbology;

namespace Demo_Map
{
    public class NumericFilterForm : Form
    {
        private readonly Map _map;
        private ComboBox cmbLayer;
        private ComboBox cmbField;
        private NumericUpDown nudValue;
        private Button btnOk;
        private Button btnCancel;

        public IMapFeatureLayer SelectedLayer { get; private set; }
        public string SelectedField { get; private set; }
        public double Threshold { get; private set; }

        public NumericFilterForm(Map map)
        {
            _map = map;
            InitializeComponent();
            LoadLayers();
        }

        private void InitializeComponent()
        {
            Text = "字段数值筛选";
            Size = new Size(400, 220);
            FormBorderStyle = FormBorderStyle.Sizable;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;

            var lblLayer = new Label { Text = "图层", Dock = DockStyle.Top };
            cmbLayer = new ComboBox
            {
                Dock = DockStyle.Top,
                DropDownStyle = ComboBoxStyle.DropDownList,
                DisplayMember = "LegendText"
            };
            var lblField = new Label { Text = "字段", Dock = DockStyle.Top };
            cmbField = new ComboBox { Dock = DockStyle.Top, DropDownStyle = ComboBoxStyle.DropDownList };
            var lblValue = new Label { Text = "最小值", Dock = DockStyle.Top };
            nudValue = new NumericUpDown { Dock = DockStyle.Top, DecimalPlaces = 2, Maximum = decimal.MaxValue };
            var lblInfo = new Label { Text = "筛选规则: 选定字段并输入阈值，保留>=阈值的要素", Dock = DockStyle.Bottom, Height = 25 };
            var panelButtons = new FlowLayoutPanel { Dock = DockStyle.Bottom, FlowDirection = FlowDirection.RightToLeft, Height = 35 };
            btnOk = new Button { Text = "确定", DialogResult = DialogResult.OK };
            btnCancel = new Button { Text = "取消", DialogResult = DialogResult.Cancel };
            panelButtons.Controls.Add(btnOk);
            panelButtons.Controls.Add(btnCancel);

            Controls.Add(panelButtons);
            Controls.Add(lblInfo);
            Controls.Add(nudValue);
            Controls.Add(lblValue);
            Controls.Add(cmbField);
            Controls.Add(lblField);
            Controls.Add(cmbLayer);
            Controls.Add(lblLayer);

            cmbLayer.SelectedIndexChanged += (s, e) => LoadFields();
            btnOk.Click += (s, e) => Apply();
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

        private void LoadFields()
        {
            cmbField.Items.Clear();
            var layer = cmbLayer.SelectedItem as IMapFeatureLayer;
            if (layer == null) return;
            foreach (DataColumn col in layer.DataSet.DataTable.Columns)
            {
                if (IsNumericType(col.DataType))
                {
                    cmbField.Items.Add(col.ColumnName);
                }
            }
            if (cmbField.Items.Count > 0)
                cmbField.SelectedIndex = 0;
        }

        private bool IsNumericType(Type type)
        {
            return type == typeof(short) || type == typeof(int) || type == typeof(long) ||
                   type == typeof(float) || type == typeof(double) || type == typeof(decimal);
        }

        private void Apply()
        {
            SelectedLayer = cmbLayer.SelectedItem as IMapFeatureLayer;
            SelectedField = cmbField.SelectedItem as string;
            Threshold = (double)nudValue.Value;
        }
    }
}