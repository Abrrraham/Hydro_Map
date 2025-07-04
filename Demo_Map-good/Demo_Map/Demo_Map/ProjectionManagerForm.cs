using System;
using System.Windows.Forms;
using DotSpatial.Controls;
using DotSpatial.Projections;
using DotSpatial.Data;
using DotSpatial.Symbology;

namespace Demo_Map
{
    public class ProjectionManagerForm : Form
    {
        private readonly Map _map;
        private readonly System.Collections.Generic.Dictionary<IMapLayer, ProjectionInfo> _originals;
        private readonly ProjectionInfo _mapOrig;
        private ComboBox cmbProjections;
        private Button btnApply;
        private Button btnReset;

        public ProjectionManagerForm(Map map, System.Collections.Generic.Dictionary<IMapLayer, ProjectionInfo> originals, ProjectionInfo mapOrig)
        {
            _map = map;
            _originals = originals;
            _mapOrig = mapOrig;
            InitializeComponent();
            LoadProjections();
        }

        private void InitializeComponent()
        {
            Text = "投影管理";
            Size = new System.Drawing.Size(400, 300);
            FormBorderStyle = FormBorderStyle.Sizable;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;

            cmbProjections = new ComboBox { Dock = DockStyle.Top, DropDownStyle = ComboBoxStyle.DropDownList };
            btnApply = new Button { Text = "应用", Dock = DockStyle.Bottom };
            btnReset = new Button { Text = "恢复初始投影", Dock = DockStyle.Bottom };

            Controls.Add(btnApply);
            Controls.Add(btnReset);
            Controls.Add(cmbProjections);

            btnApply.Click += (s, e) => ApplyProjection();
            btnReset.Click += (s, e) => ResetProjection();
        }

        private void LoadProjections()
        {
           cmbProjections.Items.Clear();
            cmbProjections.Items.Add(new ProjectionItem
            {
                Name = "NAD 1983 UTM Zone 12N",
                Projection = KnownCoordinateSystems.Projected.UtmNad1983.NAD1983UTMZone12N
            });
            cmbProjections.Items.Add(new ProjectionItem
            {
                Name = "North America Albers Equal Area Conic",
                Projection = KnownCoordinateSystems.Projected.NorthAmerica.NorthAmericaAlbersEqualAreaConic
            });
            cmbProjections.Items.Add(new ProjectionItem
            {
                Name = "USA Contiguous Lambert Conformal Conic",
                Projection = KnownCoordinateSystems.Projected.NorthAmerica.USAContiguousLambertConformalConic
            });
            cmbProjections.Items.Add(new ProjectionItem
            {
                Name = "World Cylindrical Equal Area",
                Projection = KnownCoordinateSystems.Projected.World.CylindricalEqualAreaworld
            });
            cmbProjections.Items.Add(new ProjectionItem
            {
                Name = "North Pole Azimuthal Equidistant",
                Projection = KnownCoordinateSystems.Projected.Polar.NorthPoleAzimuthalEquidistant
            });
            cmbProjections.Items.Add(new ProjectionItem
            {
                Name = "USA Contiguous Albers Equal Area Conic USGS",
                Projection = KnownCoordinateSystems.Projected.NorthAmerica.USAContiguousAlbersEqualAreaConicUSGS
            });

            if (cmbProjections.Items.Count > 0)
                cmbProjections.SelectedIndex = 0;
        }

        private void ApplyProjection()
        {
            if (cmbProjections.SelectedItem is ProjectionItem item)
            {
                var newProj = item.Projection;
                try
                {
                    // restore original projection first
                    if (_mapOrig != null)
                    {
                        foreach (var layer in _map.Layers)
                        {
                            if (_originals != null && _originals.TryGetValue(layer, out var orig))
                            {
                                if (layer is IMapFeatureLayer fl && fl.DataSet is DotSpatial.Data.IReproject fs && fs.CanReproject)
                                {
                                    fs.Reproject(orig);
                                }
                                else if (layer is IMapRasterLayer rl && rl.DataSet is DotSpatial.Data.IReproject rs && rs.CanReproject)
                                {
                                    rs.Reproject(orig);
                                }
                            }
                        }
                        _map.Projection = _mapOrig;
                    }

                    // then apply new projection
                    foreach (var layer in _map.Layers)
                    {
                        if (layer is IMapFeatureLayer fl && fl.DataSet is DotSpatial.Data.IReproject fs && fs.CanReproject)
                        {
                            if (!fs.Projection.Equals(newProj))
                                fs.Reproject(newProj);
                        }
                        else if (layer is IMapRasterLayer rl && rl.DataSet is DotSpatial.Data.IReproject rs && rs.CanReproject)
                        {
                            if (!rs.Projection.Equals(newProj))
                                rs.Reproject(newProj);
                        }
                    }

                    _map.Projection = newProj;
                    _map.ZoomToMaxExtent();
                    _map.ResetBuffer();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to set projection: {ex.Message}");
                }
            }
            Close();
        }

        private void ResetProjection()
        {
            if (_mapOrig == null) return;
            foreach (var layer in _map.Layers)
            {
                if (_originals != null && _originals.TryGetValue(layer, out var proj))
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
            _map.Projection = _mapOrig;
            _map.ZoomToMaxExtent();
            _map.ResetBuffer();
            Close();
        }

        private class ProjectionItem
        {
            public string Name { get; set; }
            public ProjectionInfo Projection { get; set; }
            public override string ToString() => Name;
        }
    }
}