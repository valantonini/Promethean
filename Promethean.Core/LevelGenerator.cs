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
            var level = new Level(_options.Width, _options.Height);

            var rooms = GenerateRooms(_options).ToList();
            var corridors = GenerateCorridors(level, rooms).ToList();

            RenderRoomsOnLevel(level, rooms);
            RenderCorridorsOnLevel(level, corridors);

            level.Inflate(2);

            _levelTiler.TileLevel(level);

            return level;
        }

        private IEnumerable<Room> GenerateRooms(Options options)
        {
            for (var roomCount = 0; roomCount < _options.NumberOfRooms; roomCount++)
            {
                var room = _roomGenerator.Generate(_options);
                yield return room;
            }
        }

        private IEnumerable<List<Point>> GenerateCorridors(Level level, List<Room> rooms)
        {
            return _corridorGenerator.Generate(level, rooms);
        }

        private static void RenderRoomsOnLevel(Level level, List<Room> rooms)
        {
            foreach (var room in rooms)
            {
                for (var rowOffset = 0; rowOffset < room.Height; rowOffset++)
                {
                    for (var columnOffset = 0; columnOffset < room.Width; columnOffset++)
                    {
                        var row = room.Position.Row + rowOffset;
                        var column = room.Position.Column + columnOffset;
                        level.SetTileByRowAndColumn(row, column, Tile.Floor);
                    }
                }
            }
        }

        private static void RenderCorridorsOnLevel(Level level, List<List<Point>> corridors)
        {
            foreach (var corridor in corridors)
            {
                foreach (var point in corridor)
                {
                    level.SetTile(point, Tile.Floor);
                }
            }
        }
    }
}