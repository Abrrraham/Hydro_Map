using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Demo_Map
{
    public class HikingChartForm : Form
    {
        private Chart _chart;

        public HikingChartForm(List<PathPoint> points)
        {
            InitializeComponent();
            LoadChart(points);
        }

        private void InitializeComponent()
        {
            Text = "Hiking Path Elevation";
            ClientSize = new Size(800, 450);

            _chart = new Chart { Dock = DockStyle.Fill };
            _chart.ChartAreas.Add(new ChartArea());
            Controls.Add(_chart);
        }

        private void LoadChart(List<PathPoint> points)
        {
            var series = new Series
            {
                ChartType = SeriesChartType.Line,
                BorderWidth = 2
            };
            foreach (var p in points)
            {
                series.Points.AddXY(p.Distance, p.Elevation);
            }
            _chart.Series.Clear();
            _chart.Series.Add(series);
            _chart.ChartAreas[0].AxisX.Title = "Distance (meters)";
            _chart.ChartAreas[0].AxisY.Title = "Elevation (meters)";
        }
    }
}
