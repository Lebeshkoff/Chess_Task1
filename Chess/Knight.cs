using System.Collections.Generic;

namespace Chess
{
    public class Knight : Figure
    {
        public Knight(Point2D position)
        {
            base.Position = position;
        }
        public override IEnumerable<Point2D> GetValidMovements(Board board)
        {
            throw new System.NotImplementedException();
        }

        public override void Move(Point2D position, Board board)
        {
            throw new System.NotImplementedException();
        }
    }
}