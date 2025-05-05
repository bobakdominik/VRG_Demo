using HeightMapApp.Models;
using HeightMapApp.ViewModels;
using HeightMapTools.Tools;

namespace HeightMapApp.Commands
{
    internal class SelectDataCommand : CommandBase
    {
        private MapViewerViewModel _mapViewerViewModel;
        public SelectDataCommand(MapViewerViewModel mapViewerViewModel)
        {
            _mapViewerViewModel = mapViewerViewModel;
        }

        public override void Execute(object? parameter)
        {
            var heightMap = HeightMapFileReader.ReadHeihtMapFromFile("D:\\Development\\c#\\VRG_Demo\\heightmap_ASCII");
            var viewableHeightMap = new ViewableHeightMap(heightMap);
            _mapViewerViewModel.SetHeightMap(viewableHeightMap);
        }
    }
}
