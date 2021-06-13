using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    /// <summary>
    /// Class who controls all game process
    /// </summary>
    public class Board
    {
        /// <summary>
        /// Player who have white figures
        /// </summary>
        public Player WhitePlayer { get; private set; }
        /// <summary>
        /// Player who have black figures
        /// </summary>
        public Player BlackPlayer { get; private set; }
        
        /// <summary>
        /// Player who make step
        /// </summary>
        private Player _currentPlayer;
        /// <summary>
        /// Player who win this game
        /// </summary>
        public Player Winner { get; private set; } 
        
        public Board()
        {
            WhitePlayer = new Player(Color.White);
            BlackPlayer = new Player(Color.Black);
            _currentPlayer = WhitePlayer;
        }

        /// <summary>
        /// Method who control player steps
        /// </summary>
        /// <param name="figurePosition">Figure position</param>
        /// <param name="movePosition">Move position</param>
        /// <exception cref="Exception">Rethrow exceptions that arise during the operation of the move methods</exception>
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
                Logger.AddActionToLog(_currentPlayer.ToString() + e.Message);
                throw e;
            }
        }

        /// <summary>
        /// Delete figure who was dead
        /// </summary>
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
                            Logger.AddActionToLog(_currentPlayer.ToString() + " Take: " + blackFigure);
                            BlackPlayer.figures.Remove(blackFigure);
                            return;
                        }
                        else
                        {
                            Logger.AddActionToLog(_currentPlayer.ToString() + " Take: " + whiteFigure);
                            WhitePlayer.figures.Remove(whiteFigure);
                            return;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Method that when a pawn reaches the edge of the board along the Y axis, it is replaced by a bishop
        /// </summary>
        private void PawnTransformationToBishop()
        {
            foreach (var figure in _currentPlayer.figures)
            {
                if (figure is Pawn && figure.Position.Y == 7 || figure.Position.Y == 0)
                {
                    _currentPlayer.figures.Add(new Bishop(figure));
                    _currentPlayer.figures.Remove(figure);
                    Logger.AddActionToLog(_currentPlayer.ToString() + " Transform: " + figure.ToString());
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
