using System;
using Xunit;
using Chess;

namespace UnitTests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(1,1,2,2, Color.White, typeof(Exception))]
        [InlineData(1,1,1,1, Color.White, typeof(Exception))]
        [InlineData(1,1,2,1, Color.White, typeof(Exception))]
        [InlineData(1,1,0,1, Color.White, typeof(Exception))]
        [InlineData(1,1,0,2, Color.White, typeof(Exception))]
        [InlineData(1,1,1,0, Color.White, typeof(Exception))]
        [InlineData(1, 6, 1, 6, Color.Black, typeof(Exception))]
        [InlineData(1, 6, 1, 7, Color.Black, typeof(Exception))]
        [InlineData(1, 6, 0, 6, Color.Black, typeof(Exception))]
        [InlineData(1, 6, 2, 6, Color.Black, typeof(Exception))]
        [InlineData(1, 6, 0, 5, Color.Black, typeof(Exception))]
        [InlineData(1, 6, 2, 5, Color.Black, typeof(Exception))]
        public void TestPawnMoveException(int pawnPositionX, int pawnPositionY, int movePointX, int movePointY, Color color,Type expected)
        {
            //Arrange
            var board = new Board();
            var pawn = new Pawn(new Point2D(pawnPositionX, pawnPositionY), color);
            var movePoint = new Point2D(movePointX, movePointY);
            //Assert
            Assert.Throws(expected, () => pawn.Move(movePoint, board));
        }

        [Theory]
        [InlineData(0, 1, 0, 2, Color.White, true)]
        [InlineData(1, 1, 1, 3, Color.White, true)]
        [InlineData(1, 5, 2, 6, Color.White, true)]
        [InlineData(1, 5, 0, 6, Color.White, true)]
        [InlineData(1, 1, 1, 4, Color.White, false)]
        [InlineData(1, 1, 2, 1, Color.White, false)]
        [InlineData(1, 1, 0, 1, Color.White, false)]
        [InlineData(1, 1, 0, 2, Color.White, false)]
        [InlineData(1, 6, 1, 0, Color.Black, false)]
        [InlineData(1, 6, 1, 7, Color.Black, false)]
        [InlineData(1, 6, 0, 6, Color.Black, false)]
        [InlineData(1, 6, 2, 6, Color.Black, false)]
        [InlineData(1, 6, 1, 5, Color.Black, true)]
        [InlineData(1, 6, 1, 4, Color.Black, true)]
        [InlineData(1, 2, 0, 1, Color.Black, true)]
        [InlineData(1, 2, 2, 1, Color.Black, true)]
        
        public void TestPawnMove(int pawnPositionX, int pawnPositionY, int movePointX, int movePointY, Color color, bool expected)
        {
            //Arrange
            var board = new Board();
            var pawn = new Pawn(new Point2D(pawnPositionX, pawnPositionY), color);
            var movePoint = new Point2D(movePointX, movePointY);
            //Act
            try
            {
                pawn.Move(movePoint, board);
            }
            catch
            {
                // ignored
            }
            //Assert
            Assert.Equal(expected, movePoint == pawn.Position);
        }
        [Theory]
        [InlineData(0,0,1,1, Color.White, typeof(Exception))]
        [InlineData(0,1,6,5, Color.White, typeof(Exception))]
        [InlineData(0,7,7,0, Color.Black, typeof(Exception))]
        [InlineData(0,1,6,6, Color.Black, typeof(Exception))]
        public void TestBishopMoveException(int pawnPositionX, int pawnPositionY, int movePointX, int movePointY, Color color,Type expected)
        {
            //Arrange
            var board = new Board();
            var pawn = new Bishop(new Point2D(pawnPositionX, pawnPositionY), color);
            var movePoint = new Point2D(movePointX, movePointY);
            //Assert
            Assert.Throws(expected, () => pawn.Move(movePoint, board));
        }

        [Theory]
        [InlineData(0,0,1,1, Color.White, false)]
        [InlineData(1,2,2,3, Color.White, true)]
        [InlineData(1,5,0,4, Color.Black, true)]
        [InlineData(1,6,1,5, Color.Black, false)]
        
        public void TestBishopMove(int pawnPositionX, int pawnPositionY, int movePointX, int movePointY, Color color, bool expected)
        {
            //Arrange
            var board = new Board();
            var pawn = new Bishop(new Point2D(pawnPositionX, pawnPositionY), color);
            var movePoint = new Point2D(movePointX, movePointY);
            //Act
            try
            {
                pawn.Move(movePoint, board);
            }
            catch
            {
                // ignored
            }
            //Assert
            Assert.Equal(expected, movePoint == pawn.Position);
        }
        
        [Theory]
        [InlineData(0,0,1,0, Color.White, typeof(Exception))]
        [InlineData(0,0,0,1, Color.White, typeof(Exception))]
        [InlineData(7,7,7,6, Color.Black, typeof(Exception))]
        [InlineData(7,6,6,6, Color.Black, typeof(Exception))]
        public void TestKingMoveException(int pawnPositionX, int pawnPositionY, int movePointX, int movePointY, Color color,Type expected)
        {
            //Arrange
            var board = new Board();
            var pawn = new King(new Point2D(pawnPositionX, pawnPositionY), color);
            var movePoint = new Point2D(movePointX, movePointY);
            //Assert
            Assert.Throws(expected, () => pawn.Move(movePoint, board));
        }

        [Theory]
        [InlineData(4,4,4,6, Color.White, false)]
        [InlineData(4,4,5,5, Color.White, true)]
        [InlineData(4,4,3,3, Color.Black, true)]
        [InlineData(4,4,7,6, Color.Black, false)]
        [InlineData(1,2,1,3, Color.Black, true)]
        
        public void TestKingMove(int pawnPositionX, int pawnPositionY, int movePointX, int movePointY, Color color, bool expected)
        {
            //Arrange
            var board = new Board();
            var pawn = new King(new Point2D(pawnPositionX, pawnPositionY), color);
            var movePoint = new Point2D(movePointX, movePointY);
            //Act
            try
            {
                pawn.Move(movePoint, board);
            }
            catch
            {
                // ignored
            }
            //Assert
            Assert.Equal(expected, movePoint == pawn.Position);
        }
        
        [Theory]
        
        [InlineData(0,0,1,1, Color.White, typeof(Exception))]
        [InlineData(0,1,6,5, Color.White, typeof(Exception))]
        [InlineData(0,7,7,0, Color.Black, typeof(Exception))]
        [InlineData(0,1,6,6, Color.Black, typeof(Exception))]
        public void TestQueenMoveException(int pawnPositionX, int pawnPositionY, int movePointX, int movePointY, Color color,Type expected)
        {
            //Arrange
            var board = new Board();
            var pawn = new Queen(new Point2D(pawnPositionX, pawnPositionY), color);
            var movePoint = new Point2D(movePointX, movePointY);
            //Assert
            Assert.Throws(expected, () => pawn.Move(movePoint, board));
        }

        [Theory]
        [InlineData(0,0,1,1, Color.White, false)]
        [InlineData(1,2,2,3, Color.White, true)]
        [InlineData(1,5,0,4, Color.Black, true)]
        [InlineData(1,6,2,4, Color.Black, false)]
        
        public void TestQueenMove(int pawnPositionX, int pawnPositionY, int movePointX, int movePointY, Color color, bool expected)
        {
            //Arrange
            var board = new Board();
            var pawn = new Queen(new Point2D(pawnPositionX, pawnPositionY), color);
            var movePoint = new Point2D(movePointX, movePointY);
            //Act
            try
            {
                pawn.Move(movePoint, board);
            }
            catch
            {
                // ignored
            }
            //Assert
            Assert.Equal(expected, movePoint == pawn.Position);
        }
        [Theory]
        
        [InlineData(0,0,0,1, Color.White, typeof(Exception))]
        [InlineData(0,0,1,0, Color.White, typeof(Exception))]
        public void TestRookMoveException(int pawnPositionX, int pawnPositionY, int movePointX, int movePointY, Color color,Type expected)
        {
            //Arrange
            var board = new Board();
            var pawn = new Rook(new Point2D(pawnPositionX, pawnPositionY), color);
            var movePoint = new Point2D(movePointX, movePointY);
            //Assert
            Assert.Throws(expected, () => pawn.Move(movePoint, board));
        }

        [Theory]
        [InlineData(0,1,0,5, Color.White, true)]
        [InlineData(0,2,6,2, Color.White, true)]
        [InlineData(1,5,5,4, Color.Black, false)]
        [InlineData(1,6,2,4, Color.Black, false)]
        
        public void TestRookMove(int pawnPositionX, int pawnPositionY, int movePointX, int movePointY, Color color, bool expected)
        {
            //Arrange
            var board = new Board();
            var pawn = new Rook(new Point2D(pawnPositionX, pawnPositionY), color);
            var movePoint = new Point2D(movePointX, movePointY);
            //Act
            try
            {
                pawn.Move(movePoint, board);
            }
            catch
            {
                // ignored
            }
            //Assert
            Assert.Equal(expected, movePoint == pawn.Position);
        }
        
        [Theory]
        [InlineData(5,2,6,4, Color.White, true)]
        [InlineData(5,2,6,0, Color.White, false)]
        [InlineData(5,5,6,3, Color.Black, true)]
        [InlineData(5,5,1,3, Color.Black, false)]
        
        public void TestKnightMove(int pawnPositionX, int pawnPositionY, int movePointX, int movePointY, Color color, bool expected)
        {
            //Arrange
            var board = new Board();
            var pawn = new Knight(new Point2D(pawnPositionX, pawnPositionY), color);
            var movePoint = new Point2D(movePointX, movePointY);
            //Act
            try
            {
                pawn.Move(movePoint, board);
            }
            catch
            {
                // ignored
            }
            //Assert
            Assert.Equal(expected, movePoint == pawn.Position);
        }
        [Theory]
        
        [InlineData(5,0,7,1, Color.White, typeof(Exception))]
        [InlineData(5,7,7,6, Color.Black, typeof(Exception))]
        public void TestKnightMoveException(int pawnPositionX, int pawnPositionY, int movePointX, int movePointY, Color color,Type expected)
        {
            //Arrange
            var board = new Board();
            var pawn = new Knight(new Point2D(pawnPositionX, pawnPositionY), color);
            var movePoint = new Point2D(movePointX, movePointY);
            //Assert
            Assert.Throws(expected, () => pawn.Move(movePoint, board));
        }

        [Fact]
        public void TestBoardFunctions()
        {
            var board = new Board();
        }
    }
}