using HeightMapApp.ViewModels;
using System.Windows.Controls;

namespace HeightMapApp.Views
{
    /// <summary>
    /// Interaction logic for HeightMapMainView.xaml
    /// </summary>
    public partial class HeightMapMainView : UserControl
    {
        public HeightMapMainView()
        {
            InitializeComponent();
            DataContext = new HeightMapMainViewModel();
        }
    }
}
