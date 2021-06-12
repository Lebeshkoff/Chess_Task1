using System.Collections.Generic;
using System.Linq;

namespace Chess
{
    public class Pawn : Figure
    {
        private readonly Color _color;
        private bool _isFirstMove = false;
        public Pawn(Point2D position, Color color)
        {
            _isFirstMove = true;
            _color = color;
            this.Position = position;
        }
        public override IEnumerable<Point2D> GetValidMovements(Board board)
        {
            var valMove = new List<Point2D>();
            if (_color == Color.White)
            {
                if (_isFirstMove)
                {
                    valMove.Add(new Point2D(Position.X, Position.Y + 2));
                }
                if (CheckEnemyFigureInPosition(new Point2D(Position.X + 1, Position.Y + 1), board))
                {
                    valMove.Add(new Point2D(Position.X + 1, Position.Y + 1));
                }
                if (CheckEnemyFigureInPosition(new Point2D(Position.X - 1, Position.Y + 1), board))
                {
                    valMove.Add(new Point2D(Position.X - 1, Position.Y + 1));
                }
                valMove.Add(new Point2D(Position.X, Position.Y + 1));
            }
            else
            {
                if (_isFirstMove)
                {
                    valMove.Add(new Point2D(Position.X, Position.Y - 2));
                }
                if (CheckEnemyFigureInPosition(new Point2D(Position.X - 1, Position.Y - 1), board))
                {
                    valMove.Add(new Point2D(Position.X - 1, Position.Y - 1));
                }
                if (CheckEnemyFigureInPosition(new Point2D(Position.X + 1, Position.Y - 1), board))
                {
                    valMove.Add(new Point2D(Position.X + 1, Position.Y - 1));
                }
                valMove.Add(new Point2D(Position.X, Position.Y - 1));
            }
            throw new System.NotImplementedException();
        }

        private bool CheckEnemyFigureInPosition(Point2D position, Board board)
        {
            return (_color == Color.Black ? board.WhitePlayer.figures : board.BlackPlayer.figures).Any(figure => position == figure.Position);
        }
        public override void Move(Board board)
        {
            throw new System.NotImplementedException();
        }
    }
}