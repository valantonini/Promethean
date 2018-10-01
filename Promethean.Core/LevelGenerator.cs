using System;
using System.Collections.Generic;
using Promethean.Core.RandomGenerator;
using System.Linq;

namespace Promethean.Core
{
    public class LevelGenerator
    {
        private readonly Options _options;
        private readonly IPsuedoRandom _random;
        private readonly RoomGenerator _roomGenerator;
        private readonly CorridorGenerator _corridorGenerator;
        private readonly LevelTiler _levelTiler;

        public LevelGenerator(Options options)
        {
            _options = options;
            _random = new PsuedoRandom(options.RandomSeed);
            _roomGenerator = new RoomGenerator(_random);
            _corridorGenerator = new CorridorGenerator();
            _levelTiler = new LevelTiler();
        }


        public Level Generate()
        {
            var level = new Level(_options.Height, _options.Width);

            var rooms = GenerateRooms(_options);
            var corridors = GenerateCorridors(level, rooms);

            RenderRoomsOnLevel(level, rooms);
            RenderCorridorsOnLevel(level, corridors);

            level.Inflate(2);

            _levelTiler.TileLevel(level);

            return level;
        }

        private List<Room> GenerateRooms(Options options)
        {
            var rooms = new List<Room>();
            for (var roomCount = 0; roomCount < _options.NumberOfRooms; roomCount++)
            {
                var room = _roomGenerator.Generate(_options);
                rooms.Add(room);
            }
            return rooms;
        }

        private List<Corridor> GenerateCorridors(Level level, List<Room> rooms)
        {
            return _corridorGenerator.Generate(level, rooms);
        }

        private static void RenderRoomsOnLevel(Level level, List<Room> rooms)
        {
            foreach (var room in rooms)
            {
                for (var xOffset = 0; xOffset < room.Height; xOffset++)
                {
                    for (var yOffset = 0; yOffset < room.Width; yOffset++)
                    {
                        var x = room.Position.X + xOffset;
                        var y = room.Position.Y + yOffset;
                        level[x, y] = Tile.Floor;
                    }
                }
            }
        }

        private static void RenderCorridorsOnLevel(Level level, List<Corridor> corridors)
        {
            foreach (var corridor in corridors)
            {
                foreach (var point in corridor.Tiles)
                {
                    level[point] = Tile.Floor;
                }
            }
        }
    }
}