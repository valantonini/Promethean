using System;
using System.Collections.Generic;
using System.Linq;
using AStar;

namespace Promethean.Core
{
    public class CorridorGenerator
    {

        public List<Corridor> Generate(Level level, List<Room> rooms)
        {
            var pathableLevel = new byte[level.Height, level.Width];

            for (var x = 1; x < level.Height - 1; x++)
            {
                for (var y = 1; y < level.Width - 1; y++)
                {
                    pathableLevel[x, y] = Tile.Empty;
                }
            }

            foreach (var room in rooms)
            {
                for (var xOffset = 0; xOffset < room.Height; xOffset++)
                {
                    for (var yOffset = 0; yOffset < room.Width; yOffset++)
                    {
                        var x = room.Position.X + xOffset;
                        var y = room.Position.Y + yOffset;

                        if (x == room.RoomCentre.X || y == room.RoomCentre.Y)
                        {
                            pathableLevel[x, y] = Tile.Empty;
                            continue;
                        }

                        pathableLevel[x, y] = Tile.Floor;
                    }
                }
            }

            Console.WriteLine(TextRenderer.RenderAsString(pathableLevel));

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


        // public List<Point> FindPath(Point start, Point end)
        // {
        //     var pathfinder = new PathFinder(_level, new PathFinderOptions() { Diagonals = false });

        //     var path = pathfinder.FindPath(
        //         start: new AStar.Point(start.X, start.Y),
        //         end: new AStar.Point(end.X, end.Y)
        //     );

        //     var pointPath = path.Select(node => new Point(node.X, node.Y)).ToList();

        //     return pointPath;
        // }
    }
}