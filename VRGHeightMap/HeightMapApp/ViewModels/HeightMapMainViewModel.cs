using HeightMapApp.Commands;
using HeightMapApp.Models;
using HeightMapApp.Services;
using HeightMapTools.Tools;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace HeightMapApp.ViewModels
{
    class HeightMapMainViewModel : ViewModelBase
    {
        private readonly CircleCreator _circleCreator;

        public MapViewerViewModel MapViewerViewModel { get; }
        public CircleListingViewModel CircleListingViewModel { get; }
        public CircleRepository CircleRepository { get; }
        public ICommand AddCircleCommand { get; }
        public ICommand SelectDataCommand { get; }
        public ICommand CancelCircleCreationCommand { get; }

        public Visibility CancelButtonVisibility => _circleCreator.IsCreatingCircle ? Visibility.Visible : Visibility.Hidden;

        public HeightMapMainViewModel()
        {
            CircleRepository = new CircleRepository();
            _circleCreator = new CircleCreator(CircleRepository);
            _circleCreator.PropertyChanged += CircleCreator_PropertyChanged;

            MapViewerViewModel = new MapViewerViewModel(CircleRepository, _circleCreator);
            CircleListingViewModel = new CircleListingViewModel(CircleRepository);

            SelectDataCommand = new SelectDataCommand(MapViewerViewModel);
            AddCircleCommand = new AddCircleCommand(_circleCreator);
            CancelCircleCreationCommand = new CancelCircleCreationCommand(_circleCreator);

            //CreateDemoMap();
            //CreateDemoCricles();
        }

        private void CircleCreator_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_circleCreator.IsCreatingCircle))
            {
                OnPropertyChanged(nameof(CancelButtonVisibility));
            }
        }

        protected override void Dispose()
        {
            _circleCreator.PropertyChanged -= CircleCreator_PropertyChanged;
            base.Dispose();
        }

        private void CreateDemoMap()
        {
            var heightMap = HeightMapFileReader.ReadHeihtMapFromFile("D:\\Development\\c#\\VRG_Demo\\heightmap_ASCII");
            var viewableHeightMap = new ViewableHeightMap(heightMap);
            MapViewerViewModel.SetHeightMap(viewableHeightMap);
        }

        private void CreateDemoCricles()
        {
            var circle1 = new TwoPointCircle("C1", new HeightMapPoint(800, 800, 400, 400), new HeightMapPoint(800, 800, 600, 600), System.Windows.Media.Brushes.Red);
            var circle2 = new TwoPointCircle("C2", new HeightMapPoint(1023, 1023, 799, 799), new HeightMapPoint(973, 973, 750, 750), System.Windows.Media.Brushes.Blue);
            var circle3 = new TwoPointCircle("C3", new HeightMapPoint(1023, 1023, 0, 0), new HeightMapPoint(973, 973, -75, -75), System.Windows.Media.Brushes.Orange);
            var circle4 = new TwoPointCircle("C4", new HeightMapPoint(1023, 1023, 799, 0), new HeightMapPoint(973, 973, 700, 100), System.Windows.Media.Brushes.Snow);
            var circle5 = new TwoPointCircle("C5", new HeightMapPoint(1023, 1023, 0, 799), new HeightMapPoint(973, 973, 125, 750), System.Windows.Media.Brushes.Yellow);
            CircleRepository.AddCircle(circle1);
            CircleRepository.AddCircle(circle2);
            CircleRepository.AddCircle(circle3);
            CircleRepository.AddCircle(circle4);
            CircleRepository.AddCircle(circle5);
        }
    }
}
