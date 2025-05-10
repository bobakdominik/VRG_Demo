using HeightMapTools.Models;
using System.Globalization;

namespace HeightMapTools.Tools
{
    /// <summary>
    /// This class reads a height map from a file.
    /// </summary>
    public static class HeightMapFileReader
    {
        /// <summary>
        /// Reads a height map from a file. The file should be in the format:
        /// ncols        int
        /// nrows        int
        /// xllcorner    double
        /// yllcorner    double
        /// cellsize     double
        /// Matrix ncols*nrows of height values
        /// </summary>
        /// <param name="filePath">Path to the file with height map data</param>
        /// <returns>HeightMap object</returns>
        /// <exception cref="FormatException">Throws an exception if selected file has a wrong format</exception>
        public static HeightMap ReadHeihtMapFromFile(string filePath)
        {
            using (StreamReader sr = new StreamReader(filePath)) 
            {
                var heightMap = CreateHeightMapFromHeader(sr);
                for (int r = 0; r < heightMap.Rows; r++)
                {
                    var line = sr.ReadLine();
                    var stringValues = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    for (int c = 0; c < heightMap.Columns; c++)
                    {
                        if (!int.TryParse(stringValues[c], out int height))
                        {
                            throw new FormatException($"Invalid integer format in line: {line}");
                        }
                        heightMap[c,r] = height;
                    }
                }
                return heightMap;
            }
        }

        private static HeightMap CreateHeightMapFromHeader(StreamReader streamReader)
        {
            (string keyColumns, int columns) = GetIntFromHeader(streamReader.ReadLine());
            (string keyRows, int rows) = GetIntFromHeader(streamReader.ReadLine());
            (string keyStartX, double startX) = GetDoubleFromHeader(streamReader.ReadLine());
            (string keyStartY, double startY) = GetDoubleFromHeader(streamReader.ReadLine());
            (string keyCellSize, double cellSize) = GetDoubleFromHeader(streamReader.ReadLine());
            return new HeightMap(columns, rows, cellSize, startX, startY);
        }

        private static (string key, int value) GetIntFromHeader(string header)
        {
            (string key, string stringValue) = GetKeyValuePairFromHeader(header);
            if (!int.TryParse(stringValue, out int value))
            {
                throw new FormatException($"Invalid integer format in line: {header}"); 
            }
            return (key, value);

        }

        private static (string key, double value) GetDoubleFromHeader(string header)
        {
            (string key, string stringValue) = GetKeyValuePairFromHeader(header);
            if (!double.TryParse(stringValue, NumberStyles.Float, CultureInfo.InvariantCulture, out double value))
            {
                throw new FormatException($"Invalid double format in line: {header}");
            }
            value = Math.Round(value, 3);
            return (key, value);
        }

        private static (string key, string value) GetKeyValuePairFromHeader(string header)
        {
            var lines = header.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (lines.Length != 2)
            {
                throw new FormatException($"Invalid format in line: {header}");
            }
            return (lines[0], lines[1]);
        }
    }
}
