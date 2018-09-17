using System;

namespace Promethean.Core
{
    public class Point : IEquatable<Point>
    {
        private int _x = 0;
        private int _y = 0;

        public int X
        {
            get => _x;
            set => _x = value;
        }

        public int Y
        {
            get => _y;
            set => _y = value;
        }

        public int Row
        {
            get => _y;
            set => _y = value;
        }


        public int Column
        {
            get => _x;
            set => _x = value;
        }

        public Point(int x = 0, int y = 0)
        {
            _x = x;
            _y = y;
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
    }
}