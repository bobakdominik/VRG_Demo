using System.ComponentModel;

namespace HeightMapApp.Models
{
    internal class HeightMapPoint : INotifyPropertyChanged
    {
        private double _mapX;
        private double _mapY;
        private double _viewX;
        private double _viewY;

        public event PropertyChangedEventHandler? PropertyChanged;
        
        public double MapX
        {
            get
            {
                return _mapX;
            }
            set
            {
                _mapX = value;
                OnPropertyChanged(nameof(MapX));
            }
        }
        public double MapY
        {
            get
            {
                return _mapY;
            }
            set
            {
                _mapY = value;
                OnPropertyChanged(nameof(MapY));
            }
        }
        public double ViewX
        {
            get
            {
                return _viewX;
            }
            set
            {
                _viewX = value;
                OnPropertyChanged(nameof(ViewX));
            }   
        }
        
        public double ViewY
        {
            get
            {
                return _viewY;
            }
            set
            {
                _viewY = value;
                OnPropertyChanged(nameof(ViewY));
            }
        }

        public HeightMapPoint(double mapY, double mapX, int viewY, int viewX)
        {
            _mapX = mapX;
            _mapY = mapY;
            _viewX = viewX;
            _viewY = viewY;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
