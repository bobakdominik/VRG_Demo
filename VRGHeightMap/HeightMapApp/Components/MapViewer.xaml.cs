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

        public MapViewer()
        {
            InitializeComponent();
        }

        private void OnMouseEnter(object sender, MouseEventArgs e)
        {
            var normalizedCrsorPosition = NormalizeCursorPosition(e.GetPosition(this), (Grid)sender);
            ViewModel.UpdateCursorPosition(normalizedCrsorPosition.Y, normalizedCrsorPosition.X);
        }

        private void OnMouseLeave(object sender, MouseEventArgs e)
        {
            ViewModel.ResetCursorPosition();
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            var normalizedCursorPosition = NormalizeCursorPosition(e.GetPosition(this), (Grid)sender);
            ViewModel.UpdateCursorPosition(normalizedCursorPosition.Y, normalizedCursorPosition.X);
        }

        private Point NormalizeCursorPosition(Point cursorPozition, Grid grid)
        {
            var imageHeight = grid.ActualHeight;
            var imageWidth = grid.ActualWidth;
            var imageStartPoint = GetImageStartingPoint(grid);

            if (imageHeight == 0 || imageWidth == 0)
            {
                return new Point(0, 0);
            }
            else
            {
                var normalizedX = ((cursorPozition.X - imageStartPoint.X)/ imageWidth);
                var normalizedY = ((cursorPozition.Y - imageStartPoint.Y)/ imageHeight);
                return new Point(normalizedX, normalizedY);
            }
        }

        private Point GetImageStartingPoint(Grid grid)
        {
            return grid.TranslatePoint(new Point(0, 0), this);
        }
    }
}
