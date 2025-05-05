using HeightMapTools.Models;
using HeightMapTools.Tools;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace HeightMapApp.Models
{
    internal class ViewableHeightMap
    {
        private readonly HeightMap _heightMap;
        private readonly BitmapImage _heightMapImage;
        public HeightMap HeightMap => _heightMap;
        public BitmapImage HeightMapImage => _heightMapImage;
        
        public ViewableHeightMap(HeightMap heightMap)
        {
            _heightMap = heightMap;
            _heightMapImage = CreateHeightMapImage();
        }

        private BitmapImage CreateHeightMapImage()
        {
            Bitmap bitmap = HeightMapImageGenerator.CreateBitMapFromHeightMap(HeightMap);
            using (var memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
                memory.Position = 0;

                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.StreamSource = memory;
                bitmapImage.EndInit();
                bitmapImage.Freeze();
                return bitmapImage;
            }
        }

    }
}
