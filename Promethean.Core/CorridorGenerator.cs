using System.Collections.Generic;
using System.Linq;

namespace Promethean.Core
{
    public class CorridorGenerator
    {

        public IEnumerable<List<Point>> Generate(Level level, List<Room> rooms)
        {
            rooms.Sort(new RoomDistanceFromOriginComparer());

            for (var index = 0; index < rooms.Count - 1; index++)
            {
                var current = rooms[index];
                var next = rooms[index + 1];

                var path = level.FindPath(start: current.RoomCentre, end: next.RoomCentre);

                yield return path;
            }
        }
    }
}