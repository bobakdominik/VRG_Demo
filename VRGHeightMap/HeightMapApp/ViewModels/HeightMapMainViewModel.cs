using HeightMapApp.Commands;
using HeightMapApp.Models;
using HeightMapApp.Services;
using HeightMapTools.Tools;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace HeightMapApp.ViewModels
{
    /// <summary>
    /// ViewModel for the main view of the height map application.
    /// </summary>
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

        /// <summary>
        /// Initializes a new instance of the <see cref="HeightMapMainViewModel"/> class.
        /// </summary>
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
    }
}
