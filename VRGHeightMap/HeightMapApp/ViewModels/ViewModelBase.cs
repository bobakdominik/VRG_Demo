using System.ComponentModel;

namespace HeightMapApp.ViewModels
{
    /// <summary>
    /// Base class for view models that implements INotifyPropertyChanged and IDisposable.
    /// </summary>
    internal class ViewModelBase : INotifyPropertyChanged, IDisposable
    {
        /// <summary>
        /// Notifies subscribers when a property changes.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Notifies subscribers when a property changes.
        /// </summary>
        /// <param name="propertyName">Property name</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Disposes of the view model.
        /// </summary>
        protected virtual void Dispose()
        {

        }

        /// <summary>
        /// Disposes of the view model.
        /// </summary>
        void IDisposable.Dispose()
        {
            Dispose();
        }
    }
}