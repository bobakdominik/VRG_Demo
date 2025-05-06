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
            MapViewerViewModel = new MapViewerViewModel();
            CircleListingViewModel = new CircleListingViewModel();
            SelectDataCommand = new SelectDataCommand(MapViewerViewModel);
            AddCircleCommand = new AddCircleCommand();
        }
    }
}
