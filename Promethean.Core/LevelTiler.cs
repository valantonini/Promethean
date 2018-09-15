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
                    //only assess floor tiles
                    if (level[row, column] != Tile.Floor)
                    {
                        continue;
                    }

                    foreach (var tile in GridPatterns.GridPatternList)
                    {
                        if (SurroundingAreaMatchesPattern(level, new Point(column, row), tile.Pattern))
                        {
                            foreach (var paintPoint in tile.PaintOffsets)
                            {
                                tilePoints.Add(new TilePoint()
                                {
                                    TileType = paintPoint.TileType,
                                    Position = paintPoint.Position.Of(row, column)
                                });
                            }

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

        public static bool SurroundingAreaMatchesPattern(byte[,] level, Point position, byte?[,] pattern)
        {
            var start = new Point(position.X - 1, position.Y - 1);

            for (var row = 0; row < pattern.GetLength(0); row++)
            {
                for (var column = 0; column < pattern.GetLength(1); column++)
                {
                    var maskValue = pattern[row, column];

                    if (maskValue is null)
                    {
                        continue;
                    }

                    var targetValue = level[start.Y + row, start.X + column];

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