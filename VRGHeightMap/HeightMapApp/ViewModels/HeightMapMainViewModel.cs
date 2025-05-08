using HeightMapApp.Commands;
using HeightMapApp.Models;
using HeightMapApp.Services;
using HeightMapTools.Tools;
using System.Windows.Input;

namespace HeightMapApp.ViewModels
{
    class HeightMapMainViewModel : ViewModelBase
    {
        public MapViewerViewModel MapViewerViewModel { get; }
        public CircleListingViewModel CircleListingViewModel { get; }
        public CircleRepository CircleRepository { get; }
        public ICommand AddCircleCommand { get; }
        public ICommand SelectDataCommand { get; }

        public HeightMapMainViewModel()
        {
            CircleRepository = new CircleRepository();
            MapViewerViewModel = new MapViewerViewModel(CircleRepository);
            CircleListingViewModel = new CircleListingViewModel(CircleRepository);
            SelectDataCommand = new SelectDataCommand(MapViewerViewModel);
            AddCircleCommand = new AddCircleCommand();
        }
    }
}
