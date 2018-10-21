using System.Collections.Generic;

namespace Promethean.Core
{
    public static class MatrixExtensions
    {
        public static IEnumerable<Point> SpiralOutFromPosition(this byte[,] array, Point startingPosition)
        {
            var directions = new Point[] { TilePositionOffsets.TopLeft, TilePositionOffsets.Top, TilePositionOffsets.TopRight,
                                           TilePositionOffsets.Left , TilePositionOffsets.Right,
                                           TilePositionOffsets.BottomLeft, TilePositionOffsets.Bottom, TilePositionOffsets.BottomRight };

            var minX = 0;
            var minY = 0;
            var maxX = array.GetLength(0) - 1;
            var maxY = array.GetLength(1) - 1;
            var offset = 1;

            while (startingPosition.X - offset >= minX &&
                  startingPosition.X + offset <= maxX &&
                  startingPosition.Y - offset >= minY &&
                  startingPosition.Y + offset <= maxY)
            {

                for (var x = 0 - offset; x <= offset; x++)
                {
                    for (var y = 0 - offset; y <= offset; y++)
                    {
                        var newX = startingPosition.X + x;
                        var newY = startingPosition.Y + y;

                        if (newX < minX || newX >= maxX)
                        {
                            //out of bounds x
                            continue;
                        }

                        if (newY < minY || newY >= maxY)
                        {
                            //out of bounds y
                            continue;
                        }

                        if (newX == startingPosition.X && newY == startingPosition.Y)
                        {
                            //starting pos
                            continue;
                        }

                        yield return new Point(newX, newY);
                    }
                }
                offset++;
            }
        }
    }
}