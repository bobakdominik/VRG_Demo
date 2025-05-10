using HeightMapApp.Commands;
using HeightMapApp.Models;
using HeightMapApp.ViewModels;
using System.Collections.ObjectModel;

namespace HeightMapApp.Services
{
    /// <summary>
    /// Repository for managing circles in the application.
    /// </summary>
    internal class CircleRepository
    {
        private readonly ObservableCollection<TwoPointCircle> _circles;
        private readonly ObservableCollection<CircleImageItemViewModel> _circleImageItemViewModels;
        private readonly ObservableCollection<CircleListingItemViewModel> _circleListingItemViewModels;

        public IEnumerable<TwoPointCircle> Circles => _circles;
        public IEnumerable<CircleImageItemViewModel> CircleImageViewModels => _circleImageItemViewModels;
        public IEnumerable<CircleListingItemViewModel> CircleListingViewModels => _circleListingItemViewModels;

        /// <summary>
        /// Constructor for CircleRepository.
        /// </summary>
        public CircleRepository()
        {
            _circles = new ObservableCollection<TwoPointCircle>();
            _circleImageItemViewModels = new ObservableCollection<CircleImageItemViewModel>();
            _circleListingItemViewModels = new ObservableCollection<CircleListingItemViewModel>();
        }

        /// <summary>
        /// Adds a circle to the repository and creates corresponding view models.
        /// </summary>
        /// <param name="circle">Circle</param>
        public void AddCircle(TwoPointCircle circle)
        {
            if (!_circles.Contains(circle))
            {
                _circles.Add(circle);
                _circleImageItemViewModels.Add(new CircleImageItemViewModel(circle));
                _circleListingItemViewModels.Add(new CircleListingItemViewModel(circle, new DeleteCircleCommand(this)));
            }            
        }

        /// <summary>
        /// Removes a circle from the repository and its corresponding view models.
        /// </summary>
        /// <param name="circle"></param>
        public void RemoveCircle(TwoPointCircle circle)
        {
            if (_circles.Remove(circle))
            {
                var imageVM = _circleImageItemViewModels.FirstOrDefault(c => c.TwoPointCircle == circle);
                if (imageVM != null)
                {
                    _circleImageItemViewModels.Remove(imageVM);
                }
                var listingVM = _circleListingItemViewModels.FirstOrDefault(c => c.TwoPointCircle == circle);
                if (listingVM != null)
                {
                    _circleListingItemViewModels.Remove(listingVM);
                }
            }
        }

        /// <summary>
        /// Clears all circles and their corresponding view models from the repository.
        /// </summary>
        public void Clear()
        {
            _circles.Clear();
            _circleImageItemViewModels.Clear();
            _circleListingItemViewModels.Clear();
        }
    }
}
