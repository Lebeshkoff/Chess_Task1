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
            //TODO: creating a set of figures for the player (black & white) different coordinates
        }
    }
    public enum Color
    {
        White,
        Black
    }
}
