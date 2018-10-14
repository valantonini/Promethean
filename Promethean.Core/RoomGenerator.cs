using System;
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

        public Room Generate(Options options)
        {

            var roomWidth = _random.Next(options.MinRoomWidth, options.MaxRoomWidth);
            var roomHeight = _random.Next(options.MinRoomHeight, options.MaxRoomHeight);
            var roomX = _random.Next(options.Border, DetermineMaxPosition(options.LevelHeight, roomHeight, options.Border));
            var roomY = _random.Next(options.Border, DetermineMaxPosition(options.LevelWidth, roomWidth, options.Border));

            var room = new Room(roomHeight, roomWidth, roomX, roomY);
            //room.Width = 
            //room.Height = _random.Next(options.MinRoomHeight, options.MaxRoomHeight);

            var x = _random.Next(options.Border, DetermineMaxPosition(options.LevelHeight, room.Height, options.Border));
            var y = _random.Next(options.Border, DetermineMaxPosition(options.LevelWidth, room.Width, options.Border));
            //room.Position = new Point(x, y);

            return room;
        }

        private static int DetermineMaxPosition(int levelDimension, int roomDimension, int border)
        {
            return levelDimension - roomDimension - (border - 1);
        }

    }
}