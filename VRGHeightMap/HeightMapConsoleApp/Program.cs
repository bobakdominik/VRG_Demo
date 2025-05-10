using HeightMapTools.Models;
using HeightMapTools.Tools;

/// <summary>
/// This is a console application that generates a png height nap image :D
/// Set parameters "_filePath" and "_outputImagePath" to generate the height map image
/// </summary>
public class Program
{
    private static string _filePath = "";
    private static string _outputImagePath = "";

    /// <summary>
    /// Creates a height map from a file and generates a png image.
    /// </summary>
    static void Main()
    {
        try
        {
            var heightMap = HeightMapFileReader.ReadHeihtMapFromFile(_filePath);

            var demoHeightMap = new HeightMap(255, 255, 1, 0, 0);
            for (int r = 0; r < demoHeightMap.Rows; r++)
            {
                for (int c = 0; c < demoHeightMap.Columns; c++)
                {
                    demoHeightMap[c, r] = c;
                }
            }
            var bitmap = HeightMapImageGenerator.CreateBitMapFromHeightMap(heightMap);
            bitmap.Save(_outputImagePath);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception thrown: {e.Message}");
        }
        
    }
}