using DotSpatial.Data;

namespace Demo_Map.BLL
{
    public interface IFlowDirectionService
    {
        IRaster FillPits(IRaster dem);
        int[,] ComputeInitialFlow(IRaster dem);
        int[,] ResolveFlats(IRaster dem, int[,] flow);
        void ExportFlowDirectionAsc(string path, int[,] flow);
        IRaster FlowArrayToRaster(int[,] flow, IRaster template);
    }
}
