namespace Promethean.Core
{
    public class Options
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public int MinRoomWidth { get; set; }
        public int MaxRoomWidth { get; set; }
        public int MinRoomHeight { get; set; }
        public int MaxRoomHeight { get; set; }

        public int NumberOfRooms { get; set; }

        public int RandomSeed { get; set; }

        public int Border { get; set; }
        public Options()
        {
            Width = 32;
            Height = 32;
            MinRoomWidth = 5;
            MaxRoomWidth = 7;
            MinRoomHeight = 5;
            MaxRoomHeight = 7;
            NumberOfRooms = 10;
            RandomSeed = 1;
            Border = 1;
        }
    }
}