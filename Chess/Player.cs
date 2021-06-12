using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    public class Player
    {
        public List<Figure> figures = new List<Figure>();
        private readonly Color color;

        public Player(Color color)
        {
            this.color = color;
            InitFigures();
        }

        private void InitFigures()
        {
            if (color == Color.White)
            {
                for (int i = 0; i < 8; i++)
                {
                    figures.Add(new Pawn(new Point2D(i, 1), Color.White));
                }
                figures.Add(new Rook(new Point2D(0,0)));
                figures.Add(new Rook(new Point2D(7,0)));
                figures.Add(new Knight(new Point2D(1,0)));
                figures.Add(new Knight(new Point2D(6,0)));
                figures.Add(new Bishop(new Point2D(2, 0)));
                figures.Add(new Bishop(new Point2D(5, 0)));
                figures.Add(new Queen(new Point2D(3, 0)));
                figures.Add(new King(new Point2D(4, 0)));
            }
            else
            {
                for (int i = 0; i < 8; i++)
                {
                    figures.Add(new Pawn(new Point2D(i, 6), Color.Black));
                }
                figures.Add(new Rook(new Point2D(0,7)));
                figures.Add(new Rook(new Point2D(7,7)));
                figures.Add(new Knight(new Point2D(1,7)));
                figures.Add(new Knight(new Point2D(6,7)));
                figures.Add(new Bishop(new Point2D(2, 7)));
                figures.Add(new Bishop(new Point2D(5, 7)));
                figures.Add(new Queen(new Point2D(3, 7)));
                figures.Add(new King(new Point2D(4, 7)));
            }
            //TODO: creating a set of figures for the player (black & white) different coordinates
        }
    }
    public enum Color
    {
        White,
        Black
    }
}
