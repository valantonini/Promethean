namespace Promethean.Core
{
    public class Options
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public int RoomWidth { get; set; }
        public int RoomHeight { get; set; }

        public int NumberOfRooms { get; set; }

        public Options()
        {
            Width = 101;
            Height = 101;
            RoomWidth = 5;
            RoomHeight = 5;
            NumberOfRooms = 7;
        }
    }
}