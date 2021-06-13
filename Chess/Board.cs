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
        
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj as Board == null) return false;
            return this.WhitePlayer == ((Board) obj).WhitePlayer 
                   && this.BlackPlayer == ((Board) obj).BlackPlayer 
                   && this.Winner == ((Board) obj).Winner 
                   && this._currentPlayer == ((Board) obj)._currentPlayer;
        }

        public override int GetHashCode()
        {
            return WhitePlayer.GetHashCode() ^ BlackPlayer.GetHashCode() ^ Winner.GetHashCode() ^
                   _currentPlayer.GetHashCode();
        }

        public override string ToString()
        {
            return "Board {Player1: " + WhitePlayer.ToString() + " Player2: " + WhitePlayer.ToString() + " Winner: " +
                   Winner.ToString() + " Current player: " + _currentPlayer.ToString() + " }";
        }
        
    }
}
