using System.Collections.Generic;

namespace Chess
{
    public class Bishop : Figure
    {
        public Bishop(Point2D position)
        {
            this.Position = position;
        }
        public override IEnumerable<Point2D> GetValidMovements()
        {
            throw new System.NotImplementedException();
        }

        public override void Move(Board board)
        {
            throw new System.NotImplementedException();
        }
    }
} 