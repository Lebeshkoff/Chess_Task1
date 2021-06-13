using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chess
{
    /// <summary>
    /// Class who describes chess player
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Set of player figures
        /// </summary>
        public List<Figure> figures = new List<Figure>();

        /// <summary>
        /// Color of figures
        /// </summary>
        public readonly Color color;

        /// <summary>
        /// Ctor who initialise sets of figures and assigns color
        /// </summary>
        /// <param name="color">Figures color</param>
        public Player(Color color)
        {
            this.color = color;
            InitFigures();
        }

        /// <summary>
        /// Initialise sets of figures depending on color
        /// </summary>
        private void InitFigures()
        {
            if (color == Color.White)
            {
                for (int i = 0; i < 8; i++)
                {
                    figures.Add(new Pawn(new Point2D(i, 1), Color.White));
                }
                figures.Add(new Rook(new Point2D(0,0), color));
                figures.Add(new Rook(new Point2D(7,0), color));
                figures.Add(new Knight(new Point2D(1,0), color));
                figures.Add(new Knight(new Point2D(6,0), color));
                figures.Add(new Bishop(new Point2D(2, 0), color));
                figures.Add(new Bishop(new Point2D(5, 0), color));
                figures.Add(new Queen(new Point2D(3, 0), color));
                figures.Add(new King(new Point2D(4, 0), color));
            }
            else
            {
                for (int i = 0; i < 8; i++)
                {
                    figures.Add(new Pawn(new Point2D(i, 6), Color.Black));
                }
                figures.Add(new Rook(new Point2D(0,7), color));
                figures.Add(new Rook(new Point2D(7,7), color));
                figures.Add(new Knight(new Point2D(1,7), color));
                figures.Add(new Knight(new Point2D(6,7), color));
                figures.Add(new Bishop(new Point2D(2, 7), color));
                figures.Add(new Bishop(new Point2D(5, 7), color));
                figures.Add(new Queen(new Point2D(3, 7), color));
                figures.Add(new King(new Point2D(4, 7), color));
            }
        }

        /// <summary>
        /// Method who moves the given figure to the given position
        /// </summary>
        /// <param name="figurePosition">Figure position</param>
        /// <param name="movePosition">Move position</param>
        /// <param name="board">Board controller</param>
        /// <exception cref="Exception">If you select null figure</exception>
        public void MoveFigure(Point2D figurePosition, Point2D movePosition, Board board)
        {
            Figure movable = null;
            foreach (var figure in figures)
            {
                if (figure.Position == figurePosition)
                {
                    movable = figure;
                    break;
                }
            }

            if (movable == null)
            {
                throw new Exception("In selected position there are no figure!");
            }
            movable.Move(movePosition, board);
        }
        
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj as Player == null) return false;
            return this.color == ((Player) obj).color && this.figures.SequenceEqual(((Player) obj).figures);
        }

        public override int GetHashCode()
        {
            return color.GetHashCode() ^ figures.GetHashCode();
        }

        public override string ToString()
        {
            return "Player {Color: " + color.ToString() + " Figures: " + figures.ToString() + " }";
        }
    }
}
