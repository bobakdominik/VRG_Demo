namespace HeightMapApp.Models
{
    internal class HeightMapPoint
    {
        private readonly double _mapX;
        private readonly double _mapY;
        private readonly double _viewX;
        private readonly double _viewY;

        public double MapX => _mapX;
        public double MapY => _mapY;
        public double ViewX => _viewX;
        public double ViewY => _viewY;

        public HeightMapPoint(double mapY, double mapX, int viewY, int viewX)
        {
            _mapX = mapX;
            _mapY = mapY;
            _viewX = viewX;
            _viewY = viewY;
        }
    }
}
