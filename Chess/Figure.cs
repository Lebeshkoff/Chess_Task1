using System;
using System.Collections.Generic;

namespace Chess
{
    public abstract class Figure
    {
        public Point2D Position { get; protected set; }
        
        public Color Color { get; protected set; }

        public abstract IEnumerable<Point2D> GetValidMovements(Board board);
        
        public virtual void Move(Point2D position, Board board)
        {
            var valPositions = GetValidMovements(board);
            foreach (var valPosition in valPositions)
            {
                if (position == valPosition)
                {
                    Position = valPosition;
                    return;
                }
            }

            throw new Exception("No valid move!");
        }
    }
}
