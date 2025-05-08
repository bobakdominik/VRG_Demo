using HeightMapApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeightMapApp.ViewModels
{
    class CircleListingViewModel : ViewModelBase
    {
        private CircleRepository circleRepository;

        public IEnumerable<CircleListingItemViewModel> CircleListingViewModels => circleRepository.CircleListingViewModels;

        public CircleListingViewModel(CircleRepository circleRepository)
        {
            this.circleRepository = circleRepository;
        }
    }
}
