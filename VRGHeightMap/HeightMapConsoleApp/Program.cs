using HeightMapTools.Models;
using HeightMapTools.Tools;

public class Program
{
    static void Main(string[] args)
    {
        // "D:\Development\c#\VRG_Demo\heightmap_ASCII"
        Console.WriteLine("Hello, World!");
        var heightMap = HeightMapFileReader.ReadHeihtMapFromFile("D:\\Development\\c#\\VRG_Demo\\heightmap_ASCII");

        var demoHeightMap = new HeightMap(255, 255, 1, 0,0);
        for (int r = 0; r < demoHeightMap.Rows; r++)
        {
            for (int c = 0; c < demoHeightMap.Columns; c++)
            {
                demoHeightMap[c, r] = c;
            }
        }
        var bitmap = HeightMapImageGenerator.CreateBitMapFromHeightMap(heightMap);
        bitmap.Save("D:\\Development\\c#\\VRG_Demo\\test.png");
        bitmap.Dispose();
    }
}