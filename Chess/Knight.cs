using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess
{
    public class Knight : Figure
    {
        public Knight(Point2D position)
        {
            Position = position;
        }
        public override IEnumerable<Point2D> GetValidMovements(Board board)
        {
            var valMoves = new List<Point2D>();
            //Up
            valMoves.Add(new Point2D(Position.X + 1, Position.Y + 2));
            valMoves.Add(new Point2D(Position.X - 1, Position.Y + 2));
            //Down
            valMoves.Add(new Point2D(Position.X + 1, Position.Y - 2));
            valMoves.Add(new Point2D(Position.X - 1, Position.Y - 2));
            //Left
            valMoves.Add(new Point2D(Position.X + 2, Position.Y + 1));
            valMoves.Add(new Point2D(Position.X + 2, Position.Y - 1));
            //Right
            valMoves.Add(new Point2D(Position.X - 2, Position.Y + 1));
            valMoves.Add(new Point2D(Position.X - 2, Position.Y - 1));
            foreach (var valMove in valMoves.Where(valMove => valMove.X > 7 || valMove.Y > 7 || valMove.X < 0 || valMove.Y < 0))
            {
                valMoves.Remove(valMove);
            }

            return valMoves;
        }

        public override void Move(Point2D position, Board board, Color color)
        {
            foreach (var valPosition in GetValidMovements(board))
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