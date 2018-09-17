using System;

namespace Promethean.Core
{
    ///
    /// <summary>
    /// A point in a matrix. Pxy where X is the row and Y is the column.
    /// </summary>
    public class Point : IEquatable<Point>
    {
        public int X { get; set; }

        public int Y { get; set; }

        public Point(int x = 0, int y = 0)
        {
            X = x;
            Y = y;
        }
        public static bool operator ==(Point a, Point b)
        {
            return a?.X == b?.X && a?.Y == b?.Y;
        }

        public static bool operator !=(Point a, Point b)
        {
            return !(a == b);
        }

        public bool Equals(Point other)
        {
            return X == other?.X && Y == other?.Y;
        }

        public override bool Equals(Object other)
        {
            var point2 = other as Point;

            if (other == null)
            {
                return false;
            }

            return Equals(other);
        }

        public override int GetHashCode()
        {
            return $"[{X},{Y}]".GetHashCode();
        }

        public override string ToString()
        {
            return $"[{X}.{Y}]";
        }
    }
}