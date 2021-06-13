using System;
using Xunit;
using Chess;

namespace UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var board = new Board();
            board.MakeStep(new Point2D(1,1), new Point2D(1,2));
            
        }
    }
}