using System;
using System.Collections.Generic;
using System.Linq;
using Promethean.Core.RandomGenerator;

namespace Promethean.Core
{
    public class RoomGenerator
    {
        private IPsuedoRandom _random;

        public RoomGenerator(IPsuedoRandom random)
        {
            _random = random;
        }

        public List<Room> GenerateRooms(Options options)
        {
            return options.OverlapRooms
                ? GenerateOverlappingRooms(options)
                : GenerateNonOverlappingRooms(options);
        }

        private List<Room> GenerateOverlappingRooms(Options options)
        {
            var rooms = new List<Room>();
            for (var roomCount = 0; roomCount < options.NumberOfRooms; roomCount++)
            {
                var room = Generate(options);
                rooms.Add(room);
            }
            return rooms;
        }

        private List<Room> GenerateNonOverlappingRooms(Options options)
        {
            var retryLimit = 100;

            var rooms = new List<Room>();
            for (var roomCount = 0; roomCount < options.NumberOfRooms; roomCount++)
            {
                var count = 0;
                var room = Generate(options);
                while (rooms.Any(r => r.Intersects(room, 1)))
                {
                    if (++count == retryLimit)
                    {
                        return rooms;
                    }

                    room = Generate(options);
                }

                rooms.Add(room);
            }

            return rooms;
        }

        private Room Generate(Options options)
        {
            var roomType = options.RoomTypes[_random.Next(1, options.RoomTypes.Length) - 1];

            var roomWidth = _random.NextOdd(options.MinRoomWidth, options.MaxRoomWidth);

            var roomHeight = roomType == RoomType.Rectangle
                                ? _random.NextOdd(options.MinRoomHeight, options.MaxRoomHeight)
                                : roomWidth;

            var roomX = _random.Next(options.Border, DetermineMaxPosition(options.LevelHeight, roomHeight, options.Border));
            var roomY = _random.Next(options.Border, DetermineMaxPosition(options.LevelWidth, roomWidth, options.Border));

            var room = new Room(roomHeight, roomWidth, roomX, roomY, roomType);

            return room;
        }

        private static int DetermineMaxPosition(int levelDimension, int roomDimension, int border)
        {
            return levelDimension - roomDimension - (border - 1);
        }
    }
}