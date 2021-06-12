﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
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
    }
}
