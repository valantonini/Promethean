using System;
using System.Collections.Generic;
using System.Linq;
using AStar;

namespace Promethean.Core
{
    public class CorridorGenerator
    {

        public List<Corridor> Generate(List<Room> rooms, Options options)
        {
            var pathableLevel = GeneratePathingGrid(rooms, options);
            var pathfinder = new PathFinder(pathableLevel, new PathFinderOptions() { Diagonals = false, PunishChangeDirection = true });

            rooms.Sort(new RoomDistanceFromOriginComparer());

            var corridors = new List<Corridor>();

            for (var index = 0; index < rooms.Count - 1; index++)
            {
                var current = rooms[index];
                var next = rooms[index + 1];

                var path = pathfinder.FindPath(
                        start: new AStar.Point(current.RoomCentre.X, current.RoomCentre.Y),
                        end: new AStar.Point(next.RoomCentre.X, next.RoomCentre.Y)
                    );

                if (path == null)
                {
                    Console.WriteLine($"No path from {current.ToString()} to {next.ToString()}");
                    continue;
                }

                var corrdior = new Corridor()
                {
                    Tiles = path.Select(node => new Point(node.X, node.Y)).ToList()
                };

                corridors.Add(corrdior);
            }

            return corridors;
        }



        private byte[,] GeneratePathingGrid(List<Room> rooms, Options options)
        {
            var pathableLevel = new byte[options.LevelHeight, options.LevelWidth];

            for (var x = options.Border; x < options.LevelHeight - options.Border; x++)
            {
                for (var y = options.Border; y < options.LevelWidth - options.Border; y++)
                {
                    pathableLevel[x, y] = PathFinderTile.Pathable;
                }
            }

            foreach (var room in rooms)
            {
                for (var xOffset = 0 - options.RoomBorder; xOffset < room.Height + options.RoomBorder; xOffset++)
                {
                    for (var yOffset = 0 - options.RoomBorder; yOffset < room.Width + options.RoomBorder; yOffset++)
                    {
                        var x = room.Position.X + xOffset;
                        var y = room.Position.Y + yOffset;

                        if (x < 0 + options.Border || x > options.LevelHeight - options.Border)
                        {
                            continue;
                        }

                        if (y < 0 + options.Border || y > options.LevelWidth - options.Border)
                        {
                            continue;
                        }

                        if (x == room.RoomCentre.X || y == room.RoomCentre.Y)
                        {
                            pathableLevel[x, y] = PathFinderTile.Pathable;
                            continue;
                        }

                        pathableLevel[x, y] = PathFinderTile.Blocked;
                    }
                }
            }

            return pathableLevel;
        }
        private class PathFinderTile
        {
            public const byte Pathable = 1;
            public const byte Blocked = 0;
        }
    }

}