using HeightMapTools.Models;
using System.Drawing;

namespace HeightMapTools.Tools
{
    public static class HeightMapImageGenerator
    {
        public static int ImageCellSize = 1;

        public static Bitmap CreateBitMapFromHeightMap(HeightMap heightMap)
        {
            var bitmap = new Bitmap(heightMap.Columns * ImageCellSize, heightMap.Rows * ImageCellSize);
            
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                for (int r = 0; r < heightMap.Rows; r++)
                {
                    var minHeight = heightMap.MinHeight;
                    var maxHeight = heightMap.MaxHeight;
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
