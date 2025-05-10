using HeightMapApp.Commands;
using HeightMapApp.Models;
using System.Windows.Input;
using System.Windows.Media;

namespace HeightMapApp.ViewModels
{
    /// <summary>
    /// ViewModel for a circle listing item in the UI.
    /// </summary>
    class CircleListingItemViewModel : ViewModelBase
    {
        private readonly TwoPointCircle _selectedCircle;

        public TwoPointCircle TwoPointCircle => _selectedCircle;
        public string CircleName => _selectedCircle.Name;
        public string CircleCenterDescription => string.Format($"Center: [{_selectedCircle.CenterPoint.MapX:0.##}; {_selectedCircle.CenterPoint.MapY:0.##}]");
        public string CircleRadiusDescription => string.Format($"Radius: {_selectedCircle.RadiusForMap:0.##}");
        public Brush CircleBrush => _selectedCircle.Brush;
        public bool IsChecked
        {
            get => _selectedCircle.IsVisible;
            set
            {
                if (_selectedCircle.IsVisible != value)
                {
                    _selectedCircle.IsVisible = value;
                    OnPropertyChanged(nameof(IsChecked));
                }
            }
        }
        public ICommand DeleteCircleCommand { get; }

        /// <summary>
        /// Constructor for CircleListingItemViewModel.
        /// </summary>
        /// <param name="circle">Circle created on map</param>
        /// <param name="deleteCircleCommand">Command for circle deletion</param>
        public CircleListingItemViewModel(TwoPointCircle circle, DeleteCircleCommand deleteCircleCommand)
        {
            _selectedCircle = circle;
            DeleteCircleCommand = deleteCircleCommand;
        }

    }
}
