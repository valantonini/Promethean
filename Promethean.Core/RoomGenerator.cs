using System;
using System.Drawing;

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

            room.Position = new Point(){
                X = _random.Next(1, DetermineMaxPosition(options.Width, room.Width)),
                Y = _random.Next(1, DetermineMaxPosition(options.Height, room.Height))
            };

            return room;
        }

        private static int DetermineMaxPosition(int levelDimension, int roomDimension){
            return levelDimension - roomDimension;
        }

    }
}