using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    public class Board
    {
        public Player WhitePlayer { get; private set; }
        public Player BlackPlayer { get; private set; }
        
        private Player _currentPlayer;
        
        public Player Winner { get; private set; } 
        
        public Board()
        {
            WhitePlayer = new Player(Color.White);
            BlackPlayer = new Player(Color.Black);
            _currentPlayer = WhitePlayer;
        }

        public void MakeStep(Point2D figurePosition, Point2D movePosition)
        {
            try
            {
                _currentPlayer.MoveFigure(figurePosition, movePosition, this);
                TakeFigure();
                _currentPlayer = _currentPlayer.color == Color.White ? BlackPlayer : WhitePlayer;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private void TakeFigure()
        {
            foreach (var whiteFigure in WhitePlayer.figures)
            {
                foreach (var blackFigure in BlackPlayer.figures)
                {
                    if (whiteFigure.Position == blackFigure.Position)
                    {
                        if (_currentPlayer.color == Color.White)
                        {
                            BlackPlayer.figures.Remove(blackFigure);
                            return;
                        }
                        else
                        {
                            WhitePlayer.figures.Remove(whiteFigure);
                            return;
                        }
                    }
                }
            }
        }
        
    }
}
