using HeightMapApp.Models;
using System.Collections.ObjectModel;
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

        public Point CenterPointForView => new Point(_selectedCircle.CenterPoint.ViewX, _selectedCircle.CenterPoint.ViewX);

        public double CircleX => _centerPoint.X - CircleRadius;
        public double CircleY => _centerPoint.Y - CircleRadius;
        public Color CircleColor => _selectedCircle.Color;
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


        public CircleImageItemViewModel(TwoPointCircle twoPointCircle)
        {
            _selectedCircle = twoPointCircle;
            _centerPoint = new Point(0, 0);
            _outlinePoint = new Point(twoPointCircle.OutlinePoint.ViewX - twoPointCircle.CenterPoint.ViewX,
                twoPointCircle.OutlinePoint.ViewY - twoPointCircle.CenterPoint.ViewY);

            PropertiesChanged();

            //// Example data
            //var centerPoint = new HeightMapPoint(0.5, 0.5, 1024, 1024);
            //var outlinePoint = new HeightMapPoint(0.7, 0.7, 1024, 1024);
            //var color = Colors.Red;
            //var centerPoint2 = new HeightMapPoint(0, 0, 1024, 1024);
            //var outlinePoint2 = new HeightMapPoint(0.1, 0.1, 1024, 1024);
            //var color2 = Colors.Red;
        }

        private void PropertiesChanged()
        {
            OnPropertyChanged(nameof(CenterPointForView));
            OnPropertyChanged(nameof(CircleX));
            OnPropertyChanged(nameof(CircleY));
            OnPropertyChanged(nameof(CircleColor));
            OnPropertyChanged(nameof(CircleRadius));
            OnPropertyChanged(nameof(CircleDiameter));

            OnPropertyChanged(nameof(CenterCrossX1));
            OnPropertyChanged(nameof(CenterCrossY1));
            OnPropertyChanged(nameof(CenterCrossX2));
            OnPropertyChanged(nameof(CenterCrossY2));

            OnPropertyChanged(nameof(OutlineCrossX1));
            OnPropertyChanged(nameof(OutlineCrossY1));
            OnPropertyChanged(nameof(OutlineCrossX2));
            OnPropertyChanged(nameof(OutlineCrossY2));
        }
    }
}
