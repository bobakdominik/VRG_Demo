namespace HeightMapTools.Models
{
    internal class HeightMap
    {
        private readonly int _columns;
        private readonly int _rows;
        private readonly float _cellSize;
        private readonly float _startX;
        private readonly float _startY;
        private readonly int[,] _heights;

        public int Columns => _columns;
        public int Rows => _rows;
        public float CellSize => _cellSize;
        public float X => _startX;
        public float Y => _startY;
        public int[,]Heights => _heights;
        

        public HeightMap(int collumns, int rows, float cellSize, float startX, float startY) 
        {
            _rows = rows;
            _columns = collumns;
            _cellSize = cellSize;
            _startX = startX;
            _startY = startY;
            _heights = new int[collumns,rows];
        }

        public void SetHeight(int height, int collumn, int row)
        {
            if (collumn < 0 || collumn >= _columns ||
                row < 0 || row >= _rows)
            {
                throw new ArgumentOutOfRangeException("Invalid collumn or row index");
            }
            _heights[collumn, row] = height;
        }
    }
}
