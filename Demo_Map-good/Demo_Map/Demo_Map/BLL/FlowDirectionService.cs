using System;
using System.IO;
using System.Linq;
using DotSpatial.Data;

namespace Demo_Map.BLL
{
    public class FlowDirectionService : IFlowDirectionService
    {
        private static readonly int[] dr = { 0, 1, 1, 1, 0, -1, -1, -1 };
        private static readonly int[] dc = { 1, 1, 0, -1, -1, -1, 0, 1 };
        private static readonly int[] code = { 1, 2, 4, 8, 16, 32, 64, 128 };

        private double[,] RasterToArray(IRaster raster)
        {
            int rows = raster.NumRows;
            int cols = raster.NumColumns;
            var arr = new double[rows, cols];
            for (int r = 0; r < rows; r++)
                for (int c = 0; c < cols; c++)
                    arr[r, c] = raster.Value[r, c];
            return arr;
        }

        private IRaster CreateLike(IRaster template, string filename, Type dataType)
        {
            IRaster r = Raster.CreateRaster(filename, null,
                template.NumColumns, template.NumRows, 1, dataType, new string[] { });
            r.Bounds = template.Bounds.Copy();
            r.NoDataValue = template.NoDataValue;
            r.Projection = template.Projection;
            return r;
        }

        public IRaster FillPits(IRaster dem)
        {
            int rows = dem.NumRows;
            int cols = dem.NumColumns;
            double[,] elev = RasterToArray(dem);
            bool changed = true;
            while (changed)
            {
                changed = false;
                for (int r = 1; r < rows - 1; r++)
                    for (int c = 1; c < cols - 1; c++)
                    {
                        double curr = elev[r, c];
                        double minN = new[]
                        {
                            elev[r - 1, c], elev[r + 1, c], elev[r, c - 1], elev[r, c + 1],
                            elev[r - 1, c - 1], elev[r - 1, c + 1], elev[r + 1, c - 1], elev[r + 1, c + 1]
                        }.Min();
                        if (curr < minN)
                        {
                            elev[r, c] = minN;
                            changed = true;
                        }
                    }
            }
            string path = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + "_fill.bgd");
            IRaster result = CreateLike(dem, path, typeof(double));
            for (int r = 0; r < rows; r++)
                for (int c = 0; c < cols; c++)
                    result.Value[r, c] = elev[r, c];
            result.Save();
            return result;
        }

        public int[,] ComputeInitialFlow(IRaster dem)
        {
            int rows = dem.NumRows;
            int cols = dem.NumColumns;
            double[,] elev = RasterToArray(dem);
            var flow = new int[rows, cols];
            for (int r = 1; r < rows - 1; r++)
                for (int c = 1; c < cols - 1; c++)
                {
                    double z0 = elev[r, c];
                    double maxSlope = 0;
                    int dir = 0;
                    for (int i = 0; i < 8; i++)
                    {
                        int nr = r + dr[i], nc = c + dc[i];
                        double dz = z0 - elev[nr, nc];
                        double dist = (i % 2 == 0) ? 1.0 : Math.Sqrt(2);
                        double slope = dz / dist;
                        if (slope > maxSlope)
                        {
                            maxSlope = slope;
                            dir = code[i];
                        }
                    }
                    flow[r, c] = dir;
                }
            return flow;
        }

        public int[,] ResolveFlats(IRaster dem, int[,] flow)
        {
            int rows = dem.NumRows;
            int cols = dem.NumColumns;
            double[,] elev = RasterToArray(dem);
            int[,] flatLabels = new int[rows, cols];
            int label = 0;
            for (int r = 1; r < rows - 1; r++)
                for (int c = 1; c < cols - 1; c++)
                {
                    if (flow[r, c] == 0 && flatLabels[r, c] == 0)
                    {
                        label++;
                        var queue = new System.Collections.Generic.Queue<(int,int)>();
                        queue.Enqueue((r, c));
                        flatLabels[r, c] = label;
                        while (queue.Count > 0)
                        {
                            var cell = queue.Dequeue();
                            for (int i = 0; i < 8; i++)
                            {
                                int nr = cell.Item1 + dr[i], nc = cell.Item2 + dc[i];
                                if (nr < 1 || nr >= rows - 1 || nc < 1 || nc >= cols - 1) continue;
                                if (flow[nr, nc] == 0 && flatLabels[nr, nc] == 0)
                                {
                                    flatLabels[nr, nc] = label;
                                    queue.Enqueue((nr, nc));
                                }
                            }
                        }
                    }
                }

            for (int id = 1; id <= label; id++)
            {
                var cells = new System.Collections.Generic.List<(int,int)>();
                for (int r = 1; r < rows - 1; r++)
                    for (int c = 1; c < cols - 1; c++)
                        if (flatLabels[r, c] == id)
                            cells.Add((r, c));

                var distLow = new int[rows, cols];
                var qLow = new System.Collections.Generic.Queue<(int,int)>();
                foreach (var cell in cells)
                {
                    int r = cell.Item1, c = cell.Item2;
                    bool edge = false;
                    for (int i = 0; i < 8; i++)
                    {
                        int nr = r + dr[i], nc = c + dc[i];
                        if (flow[nr, nc] != 0) { edge = true; break; }
                    }
                    if (edge)
                    {
                        distLow[r, c] = 1;
                        qLow.Enqueue(cell);
                    }
                }
                while (qLow.Count > 0)
                {
                    var cell = qLow.Dequeue();
                    int d = distLow[cell.Item1, cell.Item2];
                    for (int i = 0; i < 8; i++)
                    {
                        int nr = cell.Item1 + dr[i], nc = cell.Item2 + dc[i];
                        if (flatLabels[nr, nc] == id && distLow[nr, nc] == 0)
                        {
                            distLow[nr, nc] = d + 1;
                            qLow.Enqueue((nr, nc));
                        }
                    }
                }

                var distHigh = new int[rows, cols];
                var qHigh = new System.Collections.Generic.Queue<(int,int)>();
                foreach (var cell in cells)
                {
                    int r = cell.Item1, c = cell.Item2;
                    bool edge = false;
                    for (int i = 0; i < 8; i++)
                    {
                        int nr = r + dr[i], nc = c + dc[i];
                        if (elev[nr, nc] > elev[r, c]) { edge = true; break; }
                    }
                    if (edge)
                    {
                        distHigh[r, c] = 1;
                        qHigh.Enqueue(cell);
                    }
                }
                while (qHigh.Count > 0)
                {
                    var cell = qHigh.Dequeue();
                    int d = distHigh[cell.Item1, cell.Item2];
                    for (int i = 0; i < 8; i++)
                    {
                        int nr = cell.Item1 + dr[i], nc = cell.Item2 + dc[i];
                        if (flatLabels[nr, nc] == id && distHigh[nr, nc] == 0)
                        {
                            distHigh[nr, nc] = d + 1;
                            qHigh.Enqueue((nr, nc));
                        }
                    }
                }

                int maxHigh = cells.Max(t => distHigh[t.Item1, t.Item2]);

                foreach (var cell in cells)
                {
                    int r = cell.Item1, c = cell.Item2;
                    int baseVal = distLow[r, c] + (maxHigh - distHigh[r, c]);
                    int bestVal = baseVal, bestDir = 0;
                    for (int i = 0; i < 8; i++)
                    {
                        int nr = r + dr[i], nc = c + dc[i];
                        if (flatLabels[nr, nc] != id) continue;
                        int val = distLow[nr, nc] + (maxHigh - distHigh[nr, nc]);
                        if (val > bestVal)
                        {
                            bestVal = val;
                            bestDir = code[i];
                        }
                    }
                    if (bestDir != 0) flow[r, c] = bestDir;
                }
            }

            return flow;
        }

        public void ExportFlowDirectionAsc(string path, int[,] flow)
        {
            int rows = flow.GetLength(0);
            int cols = flow.GetLength(1);
            using (var sw = new StreamWriter(path))
            {
                sw.WriteLine("ncols " + cols);
                sw.WriteLine("nrows " + rows);
                sw.WriteLine("xllcorner 0");
                sw.WriteLine("yllcorner 0");
                sw.WriteLine("cellsize 1");
                sw.WriteLine("NODATA_value -9999");
                for (int r = 0; r < rows; r++)
                {
                    for (int c = 0; c < cols; c++)
                    {
                        sw.Write(flow[r, c]);
                        if (c < cols - 1) sw.Write(' ');
                    }
                    sw.WriteLine();
                }
            }
        }

        public IRaster FlowArrayToRaster(int[,] flow, IRaster template)
        {
            string path = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + "_flow.bgd");
            IRaster r = CreateLike(template, path, typeof(int));
            int rows = template.NumRows;
            int cols = template.NumColumns;
            r.NoDataValue = -9999;
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    r.Value[i, j] = flow[i, j];
            r.Save();
            return r;
        }
    }
}
