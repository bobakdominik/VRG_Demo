using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HeightMapApp.ViewModels
{
    class HeightMapMainViewModel : ViewModelBase
    {
        public ICommand AddCircleCommand { get; }
        public ICommand SelectDataCommand { get; }
    }
}
