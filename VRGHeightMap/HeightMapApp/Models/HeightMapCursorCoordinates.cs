namespace HeightMapApp.Models
{
    /// <summary>
    /// Represents the coordinates of a cursor in a height map, including the height at that point.
    /// </summary>
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

        /// <summary>
        /// Constructor for HeightMapCursorCoordinates.
        /// </summary>
        public HeightMapCursorCoordinates() :
            base(-1,-1,-1,-1)
        {
            _onMapHeight = -1;
        }

        /// <summary>
        /// Resets the height and coordinates of the cursor to -1.
        /// </summary>
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
