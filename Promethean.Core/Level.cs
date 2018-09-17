using System;
using System.Collections.Generic;
using System.Linq;
using AStar;

namespace Promethean.Core
{
    public class Level
    {
        private byte[,] _level;

        public int Height => _level.GetLength(0);
        public int Width => _level.GetLength(1);

        public Level(int width, int height)
        {
            _level = new byte[height, width];
            for (var y = 0; y < _level.GetLength(0); y++)
            {
                for (var x = 0; x < _level.GetLength(1); x++)
                {
                    SetTileByXandY(x, y, Tile.Empty);
                }
            }
        }

        public void SetTile(Point point, byte tile)
        {
            SetTileByRowAndColumn(point.Y, point.X, tile);
        }
        public void SetTileByXandY(int x, int y, byte tile)
        {
            SetTileByRowAndColumn(y, x, tile);
        }

        public void SetTileByRowAndColumn(int row, int column, byte tile)
        {
            _level[row, column] = tile;
        }

        public byte this[Point point]
        {
            get => _level[point.Y, point.X];
            set => SetTile(point, value);
        }

        public byte this[int row, int column]
        {
            get => _level[row, column];
            set => SetTileByRowAndColumn(row, column, value);
        }

        public List<Point> FindPath(Point start, Point end)
        {
            var pathfinder = new PathFinder(_level, new PathFinderOptions() { Diagonals = false });
            var path = pathfinder.FindPath(
                start: new AStar.Point(start.X, start.Y),
                end: new AStar.Point(end.X, end.Y)
            );
            return path.Select(node => new Point(node.X, node.Y)).ToList();
        }

        public byte[,] Render()
        {
            return _level;
        }

        public void Inflate(int inflationFactor)
        {
            var inflatedMatrix = new byte[_level.GetLength(0) * inflationFactor, _level.GetLength(1) * inflationFactor];
            for (var row = 0; row < _level.GetLength(0); row++)
            {
                for (var column = 0; column < _level.GetLength(1); column++)
                {
                    for (var xR = 0; xR < inflationFactor; xR++)
                    {
                        for (var xY = 0; xY < inflationFactor; xY++)
                        {
                            inflatedMatrix[row * inflationFactor + xR, column * inflationFactor + xY] = _level[row, column];
                        }
                    }
                }
            }
            _level = inflatedMatrix;
        }

        public override string ToString()
        {
            return TextRenderer.RenderAsString(_level);
        }
    }
}