using HeightMapApp.Models;
using HeightMapApp.ViewModels;
using HeightMapTools.Tools;
using Microsoft.Win32;
using System.Windows;

namespace HeightMapApp.Commands
{
    internal class SelectDataCommand : CommandBase
    {
        private MapViewerViewModel _mapViewerViewModel;
        public SelectDataCommand(MapViewerViewModel mapViewerViewModel)
        {
            _mapViewerViewModel = mapViewerViewModel;
        }

        public override void Execute(object? parameter)
        {
            var filePath = GetFilePathFromDialog();
            if (string.IsNullOrEmpty(filePath))
            {
                return;
            }
            try
            {
                var heightMap = HeightMapFileReader.ReadHeihtMapFromFile(filePath);
                var viewableHeightMap = new ViewableHeightMap(heightMap);
                _mapViewerViewModel.SetHeightMap(viewableHeightMap);
            }
            catch (Exception ex)
            {
                DisplayErrorMessage($"Error reading height map file: {filePath}");
            }
        }

        private string GetFilePathFromDialog()
        {
            var openFileDialog = new OpenFileDialog()
            {
                Title = "Select a Height Map File",
                InitialDirectory = "C:\\",
                Multiselect = false
            };
            if (openFileDialog.ShowDialog() == true)
            {
                return openFileDialog.FileName;
            }
            return string.Empty;
        }

        private void DisplayErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
