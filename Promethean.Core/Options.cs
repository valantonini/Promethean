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

        public Options()
        {
            Width = 51;
            Height = 51;
            RoomWidth = 11;
            RoomHeight = 11;
            NumberOfRooms = 7;
            RandomSeed = 1;
        }
    }
}