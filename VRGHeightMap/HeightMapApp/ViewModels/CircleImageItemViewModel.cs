using HeightMapApp.Models;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;

namespace HeightMapApp.ViewModels
{
    class CircleImageItemViewModel : ViewModelBase
    {
        private readonly TwoPointCircle _selectedCircle;
        private const double CHalfLineLength = 2.5;

        public TwoPointCircle TwoPointCircle => _selectedCircle;

        public double CircleX => _selectedCircle.CenterPoint.ViewX - CircleRadius;
        public double CircleY => _selectedCircle.CenterPoint.ViewY - CircleRadius;
        public Brush Brush => _selectedCircle.Brush;
        public double CircleRadius => _selectedCircle.RadiusForView;
        public double CircleDiameter => CircleRadius * 2;
        public int Thickness => 1;

        public double CenterCrossX1 => _selectedCircle.CenterPoint.ViewX - CHalfLineLength;
        public double CenterCrossY1 => _selectedCircle.CenterPoint.ViewY - CHalfLineLength;
        public double CenterCrossX2 => _selectedCircle.CenterPoint.ViewX + CHalfLineLength;
        public double CenterCrossY2 => _selectedCircle.CenterPoint.ViewY + CHalfLineLength;

        public double OutlineCrossX1 => _selectedCircle.OutlinePoint.ViewX - CHalfLineLength;
        public double OutlineCrossY1 => _selectedCircle.OutlinePoint.ViewY - CHalfLineLength;
        public double OutlineCrossX2 => _selectedCircle.OutlinePoint.ViewX + CHalfLineLength;
        public double OutlineCrossY2 => _selectedCircle.OutlinePoint.ViewY + CHalfLineLength;

        public Visibility IsVisible => _selectedCircle.Visible ? Visibility.Visible : Visibility.Hidden;


        public CircleImageItemViewModel(TwoPointCircle twoPointCircle)
        {
            _selectedCircle = twoPointCircle;

            _selectedCircle.PropertyChanged += SelectedCircle_VisibilityChanged;
            _selectedCircle.CenterPoint.PropertyChanged += CenterPoint_PropertyChanged;
            _selectedCircle.OutlinePoint.PropertyChanged += OutlinePoint_PropertyChanged;
        }

        private void CenterPoint_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(nameof(CircleX));
            OnPropertyChanged(nameof(CircleY));
            OnPropertyChanged(nameof(CircleRadius));
            OnPropertyChanged(nameof(CircleDiameter));

            OnPropertyChanged(nameof(CenterCrossX1));
            OnPropertyChanged(nameof(CenterCrossY1));
            OnPropertyChanged(nameof(CenterCrossX2));
            OnPropertyChanged(nameof(CenterCrossY2));
        }

        private void OutlinePoint_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(nameof(CircleX));
            OnPropertyChanged(nameof(CircleY));
            OnPropertyChanged(nameof(CircleRadius));
            OnPropertyChanged(nameof(CircleDiameter));

            OnPropertyChanged(nameof(OutlineCrossX1));
            OnPropertyChanged(nameof(OutlineCrossY1));
            OnPropertyChanged(nameof(OutlineCrossX2));
            OnPropertyChanged(nameof(OutlineCrossY2));
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
            _selectedCircle.CenterPoint.PropertyChanged -= CenterPoint_PropertyChanged;
            _selectedCircle.OutlinePoint.PropertyChanged -= OutlinePoint_PropertyChanged;
            base.Dispose();
        }
    }
}
