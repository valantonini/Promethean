using System;

namespace Promethean.Core
{
    public class LevelGenerator
    {
        private const int LevelBorder = 2;
        private readonly Options _options;
        private readonly Random _random;

        public LevelGenerator(Options options)
        {
            _options = options;
            _random = new System.Random(options.RandomSeed);

        }
        public Level Generate()
        {
            var level = new Level(_options.Width + LevelBorder, _options.Height + LevelBorder);
            return level;
        }

        public Room GenerateRoom()
        {
            var x = _random.Next(0 + LevelBorder / 2, _options.Width - LevelBorder - _options.RoomWidth);

            var room = new Room()
            {
            };
            return room;
        }
    }
}