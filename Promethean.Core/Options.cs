namespace Promethean.Core
{
    public class Options
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public int RoomWidth { get; set; }
        public int RoomHeight { get; set; }

        public int NumberOfRooms { get; set; }

        public int RandomSeed { get; set; }

        public int Border { get; set; }
        public Options()
        {
            Width = 32;
            Height = 32;
            RoomWidth = 5;
            RoomHeight = 5;
            NumberOfRooms = 10;
            RandomSeed = 1;
            Border = 1;
        }
    }
}