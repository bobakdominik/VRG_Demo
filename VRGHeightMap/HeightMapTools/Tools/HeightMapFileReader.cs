using HeightMapTools.Models;

namespace HeightMapTools.Tools
{
    internal static class HeightMapFileReader
    {
        public static HeightMap ReadHeihtMapFromFile(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open)) 
            {
                
            }
        }
    }
}
