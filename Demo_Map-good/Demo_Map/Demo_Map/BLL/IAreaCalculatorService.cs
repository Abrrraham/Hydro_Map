using DotSpatial.Data;
using Demo_Map.Models;

namespace Demo_Map.BLL
{
    public interface IAreaCalculatorService
    {
        double ComputeTotal(IFeatureSet fs, string filterExpression = null);
        double ComputeByField(IFeatureSet fs, string fieldName, object value);
        double Convert(double areaInSquareMeters, AreaUnit unit);
    }
}
