using HeightMapApp.Services;

namespace HeightMapApp.ViewModels
{
    /// <summary>
    /// ViewModel for the circle listing, responsible for managing the list of circles.
    /// </summary>
    class CircleListingViewModel : ViewModelBase
    {
        private CircleRepository circleRepository;
        public IEnumerable<CircleListingItemViewModel> CircleListingViewModels => circleRepository.CircleListingViewModels;

        /// <summary>
        /// Initializes a new instance of the <see cref="CircleListingViewModel"/> class.
        /// </summary>
        /// <param name="circleRepository"></param>
        public CircleListingViewModel(CircleRepository circleRepository)
        {
            this.circleRepository = circleRepository;
        }
    }
}
