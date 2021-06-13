using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess
{
    public class Rook : Figure
    {
        public Rook(Point2D position, Color color)
        {
            Color = color;
            Position = position;
        }
        public override IEnumerable<Point2D> GetValidMovements(Board board)
        {
            var valMoves = new List<Point2D>();
            //Up
            valMoves.AddRange(GetValidPositionsFromAxis(new Point2D(0,1), board));
            //Down
            valMoves.AddRange(GetValidPositionsFromAxis(new Point2D(0,-1), board));
            //Left
            valMoves.AddRange(GetValidPositionsFromAxis(new Point2D(-1,0), board));
            //Right
            valMoves.AddRange(GetValidPositionsFromAxis(new Point2D(1,0), board));
            return valMoves;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj as Rook == null) return false;
            return this.Position == ((Rook) obj).Position && this.Color == ((Rook) obj).Color;
        }

        public override int GetHashCode()
        {
            return Position.X.GetHashCode() ^ Position.Y.GetHashCode() ^ Color.GetHashCode();
        }

        public override string ToString()
        {
            return "Rook {Position: " + Position.ToString() + " Color: " + Color.ToString() + " }";
        }
    }
}