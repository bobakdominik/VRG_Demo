using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeightMapApp.Models
{
    internal class Point
    {
        private readonly int _xVal;
        private readonly int _yVal;

        public int XVal => _xVal;
        public int YVal => _yVal;

        public Point(int xVal, int yVal)
        {
            _xVal = xVal;
            _yVal = yVal;
        }
    }
}
