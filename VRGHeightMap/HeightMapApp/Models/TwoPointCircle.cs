using System.Windows.Media;

namespace HeightMapApp.Models
{
    class TwoPointCircle
    {
        private readonly HeightMapPoint _centerPoint;
        private readonly HeightMapPoint _outlinePoint;
        private readonly Color _color;

        public HeightMapPoint CenterPoint => _centerPoint;
        public HeightMapPoint OutlinePoint => _outlinePoint;
        public Color Color => _color;

        public TwoPointCircle(HeightMapPoint centerPoint, HeightMapPoint outlinePoint, Color color)
        {
            _centerPoint = centerPoint;
            _outlinePoint = outlinePoint;
            _color = color;
        }

        public double Radius
        {
            get
            {
                var xLength = Math.Max(CenterPoint.X, OutlinePoint.X) - Math.Min(CenterPoint.X, OutlinePoint.X);
                var yLength = Math.Max(CenterPoint.Y, OutlinePoint.Y) - Math.Min(CenterPoint.Y, OutlinePoint.Y);
                return Math.Sqrt(Math.Pow(xLength, 2) + Math.Pow(yLength, 2));
            }
        }
    }
}
