using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess
{
    /// <summary>
    /// The abstract class who describes chess figures
    /// </summary>
    public abstract class Figure
    {
        /// <summary>
        /// Position on board
        /// </summary>
        public Point2D Position { get; protected set; }
        
        /// <summary>
        /// Figure color
        /// </summary>
        public Color Color { get; protected set; }

        /// <summary>
        /// Method who gets valid movements for figure
        /// </summary>
        /// <param name="board">Board controller</param>
        /// <returns>List of points</returns>
        public abstract IEnumerable<Point2D> GetValidMovements(Board board);
        
        /// <summary>
        /// Method who moves the figure
        /// </summary>
        /// <param name="position">Position for move</param>
        /// <param name="board">Board controller</param>
        /// <exception cref="Exception">When the figure cannot move</exception>
        public virtual void Move(Point2D position, Board board)
        {
            var valPositions = GetValidMovements(board);
            foreach (var valPosition in valPositions)
            {
                if (position == valPosition)
                {
                    Position = valPosition;
                    return;
                }
            }

            throw new Exception("No valid move!");
        }
        
        /// <summary>
        /// Method who take points from axis taking into account standing figures
        /// </summary>
        /// <param name="axis">Axis</param>
        /// <param name="board">Board controller</param>
        /// <returns>Points list</returns>
        protected IEnumerable<Point2D> GetValidPositionsFromAxis(Point2D axis, Board board)
        {
            var resList = new List<Point2D>();
            var tempPosition = Position; 
            while (tempPosition.X < 8 && tempPosition.X >= 0 && tempPosition.Y < 8 && tempPosition.Y >= 0)
            {
                tempPosition += axis;
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
                resList.Add(tempPosition);
            }

            return resList;
        }
    }
}
