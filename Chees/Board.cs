using System;
using System.Collections.Generic;
using System.Text;

namespace Chees
{
    public class Board
    {
        public Player WhitePlayer { get; private set; }
        public Player BlackPlayer { get; private set; }
        public Board()
        {
            WhitePlayer = new Player(Color.White);
            BlackPlayer = new Player(Color.Black);
        }
    }
}
