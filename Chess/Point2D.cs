using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    /// <summary>
    /// Сlass describing a two-dimensional point
    /// </summary>
    public class Point2D
    {
        /// <summary>
        /// Х coordinate
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// Y coordinate
        /// </summary>
        public int Y { get; set; }
        /// <summary>
        /// 2D point
        /// </summary>
        /// <param name="x">Х coordinate</param>
        /// <param name="y">Y coordinate</param>
        public Point2D(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Point2D operator +(Point2D point1, Point2D point2)
        {
            return new Point2D(point1.X + point2.X, point1.Y + point2.Y);
        }
        
        public static bool operator ==(Point2D point1, Point2D point2)
        {
            return point1.X == point2.X && point1.Y == point2.Y;
        }

        public static bool operator !=(Point2D point1, Point2D point2)
        {
            return !(point1 == point2);
        }

        public override bool Equals(object obj)
        {
            if(obj == null) return false;
            if (!(obj is Point2D)) return false;
            return this.X == ((Point2D) obj).X && this.Y == ((Point2D) obj).Y;
        }
        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }

        public override string ToString()
        {
            return "Point2D {X: " + X.ToString() + " Y: " + Y.ToString() + " }";
        }
    }
}
