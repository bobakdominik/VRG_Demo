using HeightMapApp.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HeightMapApp.Components
{
    /// <summary>
    /// Interaction logic for MapView.xaml
    /// </summary>
    public partial class MapViewer : UserControl
    {
        private MapViewerViewModel ViewModel => (MapViewerViewModel)DataContext;
        private const int cDefaultImageSize = 1024;
        public MapViewer()
        {
            InitializeComponent();
            DataContext = new MapViewerViewModel();
        }

        private void OnMouseEnter(object sender, MouseEventArgs e)
        {
            var normalizedCrsorPosition = NormalizeCursorPosition(e.GetPosition(this), (Image)sender);
            ViewModel.UpdateCursorPosition((int)normalizedCrsorPosition.Y, (int)normalizedCrsorPosition.X);
        }

        private void OnMouseLeave(object sender, MouseEventArgs e)
        {
            ViewModel.ResetCursorPosition();
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            var normalizedCrsorPosition = NormalizeCursorPosition(e.GetPosition(this), (Image)sender);
            ViewModel.UpdateCursorPosition((int)normalizedCrsorPosition.Y, (int)normalizedCrsorPosition.X);
        }

        private Point NormalizeCursorPosition(Point cursorPozition, Image image)
        {
            var imageHeight = image.ActualHeight;
            var imageWidth = image.ActualWidth;
            var imageStartPoint = GetImageStartingPoint(image);

            if (imageHeight == 0 || imageWidth == 0)
            {
                return new Point(0, 0);
            }
            else
            {
                var normalizedX = ((cursorPozition.X - imageStartPoint.X)/ imageWidth) * cDefaultImageSize;
                var normalizedY = ((cursorPozition.Y - imageStartPoint.Y)/ imageHeight);
                var invertedNormalizedY = (1 - normalizedY) * cDefaultImageSize;
                return new Point(normalizedX, invertedNormalizedY);
            }
        }

        private Point GetImageStartingPoint(Image image)
        {
            return image.TranslatePoint(new Point(0, 0), this);
        }
    }
}
