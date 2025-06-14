﻿using HeightMapTools.Models;
using HeightMapTools.Tools;
using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;

namespace HeightMapApp.Models
{
    /// <summary>
    /// Represents a viewable height map object with an associated image.
    /// </summary>
    internal class ViewableHeightMap
    {
        private readonly HeightMap _heightMap;
        private readonly BitmapImage _heightMapImage;
        public HeightMap HeightMap => _heightMap;
        public BitmapImage HeightMapImage => _heightMapImage;

        /// <summary>
        /// Constructor for ViewableHeightMap.
        /// </summary>
        /// <param name="heightMap">Height map</param>
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
