using System;
using Promethean.Core.RandomGenerator;

namespace Promethean.Core
{
    public class LevelGenerator
    {
        private readonly Options _options;
        private readonly IPsuedoRandom _random;

        public LevelGenerator(Options options)
        {
            _options = options;
            _random = new PsuedoRandom(options.RandomSeed);
        }

        public byte[,] Generate()
        {
            var level = new Level(_options.Width, _options.Height);
            var roomGenerator = new RoomGenerator(_random);

            for (var roomCount = 0; roomCount < _options.NumberOfRooms; roomCount++)
            {
                var room = roomGenerator.Generate(_options);
                level.Add(room);
            }

            return level;
        }
    }
}