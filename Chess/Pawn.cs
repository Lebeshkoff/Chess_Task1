using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess
{
    /// <summary>
    /// Pawn figure
    /// </summary>
    public class Pawn : Figure
    {
        private bool _isFirstMove = false;

        /// <summary>
        ///  Initialise figure
        /// </summary>
        /// <param name="position">Start position</param>
        /// <param name="color">Color</param>
        public Pawn(Point2D position, Color color)
        {
            _isFirstMove = true;
            Color = color;
            Position = position;
        }

        /// <summary>
        /// Ctor which allows you to copy the figure
        /// </summary>
        /// <param name="pawn">Сopied</param>
        public Pawn(Pawn pawn)
        {
            Position = pawn.Position;
            Color = pawn.Color;
        }
        public override IEnumerable<Point2D> GetValidMovements(Board board)
        {
            var valMoves = new List<Point2D>();
            if (Color == Color.White)
            {
                if (_isFirstMove)
                {
                    valMoves.Add(new Point2D(Position.X, Position.Y + 2));
                    _isFirstMove = false;
                }
                if (CheckEnemyFigureInPosition(new Point2D(Position.X + 1, Position.Y + 1), board))
                {
                    valMoves.Add(new Point2D(Position.X + 1, Position.Y + 1));
                }
                if (CheckEnemyFigureInPosition(new Point2D(Position.X - 1, Position.Y + 1), board))
                {
                    valMoves.Add(new Point2D(Position.X - 1, Position.Y + 1));
                }
                valMoves.Add(new Point2D(Position.X, Position.Y + 1));
            }
            else
            {
                if (_isFirstMove)
                {
                    valMoves.Add(new Point2D(Position.X, Position.Y - 2));
                    _isFirstMove = false;
                }
                if (CheckEnemyFigureInPosition(new Point2D(Position.X - 1, Position.Y - 1), board))
                {
                    valMoves.Add(new Point2D(Position.X - 1, Position.Y - 1));
                }
                if (CheckEnemyFigureInPosition(new Point2D(Position.X + 1, Position.Y - 1), board))
                {
                    valMoves.Add(new Point2D(Position.X + 1, Position.Y - 1));
                }
                valMoves.Add(new Point2D(Position.X, Position.Y - 1));
            }
            return valMoves;
        }

        /// <summary>
        /// Method who check enemy figures on diagonals for pawn steps
        /// </summary>
        /// <param name="position">Diagonal points</param>
        /// <param name="board">Board controller</param>
        /// <returns>Boolean</returns>
        private bool CheckEnemyFigureInPosition(Point2D position, Board board)
        {
            return (Color == Color.Black ? board.WhitePlayer.figures : board.BlackPlayer.figures).Any(figure => position == figure.Position);
        }
        
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj as Pawn == null) return false;
            return this.Position == ((Pawn) obj).Position && this.Color == ((Pawn) obj).Color && this._isFirstMove == ((Pawn) obj)._isFirstMove;
        }

        public override int GetHashCode()
        {
            return Position.X.GetHashCode() ^ Position.Y.GetHashCode() ^ Color.GetHashCode() ^ _isFirstMove.GetHashCode();
        }

        public override string ToString()
        {
            return "Pawn {Position: " + Position.ToString() + " Color: " + Color.ToString() + " IsFirstMove: " + _isFirstMove.ToString() +" }";
        }
    }
}