using HeightMapApp.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

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

        private void ImageGrid_OnMouseEnter(object sender, MouseEventArgs e)
        {
            var grid = (Grid)sender;
            var normalizedCrsorPosition = NormalizeCursorPosition(e.GetPosition(this), grid);
            ViewModel.UpdateCursorPosition(normalizedCrsorPosition.Y, normalizedCrsorPosition.X, grid.ActualHeight, grid.ActualWidth);
        }

        private void ImageGrid_OnMouseMove(object sender, MouseEventArgs e)
        {
            var grid = (Grid)sender;
            var normalizedCursorPosition = NormalizeCursorPosition(e.GetPosition(this), grid);
            ViewModel.UpdateCursorPosition(normalizedCursorPosition.Y, normalizedCursorPosition.X, grid.ActualHeight, grid.ActualWidth);
        }

        private void ImageGrid_OnMouseLeave(object sender, MouseEventArgs e)
        {
            ViewModel.ResetCursorPosition();
        }
        private void ImageGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ViewModel.SaveCursorPosition();
        }

        private void Canvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var canvas = (Canvas)sender;
            canvas.Clip = new RectangleGeometry
            {
                Rect = new Rect(0, 0, canvas.ActualWidth, canvas.ActualHeight)
            };
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
