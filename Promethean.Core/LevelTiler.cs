using System.Collections.Generic;

namespace Promethean.Core
{
    public class LevelTiler
    {
        public void TileLevel(Level level)
        {
            var tilePoints = new List<TilePoint>();

            for (var x = 1; x < level.Height - 1; x++)
            {
                for (var y = 1; y < level.Width - 1; y++)
                {

                    //only assess floor tiles
                    if (level[x, y] != Tile.Floor)
                    {
                        continue;
                    }

                    foreach (var tile in GridPatterns.GridPatternList)
                    {
                        if (SurroundingAreaMatchesPattern(level, new Point(x, y), tile.Pattern))
                        {
                            foreach (var paintPoint in tile.PaintOffsets)
                            {
                                tilePoints.Add(new TilePoint()
                                {
                                    TileType = paintPoint.TileType,
                                    Position = paintPoint.Position.Of(x, y)
                                });
                            }

                            break;
                        }
                    }

                }
            }

            foreach (var tilePoint in tilePoints)
            {
                level[tilePoint.Position.X, tilePoint.Position.Y] = tilePoint.TileType;
            }
        }

        public static bool SurroundingAreaMatchesPattern(Level level, Point position, byte?[,] pattern)
        {
            var start = new Point(position.X - 1, position.Y - 1);

            for (var x = 0; x < pattern.GetLength(0); x++)
            {
                for (var y = 0; y < pattern.GetLength(1); y++)
                {
                    var maskValue = pattern[x, y];

                    if (maskValue is null)
                    {
                        continue;
                    }

                    var targetValue = level[start.X + x, start.Y + y];

                    if (targetValue == maskValue)
                    {
                        continue;
                    }

                    if (targetValue == TileMask.open && maskValue != TileMask.open)
                    {
                        return false;
                    }

                    if (targetValue != TileMask.open && maskValue == TileMask.open)
                    {
                        return false;
                    }

                }
            }

            return true;
        }
    }
}