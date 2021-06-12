using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess
{
    public class Bishop : Figure
    {
        public Bishop(Point2D position)
        {
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
                if (board.BlackPlayer.figures.Any(figure => figure.Position == tempPosition))
                {
                    return resList;
                }
                if (board.WhitePlayer.figures.Any(figure => figure.Position == tempPosition))
                {
                    return resList;
                }
                resList.Add(tempPosition);
            }

            return resList;
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