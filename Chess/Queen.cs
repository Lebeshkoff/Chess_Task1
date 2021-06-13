using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess
{
    /// <summary>
    /// Queen figure
    /// </summary>
    public class Queen : Figure
    {
        /// <summary>
        ///  Initialise figure
        /// </summary>
        /// <param name="position">Start position</param>
        /// <param name="color">Color</param>
        public Queen(Point2D position, Color color)
        {
            Color = color;
            Position = position;
        }
        
        /// <summary>
        /// Ctor which allows you to copy the figure
        /// </summary>
        /// <param name="queen">Сopied</param>
        public Queen(Queen queen)
        {
            Position = queen.Position;
            Color = queen.Color;
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