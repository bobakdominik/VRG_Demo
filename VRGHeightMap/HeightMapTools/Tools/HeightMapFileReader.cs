using HeightMapTools.Models;
using System.Globalization;

namespace HeightMapTools.Tools
{
    public static class HeightMapFileReader
    {

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

        //ncols        1024
        //nrows        1024
        //xllcorner    0.000000000000
        //yllcorner    0.000000000000
        //cellsize     1.000000000000
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
