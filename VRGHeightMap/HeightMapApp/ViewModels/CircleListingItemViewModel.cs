using HeightMapApp.Commands;
using HeightMapApp.Models;
using System.Windows.Input;
using System.Windows.Media;

namespace HeightMapApp.ViewModels
{
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
            get => _selectedCircle.Visible;
            set
            {
                if (_selectedCircle.Visible != value)
                {
                    _selectedCircle.Visible = value;
                    OnPropertyChanged(nameof(IsChecked));
                }
            }
        }

        public ICommand DeleteCircleCommand { get; }

        public CircleListingItemViewModel(TwoPointCircle circle, DeleteCircleCommand deleteCircleCommand)
        {
            _selectedCircle = circle;
            DeleteCircleCommand = deleteCircleCommand;
        }

    }
}
