using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DotSpatial.Data;

namespace Demo_Map.Services
{
    public enum AreaUnit
    {
        SquareMeters,
        SquareKilometers,
        Hectares
    }

    public static class AreaCalculator
    {
        public static double ComputeTotal(IFeatureSet fs, string filterExpression = null)
        {
            if (fs == null) throw new ArgumentNullException(nameof(fs));
            IEnumerable<IFeature> features = fs.Features;
            if (!string.IsNullOrWhiteSpace(filterExpression))
            {
                var rows = fs.DataTable.Select(filterExpression);
                var rowSet = new HashSet<DataRow>(rows);
                features = features.Where(f => rowSet.Contains(f.DataRow));
            }

            double area = 0;
            foreach (var feature in features)
            {
                area += feature.Area();
            }
            return area;
        }

        public static double ComputeByField(IFeatureSet fs, string fieldName, object value)
        {
            if (fs == null) throw new ArgumentNullException(nameof(fs));
            if (string.IsNullOrEmpty(fieldName)) throw new ArgumentNullException(nameof(fieldName));

            double area = 0;
            foreach (var feature in fs.Features)
            {
                if (Equals(feature.DataRow[fieldName], value))
                {
                    area += feature.Area();
                }
            }
            return area;
        }

        public static double Convert(double areaInSquareMeters, AreaUnit unit)
        {
            switch (unit)
            {
                case AreaUnit.SquareKilometers:
                    return areaInSquareMeters / 1_000_000.0;
                case AreaUnit.Hectares:
                    return areaInSquareMeters / 10_000.0;
                default:
                    return areaInSquareMeters;
            }
        }
    }
}