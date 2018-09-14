using System.Collections.Generic;

namespace Promethean.Core
{
    public class LevelTiler
    {
        public void TileLevel(byte[,] level)
        {
            for (var row = 1; row < level.GetLength(0) - 1; row++)
            {
                for (var column = 1; column < level.GetLength(1) - 1; column++)
                {
                    foreach (var tile in TileTypes.TileTypeList)
                    {
                        if (GridEqualsMask(level, new Point(column, row), tile.Mask))
                        {
                            level[row, column] = tile.Value;
                            break;
                        }
                    }

                }
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

    public class TileType
    {
        public string Name { get; set; }

        public byte Value { get; set; }

        public byte?[,] Mask { get; set; }
    }

    public static class TileTypes
    {
        private static byte? wild = TileMask.wild;
        private static byte open = TileMask.open;
        private static byte blck = TileMask.blck;
        public static List<TileType> TileTypeList = new List<TileType>(){
            new TileType
            {
                Name = "Top Left Inside Corner",
                Value = Tile.TopLeftInsideCorner,
                Mask = new byte?[,]{
                    {wild,open,open},
                    {open,blck,blck},
                    {wild,blck,blck}
                }
            },

            new TileType
            {
                Name = "Top Right Inside Corner",
                Value = Tile.TopRightInsideCorner,
                Mask = new byte?[,]{
                    {open,open,wild},
                    {blck,blck,open},
                    {blck,blck,wild}
                }
            },

            new TileType
            {
                Name = "Bottom Left Inside Corner",
                Value = Tile.BottomLeftInsideCorner,
                Mask = new byte?[,]{
                    {open,blck,blck},
                    {open,blck,blck},
                    {wild,open,wild}
                }
            },

            new TileType
            {
                Name = "Bottom Right Inside Corner",
                Value = Tile.BottomRightInsideCorner,
                Mask = new byte?[,]{
                    {blck,blck,open},
                    {blck,blck,open},
                    {wild,open,wild}
                }
            }
        };
    }
}