using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess
{
    public class Queen : Figure
    {
        public Queen(Point2D position, Color color)
        {
            Color = color;
            Position = position;
        }
        public override IEnumerable<Point2D> GetValidMovements(Board board)
        {
            var valMoves = new List<Point2D>();
            valMoves.AddRange(GetValidPositionsFromAxis(new Point2D(0,1), board));
            valMoves.AddRange(GetValidPositionsFromAxis(new Point2D(0,-1), board));
            valMoves.AddRange(GetValidPositionsFromAxis(new Point2D(-1,0), board));
            valMoves.AddRange(GetValidPositionsFromAxis(new Point2D(1,0), board));
            valMoves.AddRange(GetValidPositionsFromAxis(new Point2D(1,1), board));
            valMoves.AddRange(GetValidPositionsFromAxis(new Point2D(-1,1), board));
            valMoves.AddRange(GetValidPositionsFromAxis(new Point2D(-1,-1), board));
            valMoves.AddRange(GetValidPositionsFromAxis(new Point2D(1,-1), board));
            return valMoves;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj as Queen == null) return false;
            return this.Position == ((Queen) obj).Position && this.Color == ((Queen) obj).Color;
        }

        public override int GetHashCode()
        {
            return Position.X.GetHashCode() ^ Position.Y.GetHashCode() ^ Color.GetHashCode();
        }

        public override string ToString()
        {
            return "Queen {Position: " + Position.ToString() + " Color: " + Color.ToString() + " }";
        }
    }
}