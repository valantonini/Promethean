using System;
using System.Collections.Generic;
using AStar;

namespace Promethean.Core
{
    public class Level
    {
        private byte[,] _level;

        public Level(int width, int height)
        {
            _level = new byte[width, height];
            for (var y = 0; y < _level.GetLength(0); y++)
            {
                for (var x = 0; x < _level.GetLength(1); x++)
                {
                    SetTile(x, y, Tile.Empty);
                }
            }

            _rooms = new List<Room>();
        }
        public void SetTile(Point point, byte tile)
        {
            SetTile(point.X, point.Y, tile);
        }
        public void SetTile(int x, int y, byte tile)
        {
            _level[y, x] = tile;
        }


        private readonly List<Room> _rooms;


        internal void Add(Room room)
        {
            _rooms.Add(room);
        }

        private List<List<PathFinderNode>> GenerateCorridors()
        {
            var paths = new List<List<PathFinderNode>>();
            _rooms.Sort(new DistanceFromOriginComparer());
            for (var index = 0; index < _rooms.Count - 1; index++)
            {
                var current = _rooms[index];
                var next = _rooms[index + 1];
                var pathfinder = new PathFinder(_level, new PathFinderOptions() { Diagonals = false });
                var path = pathfinder.FindPath(
                    start: new AStar.Point(current.RoomCentre.X, current.RoomCentre.Y),
                    end: new AStar.Point(next.RoomCentre.X, next.RoomCentre.Y)
                );
                paths.Add(path);
            }
            return paths;
        }

        public byte[,] Render()
        {
            var paths = GenerateCorridors();

            foreach (var room in _rooms)
            {
                for (var row = 0; row < room.Width; row++)
                {
                    for (var column = 0; column < room.Height; column++)
                    {
                        _level[room.Position.Row + row, room.Position.Column + column] = Tile.Floor;
                    }
                }
            }

            foreach (var path in paths)
            {
                foreach (var node in path)
                {
                    _level[node.Y, node.X] = Tile.Floor;
                }
            }

            _level = _level.Explode(2);

            var tiler = new LevelTiler();
            tiler.TileLevel(_level);

            return _level;
        }
    }
}