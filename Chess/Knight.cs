using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess
{
    /// <summary>
    /// Knight figure
    /// </summary>
    public class Knight : Figure
    {
        /// <summary>
        ///  Initialise figure
        /// </summary>
        /// <param name="position">Start position</param>
        /// <param name="color">Color</param>
        public Knight(Point2D position, Color color)
        {
            Color = color;
            Position = position;
        }
        
        /// <summary>
        /// Ctor which allows you to copy the figure
        /// </summary>
        /// <param name="knight">Сopied</param>
        public Knight(Knight knight)
        {
            Position = knight.Position;
            Color = knight.Color;
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
        
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj as Knight == null) return false;
            return this.Position == ((Knight) obj).Position && this.Color == ((Knight) obj).Color;
        }

        public override int GetHashCode()
        {
            return Position.X.GetHashCode() ^ Position.Y.GetHashCode() ^ Color.GetHashCode();
        }

        public override string ToString()
        {
            return "Knight {Position: " + Position.ToString() + " Color: " + Color.ToString() + " }";
        }
    }
}