namespace HeightMapApp.Models
{
    internal class HeightMapPoint
    {
        private readonly int _parentWidth;
        private readonly int _parentHeight;
        private readonly double _relativeX;
        private readonly double _relativeY;

        public int X => (int)(_relativeX * _parentWidth);
        public int Y => (int)(_relativeY * _parentHeight);

        public int XDisplay => X;
        public int YDisplay => (int)((1 - _relativeY) * _parentHeight);

        public HeightMapPoint(double relativeX, double relativeY, int parentWidth, int parentHeight)
        {
            _relativeX = relativeX;
            _relativeY = relativeY;
            _parentWidth = parentWidth;
            _parentHeight = parentHeight;
        }
    }
}
