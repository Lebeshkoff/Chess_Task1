using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess
{
    public class Bishop : Figure
    {
        public Bishop(Point2D position, Color color)
        {
            Color = color;
            Position = position;
        }
        public override IEnumerable<Point2D> GetValidMovements(Board board)
        {
            var valMoves = new List<Point2D>();
            valMoves.AddRange(GetValidPositions(new Point2D(1,1), board));
            valMoves.AddRange(GetValidPositions(new Point2D(-1,1), board));
            valMoves.AddRange(GetValidPositions(new Point2D(-1,-1), board));
            valMoves.AddRange(GetValidPositions(new Point2D(1,-1), board));
            return valMoves;
        }

        private IEnumerable<Point2D> GetValidPositions(Point2D axis, Board board)
        {
            var resList = new List<Point2D>();
            var tempPosition = Position; 
            while (tempPosition.X < 8 && tempPosition.X >= 0 && tempPosition.Y < 8 && tempPosition.Y >= 0)
            {
                tempPosition += axis;
                resList.Add(tempPosition);
                if (board.BlackPlayer.figures.Any(figure => figure.Position == tempPosition))
                {
                    if (Color == Color.Black)
                    {
                        resList.Remove(tempPosition);
                    }
                    return resList;
                }
                if (board.WhitePlayer.figures.Any(figure => figure.Position == tempPosition))
                {
                    if (Color == Color.White)
                    {
                        resList.Remove(tempPosition);
                    }
                    return resList;
                }
            }

            return resList;
        }
        
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj as Bishop == null) return false;
            return this.Position == ((Bishop) obj).Position && this.Color == ((Bishop) obj).Color;
        }

        public override int GetHashCode()
        {
            return Position.X.GetHashCode() ^ Position.Y.GetHashCode() ^ Color.GetHashCode();
        }

        public override string ToString()
        {
            return "Bishop {Position: " + Position.ToString() + " Color: " + Color.ToString() + " }";
        }
    }
} 