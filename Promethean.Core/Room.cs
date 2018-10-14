
namespace Promethean.Core
{
    public struct Room
    {
        public Room(int roomHeight, int roomWidth, int roomX, int roomY)
        {
            Height = roomHeight;
            Width = roomWidth;
            Position = new Point(roomX, roomY);
            RoomCentre = new Point(Position.X + Height / 2, Position.Y + Width / 2);
            BottomLeft = new Point(Position.X + Height - 1, Position.Y);
            TopRight = new Point(Position.X, Position.Y + Width - 1);
            BottomRight = new Point(Position.X + Height - 1, Position.Y + Width - 1);
        }

        public int Width { get; private set; }
        public int Height { get; private set; }
        public Point Position { get; private set; }

        public Point TopLeft => Position;
        public Point RoomCentre { get; private set; }
        public Point BottomLeft { get; private set; }
        public Point TopRight { get; private set; }
        public Point BottomRight { get; private set; }

        public override string ToString()
        {
            return $"Position: [{Position.X}, {Position.Y}], Width: {Width} Height: {Height}";
        }
    }
}