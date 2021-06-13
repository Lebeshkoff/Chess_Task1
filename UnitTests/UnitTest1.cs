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
    }
}