using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DotSpatial.Controls;
using DotSpatial.Symbology;
using DotSpatial.Data;
using DotSpatial.Projections;
using Demo_Map.BLL;
using Demo_Map.Models;

namespace Demo_Map
{
    public class AreaCalculatorForm : Form
    {
        private readonly Map _map;
        private readonly IAreaCalculatorService _calculator = new AreaCalculatorService();
        private ComboBox cmbLayer;
        private ComboBox cmbField;
        private ComboBox cmbValue;
        private ComboBox cmbUnit;
        private Label lblResult;
        private Button btnCompute;

        public AreaCalculatorForm(Map map)
        {
            _map = map;
            InitializeComponent();
            LoadLayers();
        }

        private void InitializeComponent()
        {
            Text = "面积计算";
            Size = new System.Drawing.Size(350, 400);
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
            var lblValue = new Label { Text = "取值", Dock = DockStyle.Top };
            cmbValue = new ComboBox { Dock = DockStyle.Top, DropDownStyle = ComboBoxStyle.DropDownList };
            var lblUnit = new Label { Text = "单位", Dock = DockStyle.Top };
            cmbUnit = new ComboBox { Dock = DockStyle.Top, DropDownStyle = ComboBoxStyle.DropDownList };
            lblResult = new Label { Dock = DockStyle.Top, Height = 30 };
            btnCompute = new Button { Text = "计算", Dock = DockStyle.Bottom };

            cmbUnit.Items.AddRange(new object[] { AreaUnit.SquareMeters, AreaUnit.SquareKilometers, AreaUnit.Hectares });
            cmbUnit.SelectedIndex = 1;

            Controls.Add(btnCompute);
            Controls.Add(lblResult);
            Controls.Add(cmbUnit);
            Controls.Add(lblUnit);
            Controls.Add(cmbValue);
            Controls.Add(lblValue);
            Controls.Add(cmbField);
            Controls.Add(lblField);
            Controls.Add(cmbLayer);
            Controls.Add(lblLayer);

            cmbLayer.SelectedIndexChanged += (s, e) => LoadFields();
            cmbField.SelectedIndexChanged += (s, e) => LoadValues();
            btnCompute.Click += (s, e) => Compute();
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
            cmbValue.Items.Clear();
            var layer = cmbLayer.SelectedItem as IMapFeatureLayer;
            if (layer == null) return;
            foreach (DataColumn col in layer.DataSet.DataTable.Columns)
            {
                cmbField.Items.Add(col.ColumnName);
            }
            if (cmbField.Items.Count > 0)
                cmbField.SelectedIndex = 0;
        }

        private void LoadValues()
        {
            cmbValue.Items.Clear();
            var layer = cmbLayer.SelectedItem as IMapFeatureLayer;
            var fieldName = cmbField.SelectedItem as string;
            if (layer == null || string.IsNullOrEmpty(fieldName)) return;
            var values = layer.DataSet.DataTable.AsEnumerable()
                .Select(r => r[fieldName])
                .Distinct()
                .ToList();
            foreach (var val in values)
            {
                cmbValue.Items.Add(val);
            }
            if (cmbValue.Items.Count > 0)
                cmbValue.SelectedIndex = 0;
        }

        private void Compute()
        {
            var layer = cmbLayer.SelectedItem as IMapFeatureLayer;
            var field = cmbField.SelectedItem as string;
            var value = cmbValue.SelectedItem;
            if (layer == null || field == null || value == null) return;

            double area = 0;
            var fs = layer.DataSet;
            var origProj = fs.Projection;

            // clone the feature set when reprojection is required
            bool reproj = origProj == null || origProj.IsLatLon;
            IFeatureSet working = fs;
            FeatureSet tempSet = null;
            if (reproj)
            {
                var tempProj = KnownCoordinateSystems.Projected.World.CylindricalEqualAreaworld;
                if (!tempProj.Equals(origProj))
                {
                    tempSet = new FeatureSet(fs.FeatureType);
                    tempSet.CopyFeatures(fs, true);
                    tempSet.Projection = origProj;
                    tempSet.Reproject(tempProj);
                    working = tempSet;
                }
            }

            area = _calculator.ComputeByField(working, field, value);

            //tempSet?.Dispose();

            var unit = (AreaUnit)cmbUnit.SelectedItem;
            double converted = _calculator.Convert(area, unit);
            lblResult.Text = $"面积: {converted:N3} {UnitLabel(unit)}";
        }

        private string UnitLabel(AreaUnit unit)
        {
            switch (unit)
            {
                case AreaUnit.SquareKilometers: return "km²";
                case AreaUnit.Hectares: return "ha";
                default: return "m²";
            }
        }
    }
}