using DotSpatial.Data;

namespace Demo_Map.DAL
{
    public interface IRasterDataAccess
    {
        IRaster Open(string path);
    }
}
