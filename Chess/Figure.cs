using System;
using System.Collections.Generic;

namespace Chess
{
    public abstract class Figure
    {
        public Point2D Coordinates { get; private set; }

        public abstract IEnumerable<Point2D> GetValidMovements();
        public abstract void Move(Board board);
    }
}
