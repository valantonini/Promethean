using System;
using System.Drawing;
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

            room.Width = options.RoomWidth;
            room.Height = options.RoomHeight;

            room.Position = new Point()
            {
                X = _random.Next(options.Border, DetermineMaxPosition(options.Width, room.Width, options.Border)),
                Y = _random.Next(options.Border, DetermineMaxPosition(options.Height, room.Height, options.Border))
            };

            return room;
        }

        private static int DetermineMaxPosition(int levelDimension, int roomDimension, int border)
        {
            return levelDimension - roomDimension - (border - 1);
        }

    }
}