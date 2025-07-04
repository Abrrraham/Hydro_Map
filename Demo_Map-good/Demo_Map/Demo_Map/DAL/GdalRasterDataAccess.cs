using DotSpatial.Data;
using DotSpatial.Data.Rasters.GdalExtension;

namespace Demo_Map.DAL
{
    public class GdalRasterDataAccess : IRasterDataAccess
    {
        public IRaster Open(string path)
        {
            return new GdalRasterProvider().Open(path) as IRaster;
        }
    }
}
