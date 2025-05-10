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
        private readonly double _minScale = 0.1;
        private readonly double _maxScale = 8.0;
        private bool _isPanning = false;
        private bool _captureCursorPosition = false;
        private Point _panStartCursorPosition;
        private Point _panOriginGridPosition;
        private MapViewerViewModel ViewModel => (MapViewerViewModel)DataContext;

        public MapViewer()
        {
            InitializeComponent();
        }

        private void ImageGrid_OnMouseEnter(object sender, MouseEventArgs e)
        {
            _captureCursorPosition = true;
        }

        private void ImageGrid_OnMouseMove(object sender, MouseEventArgs e)
        {
            if (_isPanning)
            {
                var current = e.GetPosition(ImageScrollViewer);
                var delta = current - _panStartCursorPosition;

                ImageGridTranslateTransform.X = _panOriginGridPosition.X + delta.X;
                ImageGridTranslateTransform.Y = _panOriginGridPosition.Y + delta.Y;
            }

            if (_captureCursorPosition)
            {
                var normalizedCursorPosition = NormalizeCursorPosition(e);
                ViewModel.UpdateCursorPosition(normalizedCursorPosition.Y, normalizedCursorPosition.X, ImageGrid.ActualHeight, ImageGrid.ActualWidth);
            }            
        }

        private void ImageGrid_OnMouseLeave(object sender, MouseEventArgs e)
        {
            _captureCursorPosition = false;
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

        private Point NormalizeCursorPosition(MouseEventArgs e)
        {
            var cursorPosition = e.GetPosition(ImageGrid);
            var normalizedX = cursorPosition.X / ImageGrid.ActualWidth;
            var normalizedY = cursorPosition.Y / ImageGrid.ActualHeight;
            
            normalizedX = Math.Clamp(normalizedX, 0, 1);
            normalizedY = Math.Clamp(normalizedY, 0, 1);

            // Sometimes the cursor position is 1 (mostly right bottom corner during zoom),
            // which causes problems with the calculations
            if (normalizedX == 1 || normalizedY == 1)
            {
                return new Point(0, 0);
            }
            return new Point(normalizedX, normalizedY);
        }

        private void ImageScrollViewer_OnMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if ((e.Delta > 0 && ImageGridScaleTransform.ScaleX < _maxScale && ImageGridScaleTransform.ScaleY < _maxScale) ||
                (e.Delta < 0 && ImageGridScaleTransform.ScaleX > _minScale && ImageGridScaleTransform.ScaleY > _minScale))
            {
                var zoom = e.Delta > 0 ? 1.1 : 0.9;
                var cursorPosition = e.GetPosition(ImageGrid);

                ImageGridScaleTransform.ScaleX *= zoom;
                ImageGridScaleTransform.ScaleY *= zoom;

                ImageGridScaleTransform.CenterX *= zoom;
                ImageGridScaleTransform.CenterY *= zoom;

                ImageGridTranslateTransform.X = (1 - zoom) * cursorPosition.X + zoom * ImageGridTranslateTransform.X;
                ImageGridTranslateTransform.Y = (1 - zoom) * cursorPosition.Y + zoom * ImageGridTranslateTransform.Y;
            }
        }

        private void ImageScrollViewer_OnMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            _isPanning = true;
            _panStartCursorPosition = e.GetPosition(this);
            _panOriginGridPosition = new Point(ImageGridTranslateTransform.X, ImageGridTranslateTransform.Y);
            Cursor = Cursors.Hand;
            ImageScrollViewer.CaptureMouse();
        }

        private void ImageScrollViewer_OnMouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            _isPanning = false;
            Cursor = Cursors.Arrow;
            ImageScrollViewer.ReleaseMouseCapture();
        }

        private void ImageScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ImageScrollViewer_OnMouseWheel( sender, e);
            e.Handled = true;
        }
    }
}
