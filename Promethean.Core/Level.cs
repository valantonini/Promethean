using System;
using System.Collections.Generic;

namespace Promethean.Core
{
    public class Level
    {
        private byte[,] _level;
        private readonly List<Room> _rooms;

        public Level(int width, int height)
        {
            _level = new byte[width, height];
            _rooms = new List<Room>();
        }

        internal void Add(Room room)
        {
            _rooms.Add(room);
        }

        public byte[,] Render()
        {
            foreach (var room in _rooms)
            {
                Console.WriteLine(room.ToString());
                for (var row = 0; row < room.Width; row++)
                {
                    for (var column = 0; column < room.Height; column++)
                    {
                        _level[room.Position.Y + row, room.Position.X + column] = (byte)1;
                    }
                }
            }
            return _level;
        }
    }
}