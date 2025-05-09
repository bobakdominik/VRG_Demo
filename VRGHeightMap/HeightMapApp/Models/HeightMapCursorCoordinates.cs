namespace HeightMapApp.Models
{
    internal class HeightMapCursorCoordinates : HeightMapPoint
    {
        private double _onMapHeight;

        public double OnMapHeight
        {
            get
            {
                return _onMapHeight;
            }
            set
            {
                _onMapHeight = value;
                OnPropertyChanged(nameof(OnMapHeight));
            }
        }

        public HeightMapCursorCoordinates() :
            base(-1,-1,-1,-1)
        {
            _onMapHeight = -1;
        }

        public void ResetCoordinates() 
        {
            MapX = -1;
            MapY = -1;
            ViewX = -1;
            ViewY = -1;
            OnMapHeight = -1;
        }
    }
}
