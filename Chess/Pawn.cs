using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess
{
    public class Pawn : Figure
    {
        private bool _isFirstMove = true;

        public Pawn(Point2D position, Color color)
        {
            Color = color;
            Position = position;
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
            
            foreach (var figure in Color == Color.White? board.WhitePlayer.figures : board.BlackPlayer.figures) 
            { 
                foreach (var valMove in valMoves)
                {
                    if (figure.Position == valMove)
                    {
                        valMoves.Remove(valMove);
                    }
                }
            }
            return valMoves;
        }

        private bool CheckEnemyFigureInPosition(Point2D position, Board board)
        {
            return (Color == Color.Black ? board.WhitePlayer.figures : board.BlackPlayer.figures).Any(figure => position == figure.Position);
        }
        
        public override void Move(Point2D position, Board board)
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