namespace Promethean.Core
{
    public class Options
    {
        public int LevelWidth { get; set; }
        public int LevelHeight { get; set; }

        public int MinRoomWidth { get; set; }
        public int MaxRoomWidth { get; set; }
        public int MinRoomHeight { get; set; }
        public int MaxRoomHeight { get; set; }

        public int NumberOfRooms { get; set; }

        public int RandomSeed { get; set; }

        public int Border { get; set; }

        public bool OverlapRooms { get; set; }

        public RoomType[] RoomTypes { get; set; }
        public Options()
        {
            LevelWidth = 32;
            LevelHeight = 32;
            MinRoomWidth = 5;
            MaxRoomWidth = 7;
            MinRoomHeight = 5;
            MaxRoomHeight = 7;
            NumberOfRooms = 10;
            RandomSeed = 1;
            Border = 1;
            OverlapRooms = false;
            RoomTypes = new RoomType[] { RoomType.Square, RoomType.Rectangle, RoomType.Cross, RoomType.Diamond };
        }
    }
}