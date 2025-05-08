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

        public double RadiusForView
        {
            get
            {
                var xLength = Math.Max(CenterPoint.ViewX, OutlinePoint.ViewX) - Math.Min(CenterPoint.ViewX, OutlinePoint.ViewX);
                var yLength = Math.Max(CenterPoint.ViewY, OutlinePoint.ViewY) - Math.Min(CenterPoint.ViewY, OutlinePoint.ViewY);
                return Math.Sqrt(Math.Pow(xLength, 2) + Math.Pow(yLength, 2));
            }
        }

        public double RadiusForMap
        {
            get
            {
                var xLength = Math.Max(CenterPoint.MapX, OutlinePoint.MapX) - Math.Min(CenterPoint.MapX, OutlinePoint.MapX);
                var yLength = Math.Max(CenterPoint.MapY, OutlinePoint.MapY) - Math.Min(CenterPoint.MapY, OutlinePoint.MapY);
                return Math.Sqrt(Math.Pow(xLength, 2) + Math.Pow(yLength, 2));
            }
        }
        
        public TwoPointCircle(HeightMapPoint centerPoint, HeightMapPoint outlinePoint, Color color)
        {
            _centerPoint = centerPoint;
            _outlinePoint = outlinePoint;
            _color = color;
        }
        
    }
}
