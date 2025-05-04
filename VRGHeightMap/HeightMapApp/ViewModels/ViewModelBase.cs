using System.ComponentModel;

namespace HeightMapApp.ViewModels
{
    internal class ViewModelBase : INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void Dispose()
        {

        }

        void IDisposable.Dispose()
        {
            Dispose();
        }
    }
}