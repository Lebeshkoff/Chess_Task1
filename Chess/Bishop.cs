using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess
{
    /// <summary>
    /// Bishop figure
    /// </summary>
    public class Bishop : Figure
    {
        /// <summary>
        ///  Initialise figure
        /// </summary>
        /// <param name="position">Start position</param>
        /// <param name="color">Color</param>
        public Bishop(Point2D position, Color color)
        {
            Color = color;
            Position = position;
        }

        /// <summary>
        /// Ctor which allows you to copy the figure
        /// </summary>
        /// <param name="bishop">Сopied</param>
        public Bishop(Bishop bishop)
        {
            Position = bishop.Position;
            Color = bishop.Color;
        }
        public override IEnumerable<Point2D> GetValidMovements(Board board)
        {
            var valMoves = new List<Point2D>();
            valMoves.AddRange(GetValidPositionsFromAxis(new Point2D(1,1), board));
            valMoves.AddRange(GetValidPositionsFromAxis(new Point2D(-1,1), board));
            valMoves.AddRange(GetValidPositionsFromAxis(new Point2D(-1,-1), board));
            valMoves.AddRange(GetValidPositionsFromAxis(new Point2D(1,-1), board));
            return valMoves;
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