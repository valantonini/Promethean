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
                if (rooms.Any(r => r.Intersects(room, options.RoomBorder)))
                {
                    var repositionedRoom = Reposition(rooms, room, options);
                    if (repositionedRoom == null)
                    {
                        return rooms;
                    }
                    room = repositionedRoom.Value;
                }

                rooms.Add(room);
            }

            return rooms;
        }

        private Room? Reposition(List<Room> rooms, Room room, Options options)
        {
            var directions = new Point[] { TilePositionOffsets.Top, TilePositionOffsets.TopRight, TilePositionOffsets.Right, TilePositionOffsets.BottomRight, TilePositionOffsets.Bottom, TilePositionOffsets.BottomLeft, TilePositionOffsets.Left, TilePositionOffsets.TopLeft };

            var count = 1;
            var minX = options.Border;
            var minY = options.Border;
            var maxX = DetermineMaxPosition(options.LevelHeight, room.Height, 1);
            var maxY = DetermineMaxPosition(options.LevelWidth, room.Width, 1);

            Console.WriteLine($"commencing reposition of {room.ToString()}");

            while (true)
            {
                foreach (var direction in directions)
                {
                    var newX = room.Position.X + (direction.X * count);
                    var newY = room.Position.Y + (direction.Y * count);
                    Console.WriteLine($"Attempting [{newX}, {newY}]");
                    if (newX < minX || newX >= maxX)
                    {
                        continue;
                    }

                    if (newY < minY || newY >= maxY)
                    {
                        continue;
                    }

                    var newRoomCandidate = new Room(room.Height, room.Width, newX, newY, room.RoomType);

                    if (!rooms.Any(r => r.Intersects(newRoomCandidate, options.RoomBorder)))
                    {
                        Console.WriteLine($"New position found {newRoomCandidate.ToString()}");
                        return newRoomCandidate;
                    }
                }
                count++;
                if (room.Position.X - count < 0 &&
                   room.Position.X + count >= options.LevelHeight - room.Height - 1 &&
                   room.Position.Y - count < 0 &&
                   room.Position.Y + count >= options.LevelWidth - room.Height - 1)
                {
                    Console.WriteLine($"no new position for {room.ToString()}");
                    return null;
                }
            }

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