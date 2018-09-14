using System.Collections.Generic;

namespace Promethean.Core
{
    public class LevelTiler
    {

        public void TileLevel(byte[,] level)
        {
            var tilePoints = new List<TilePoint>();
            for (var row = 1; row < level.GetLength(0) - 1; row++)
            {
                for (var column = 1; column < level.GetLength(1) - 1; column++)
                {
                    foreach (var tile in TileMasks.TileMaskList)
                    {
                        if (GridEqualsMask(level, new Point(column, row), tile.Mask))
                        {
                            tilePoints.Add(new TilePoint()
                            {
                                TileType = tile.Value,
                                Position = tile.Offset.Of(row, column)
                            });
                            //level[row, column] = tile.Value;
                            break;
                        }
                    }

                }
            }
            foreach (var tilePoint in tilePoints)
            {
                level[tilePoint.Position.Row, tilePoint.Position.Column] = tilePoint.TileType;
            }
        }

        public static bool GridEqualsMask(byte[,] level, Point locationInGridToAsses, byte?[,] mask)
        {
            const byte empty = 1;
            var start = new Point(locationInGridToAsses.X - 1, locationInGridToAsses.Y - 1);

            for (var row = 0; row < mask.GetLength(0); row++)
            {
                for (var column = 0; column < mask.GetLength(1); column++)
                {
                    var maskValue = mask[row, column];

                    if (maskValue is null)
                    {
                        continue;
                    }

                    var targetValue = level[start.Y + row, start.X + column];

                    if (targetValue == empty && maskValue != empty)
                    {
                        return false;
                    }

                    if (targetValue != empty && maskValue == empty)
                    {
                        return false;
                    }

                }
            }

            return true;
        }
    }

    public class TilePoint
    {
        public Point Position { get; set; }
        public byte TileType { get; set; }
    }

    public class TileType
    {
        public string Name { get; set; }

        public byte Value { get; set; }

        public byte?[,] Mask { get; set; }

        public Point Offset { get; set; } = TilePositionOffsets.Current;

    }

    public static class TileMasks
    {
        private static byte? wild = TileMask.wild;
        private static byte open = TileMask.open;
        private static byte blck = TileMask.blck;
        public static List<TileType> TileMaskList = new List<TileType>(){
            new TileType
            {
                Name = "Top Left Inside Corner",
                Value = Tile.TopLeftInsideCorner,
                Mask = new byte?[,]{
                    {wild,open,open},
                    {open,blck,blck},
                    {wild,blck,blck}
                },
                Offset = TilePositionOffsets.TopLeft

            },

            new TileType
            {
                Name = "Top Right Inside Corner",
                Value = Tile.TopRightInsideCorner,
                Mask = new byte?[,]{
                    {open,open,wild},
                    {blck,blck,open},
                    {blck,blck,wild}
                },
                Offset = TilePositionOffsets.TopRight
            },

            new TileType
            {
                Name = "Bottom Left Inside Corner",
                Value = Tile.BottomLeftInsideCorner,
                Mask = new byte?[,]{
                    {open,blck,blck},
                    {open,blck,blck},
                    {wild,open,wild}
                },
                Offset = TilePositionOffsets.BottomLeft
            },

            new TileType
            {
                Name = "Bottom Right Inside Corner",
                Value = Tile.BottomRightInsideCorner,
                Mask = new byte?[,]{
                    {blck,blck,open},
                    {blck,blck,open},
                    {wild,open,wild}
                },
                Offset = TilePositionOffsets.BottomRight
            }
        };
    }

    public static class TilePositionOffsets
    {
        public static Point TopLeft => new Point(-1, -1);
        public static Point Top => new Point(0, -1);
        public static Point TopRight => new Point(1, -1);

        public static Point Left => new Point(-1, 0);
        public static Point Current => new Point(0, 0);
        public static Point Right => new Point(1, 0);
        public static Point BottomLeft => new Point(-1, 1);
        public static Point Bottom => new Point(0, 1);
        public static Point BottomRight => new Point(1, 1);

        public static Point Of(this Point point, int row, int column)
        {
            return new Point(column + point.Column, row + point.Row);
        }
    }
}