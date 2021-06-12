using System.Collections.Generic;

namespace Chess
{
    public class King : Figure
    {
        public King(Point2D position)
        {
            base.Position = position;
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