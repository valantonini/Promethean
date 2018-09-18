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
            var room = new Room();

            room.Width = _random.Next(options.MinRoomWidth, options.MaxRoomWidth);
            room.Height = _random.Next(options.MinRoomHeight, options.MaxRoomHeight);

            var x = _random.Next(options.Border, DetermineMaxPosition(options.Height, room.Height, options.Border));
            var y = _random.Next(options.Border, DetermineMaxPosition(options.Width, room.Width, options.Border));
            room.Position = new Point(x, y);

            return room;
        }

        private static int DetermineMaxPosition(int levelDimension, int roomDimension, int border)
        {
            return levelDimension - roomDimension - (border - 1);
        }

    }
}