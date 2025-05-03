namespace HeightMapTools.Models
{
    public class HeightMap
    {
        private readonly int _columns;
        private readonly int _rows;
        private readonly double _cellSize;
        private readonly double _startX;
        private readonly double _startY;
        private readonly int[,] _heights;
        private int _minHeight;
        private int _maxHeight;

        public int Columns => _columns;
        public int Rows => _rows;
        public double CellSize => _cellSize;
        public double X => _startX;
        public double Y => _startY;

        public int MinHeight => _minHeight;
        public int MaxHeight => _maxHeight;

        public int this[int col, int row]
        {
            get
            {
                return GetHeight(col, row);
            }
            set
            {
                SetHeight(value, col, row);
            }
        }

        public HeightMap(int collumns, int rows, double cellSize, double startX, double startY) 
        {
            _rows = rows;
            _columns = collumns;
            _cellSize = cellSize;
            _startX = startX;
            _startY = startY;
            _heights = new int[collumns,rows];
            _minHeight = int.MaxValue;
            _maxHeight = int.MinValue;
        }

        public void SetHeight(int height, int collumn, int row)
        {
            if (collumn < 0 || collumn >= _columns ||
                   row < 0 || row >= _rows)
            {
                throw new ArgumentOutOfRangeException("Invalid collumn or row index");
            }
            _heights[collumn, row] = height;
            UpdateMinMaxHeight(height);
        }

        public int GetHeight(int collumn, int row)
        {
            if (collumn < 0 || collumn >= _columns ||
                   row < 0 || row >= _rows)
            {
                throw new ArgumentOutOfRangeException("Invalid collumn or row index");
            }
            return _heights[collumn, row];
        }

        private void UpdateMinMaxHeight(int height)
        {
            if (height < _minHeight)
            {
                _minHeight = height;
            }
            if (height > _maxHeight)
            {
                _maxHeight = height;
            }
        }
    }
}
