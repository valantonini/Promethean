using System.Collections.Generic;
using System.Drawing;

namespace Promethean.Core
{
    public class LevelTiler
    {
        public void TileLevel(byte[,] level)
        {
            var tileTypeList = new TileTypes();
            for (var row = 1; row < level.GetLength(0) - 1; row++)
            {
                for (var column = 1; column < level.GetLength(1) - 1; column++)
                {
                    foreach (var tile in tileTypeList.TileTypeList)
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

    public class TileTypes
    {
        public List<TileType> TileTypeList = new List<TileType>();

        public TileTypes()
        {
            var topLeft = new TileType
            {
                Name = "Top Left Corner",
                Value = 2,
                Mask = new byte?[,]{
                    {null,1,1},
                    {1,0,0},
                    {null,0,0}
                }
            };
            TileTypeList.Add(topLeft);

            var topRight = new TileType
            {
                Name = "Top Right Corner",
                Value = 3,
                Mask = new byte?[,]{
                    {1,1,null},
                    {0,0,1},
                    {0,0,null}
                }
            };
            TileTypeList.Add(topRight);

            var bottomLeft = new TileType
            {
                Name = "Bottom Left Corner",
                Value = 4,
                Mask = new byte?[,]{
                    {1,0,0},
                    {1,0,0},
                    {null,1,null}
                }
            };
            TileTypeList.Add(bottomLeft);

            var bottomRight = new TileType
            {
                Name = "Bottom Right Corner",
                Value = 5,
                Mask = new byte?[,]{
                    {0,0,1},
                    {0,0,1},
                    {null,1,null}
                }
            };
            TileTypeList.Add(bottomRight);
        }
    }
}