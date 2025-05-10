namespace HeightMapTools.Models
{
    /// <summary>
    /// Represents a height map with starting position.
    /// </summary>
    public class HeightMap
    {
        private readonly int _columns;
        private readonly int _rows;
        private readonly double _cellSize;
        private readonly double _startX;
        private readonly double _startY;
        private readonly int[,] _heights;

        public int Columns => _columns;
        public int Rows => _rows;
        public double CellSize => _cellSize;
        public double StartX => _startX;
        public double StartY => _startY;

        public int MinHeight => _heights.Cast<int>().Min();
        public int MaxHeight => _heights.Cast<int>().Max();

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

        /// <summary>
        /// Default constructor for HeightMap.
        /// </summary>
        public HeightMap()
        {
            _columns = 1;
            _rows = 1;
            _cellSize = 0;
            _startX = 0;
            _startY = 0;
            _heights = new int[_columns, _rows];
        }

        /// <summary>
        /// Constructor for HeightMap with specified parameters.
        /// </summary>
        /// <param name="columns">Number of columns</param>
        /// <param name="rows">Number of rows</param>
        /// <param name="cellSize">Cell size</param>
        /// <param name="startX">Starting X position</param>
        /// <param name="startY">Starting Y position</param>
        /// <exception cref="ArgumentOutOfRangeException">Throws an exception if column or row is less than 1</exception>
        public HeightMap(int columns, int rows, double cellSize, double startX, double startY) 
        {
            if (columns <= 0 || rows <= 0)
            {
                throw new ArgumentOutOfRangeException("Collumns and rows must be greater than zero");
            }
            _rows = rows;
            _columns = columns;
            _cellSize = cellSize;
            _startX = startX;
            _startY = startY;
            _heights = new int[_columns, _rows];
        }

        /// <summary>
        /// Sets the height at a specific column and row in the height map.
        /// </summary>
        /// <param name="height">Height</param>
        /// <param name="column">Column</param>
        /// <param name="row">Row</param>
        /// <exception cref="ArgumentOutOfRangeException">Throws an exception for wrong column or row</exception>
        public void SetHeight(int height, int column, int row)
        {
            if (column < 0 || column >= _columns ||
                   row < 0 || row >= _rows)
            {
                throw new ArgumentOutOfRangeException("Invalid collumn or row index");
            }
            _heights[column, row] = height;
        }

        /// <summary>
        /// Gets the height at a specific column and row in the height map.
        /// </summary>
        /// <param name="column">Column</param>
        /// <param name="row">Row</param>
        /// <returns>Height</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throws an exception for wrong column or row</exception>
        public int GetHeight(int column, int row)
        {
            if (column < 0 || column >= _columns ||
                   row < 0 || row >= _rows)
            {
                throw new ArgumentOutOfRangeException("Invalid collumn or row index");
            }
            return _heights[column, row];
        }
    }
}
