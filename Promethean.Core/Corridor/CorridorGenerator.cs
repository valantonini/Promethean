using System.Collections.Generic;
using System.Linq;

namespace Promethean.Core
{
    public class CorridorGenerator
    {

        public List<Corridor> Generate(Level level, List<Room> rooms)
        {
            rooms.Sort(new RoomDistanceFromOriginComparer());

            var corridors = new List<Corridor>();

            for (var index = 0; index < rooms.Count - 1; index++)
            {
                var current = rooms[index];
                var next = rooms[index + 1];

                var corrdior = new Corridor()
                {
                    Tiles = level.FindPath(start: current.RoomCentre, end: next.RoomCentre)
                };

                corridors.Add(corrdior);
            }

            return corridors;
        }
    }
}