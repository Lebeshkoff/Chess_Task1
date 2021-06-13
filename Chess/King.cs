using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess
{
    public class King : Figure
    {
        public King(Point2D position, Color color)
        {
            Color = color;
            Position = position;
        }
        public override IEnumerable<Point2D> GetValidMovements(Board board)
        {
            var valMoves = new List<Point2D>();
            //Up
            valMoves.Add(new Point2D(Position.X, Position.Y + 1));
            valMoves.Add(new Point2D(Position.X + 1, Position.Y + 1));
            valMoves.Add(new Point2D(Position.X - 1, Position.Y + 1));
            valMoves.Add(new Point2D(Position.X - 1, Position.Y));
            valMoves.Add(new Point2D(Position.X + 1, Position.Y));
            valMoves.Add(new Point2D(Position.X - 1, Position.Y - 1));
            valMoves.Add(new Point2D(Position.X, Position.Y - 1));
            valMoves.Add(new Point2D(Position.X + 1, Position.Y - 1));

            var removeCollection = valMoves.Where(valMove => valMove.X > 7 || 
                                                             valMove.Y > 7 || 
                                                             valMove.X < 0 || 
                                                             valMove.Y < 0).ToList();

            foreach (var figure in Color == Color.White? board.WhitePlayer.figures : board.BlackPlayer.figures) 
            { 
                foreach (var valMove in valMoves)
                {
                    if (figure.Position == valMove)
                    {
                        removeCollection.Add(valMove);
                    }
                }
            }

            foreach (var toDelete in removeCollection)
            {
                valMoves.Remove(toDelete);
            }
            return valMoves;
        }
    }
}