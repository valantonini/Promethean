using System;
using System.Collections.Generic;

namespace Promethean.Core
{
    public static class MatrixExtensions
    {
        public static IEnumerable<Point> SpiralOutFromPosition(Point startingPosition, Point lowerBound, Point upperBound)
        {
            var offset = 1;
            do
            {
                var topLeft = new Point(startingPosition.X - offset, startingPosition.Y - offset);
                var topRight = new Point(startingPosition.X - offset, startingPosition.Y + offset);
                var bottomRight = new Point(startingPosition.X + offset, startingPosition.Y + offset);
                var bottomLeft = new Point(startingPosition.X + offset, startingPosition.Y - offset);

                if (topLeft.X >= lowerBound.X)
                {
                    for (var y = topLeft.Y; y <= topRight.Y && y <= upperBound.Y; y++)
                    {
                        if (y < lowerBound.Y)
                        {
                            continue;
                        }
                        yield return new Point(topLeft.X, y);
                    }
                }

                if (topRight.Y <= upperBound.Y)
                {
                    for (var x = topRight.X + 1; x < bottomRight.X && x <= upperBound.X; x++)
                    {
                        if (x < lowerBound.X)
                        {
                            continue;
                        }
                        yield return new Point(x, topRight.Y);
                    }
                }

                if (bottomRight.X <= upperBound.X)
                {
                    for (var y = bottomRight.Y; y >= bottomLeft.Y && y >= lowerBound.Y; y--)
                    {
                        if (y > upperBound.Y)
                        {
                            continue;
                        }
                        yield return new Point(bottomRight.X, y);
                    }
                }

                if (bottomLeft.Y >= lowerBound.Y)
                {
                    for (var x = bottomLeft.X - 1; x >= topLeft.X && x >= lowerBound.X + 1; x--)
                    {
                        if (x > upperBound.X)
                        {
                            continue;
                        }
                        yield return new Point(x, bottomLeft.Y);
                    }
                }
                offset++;

                if (startingPosition.X - offset < lowerBound.X &&
                   startingPosition.X + offset > upperBound.X &&
                   startingPosition.Y - offset < lowerBound.Y &&
                   startingPosition.Y + offset > upperBound.Y)
                {
                    break;
                }
            }
            while (true);
            yield break;
        }
    }
}
