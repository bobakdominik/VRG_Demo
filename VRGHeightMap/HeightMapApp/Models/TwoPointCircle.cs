using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeightMapApp.Models
{
    class TwoPointCircle
    {
        private readonly Point _centerPoint;
        private readonly Point _outlinePoint;

        public Point CenterPoint => _centerPoint;
        public Point OutlinePoint => _outlinePoint;
        public double Radius
        {
            get
            {
                var xLength = Math.Max(CenterPoint.XVal, OutlinePoint.XVal) - Math.Min(CenterPoint.XVal, OutlinePoint.XVal);
                var yLength = Math.Max(CenterPoint.YVal, OutlinePoint.YVal) - Math.Min(CenterPoint.YVal, OutlinePoint.YVal);
                return Math.Sqrt(Math.Pow(xLength, 2) + Math.Pow(yLength, 2));
            }
        }
    }
}
