using HeightMapApp.Commands;
using HeightMapApp.Models;
using HeightMapTools.Models;
using System.Windows.Input;

namespace HeightMapApp.ViewModels
{
    class HeightMapMainViewModel : ViewModelBase
    {
        public MapViewerViewModel MapViewerViewModel { get; }
        public CircleListingViewModel CircleListingViewModel { get; }
        public ICommand AddCircleCommand { get; }
        public ICommand SelectDataCommand { get; }

        public HeightMapMainViewModel()
        {
            var demoHeightMap = new HeightMap(255, 255, 1, 0, 0);
            for (int r = 0; r < demoHeightMap.Rows; r++)
            {
                for (int c = 0; c < demoHeightMap.Columns; c++)
                {
                    demoHeightMap[c, r] = c;
                }
            }
            var demoViewableHeightMap = new ViewableHeightMap(demoHeightMap);

            MapViewerViewModel = new MapViewerViewModel(demoViewableHeightMap);
            CircleListingViewModel = new CircleListingViewModel();
            SelectDataCommand = new SelectDataCommand(MapViewerViewModel);
            AddCircleCommand = new AddCircleCommand();
        }
    }
}
