using System;
using System.Collections.Generic;

namespace Chess
{
    public abstract class Figure
    {
        public Point2D Position { get; protected set; }
        
        public Color Color { get; protected set; }

        public abstract IEnumerable<Point2D> GetValidMovements(Board board);
        public abstract void Move(Point2D position, Board board);
    }
}
