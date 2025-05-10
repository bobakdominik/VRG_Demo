using HeightMapTools.Models;
using System.Drawing;

namespace HeightMapTools.Tools
{
    /// <summary>
    /// This class generates a Bitmap image from a HeightMap. The image is a grid of cells, each representing a height value.
    /// </summary>
    public static class HeightMapImageGenerator
    {
        /// <summary>
        /// The size of each cell in the Birmap image. The image is a grid of cells, each representing a height value.
        /// </summary>
        public static readonly int ImageCellSize = 1;

        /// <summary>
        /// Creates a Bitmap image from the given HeightMap. Each cell in the bitmap corresponds to a height value in the HeightMap.
        /// </summary>
        /// <param name="heightMap">HeightMap for image</param>
        /// <returns></returns>
        public static Bitmap CreateBitMapFromHeightMap(HeightMap heightMap)
        {
            var bitmap = new Bitmap(heightMap.Columns * ImageCellSize, heightMap.Rows * ImageCellSize);
            
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                var minHeight = heightMap.MinHeight;
                var maxHeight = heightMap.MaxHeight;
                for (int r = 0; r < heightMap.Rows; r++)
                {
                    for (int c = 0; c < heightMap.Columns; c++)
                    {
                        var height = heightMap[c, r];
                        var normalisedHeight = NormaliseHeight(height, minHeight, maxHeight);
                        var color = Color.FromArgb(normalisedHeight, normalisedHeight, normalisedHeight);
                        using (var brush = new SolidBrush(color))
                        {
                            g.FillRectangle(brush, c * ImageCellSize, r * ImageCellSize, ImageCellSize, ImageCellSize);
                        }
                    }
                }
            }
            return bitmap;
        }

        private static int NormaliseHeight(int height, int minHeight, int maxHeight)
        {
            if (maxHeight == minHeight)
            {
                return 0;
            }
            return (int)((height - minHeight) / (double)(maxHeight - minHeight) * 255);
        }
    }
}
