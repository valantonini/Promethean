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

        public Level(int height, int width)
        {
            _level = new byte[height, width];
            for (var x = 0; x < height; x++)
            {
                for (var y = 0; y < width; y++)
                {
                    _level[x, y] = Tile.Empty;
                }
            }
        }

        public void SetTile(int x, int y, byte tile)
        {
            _level[x, y] = tile;
        }

        public byte this[Point point]
        {
            get => _level[point.X, point.Y];
            set => SetTile(point.X, point.Y, value);
        }

        public byte this[int x, int y]
        {
            get => _level[x, y];
            set => SetTile(x, y, value);
        }

        public List<Point> FindPath(Point start, Point end)
        {
            var pathfinder = new PathFinder(_level, new PathFinderOptions() { Diagonals = false });

            var path = pathfinder.FindPath(
                start: new AStar.Point(start.X, start.Y),
                end: new AStar.Point(end.X, end.Y)
            );

            var pointPath = path.Select(node => new Point(node.X, node.Y)).ToList();

            return pointPath;
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