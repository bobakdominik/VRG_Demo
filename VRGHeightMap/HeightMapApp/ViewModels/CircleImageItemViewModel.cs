using HeightMapApp.Models;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;

namespace HeightMapApp.ViewModels
{
    class CircleImageItemViewModel : ViewModelBase
    {
        private readonly TwoPointCircle _selectedCircle;
        private readonly Point _centerPoint;
        private readonly Point _outlinePoint;
        private const double CHalfLineLength = 2.5;

        public TwoPointCircle TwoPointCircle => _selectedCircle;

        public double CircleX => _centerPoint.X - CircleRadius;
        public double CircleY => _centerPoint.Y - CircleRadius;
        public Brush Brush => _selectedCircle.Brush;
        public double CircleRadius => _selectedCircle.RadiusForView;
        public double CircleDiameter => CircleRadius * 2;
        public int Thickness => 1;

        public double CenterCrossX1 => _centerPoint.X - CHalfLineLength;
        public double CenterCrossY1 => _centerPoint.Y - CHalfLineLength;
        public double CenterCrossX2 => _centerPoint.X + CHalfLineLength;
        public double CenterCrossY2 => _centerPoint.Y + CHalfLineLength;

        public double OutlineCrossX1 => _outlinePoint.X - CHalfLineLength;
        public double OutlineCrossY1 => _outlinePoint.Y - CHalfLineLength;
        public double OutlineCrossX2 => _outlinePoint.X + CHalfLineLength;
        public double OutlineCrossY2 => _outlinePoint.Y + CHalfLineLength;

        public Visibility IsVisible => _selectedCircle.Visible ? Visibility.Visible : Visibility.Hidden;


        public CircleImageItemViewModel(TwoPointCircle twoPointCircle)
        {
            _selectedCircle = twoPointCircle;
            _centerPoint = new Point(twoPointCircle.CenterPoint.ViewX, twoPointCircle.CenterPoint.ViewY);
            _outlinePoint = new Point(twoPointCircle.OutlinePoint.ViewX, twoPointCircle.OutlinePoint.ViewY);
            _selectedCircle.PropertyChanged += SelectedCircle_VisibilityChanged;
        }

        private void SelectedCircle_VisibilityChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_selectedCircle.Visible))
            {
                OnPropertyChanged(nameof(IsVisible));
            }
        }

        protected override void Dispose()
        {
            _selectedCircle.PropertyChanged -= SelectedCircle_VisibilityChanged;
            base.Dispose();
        }
    }
}
