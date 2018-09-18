
namespace Promethean.Core
{
    public class Room
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Point Position { get; set; }

        public Point RoomCentre => new Point(Position.X + Height / 2, Position.Y + Width / 2);

        public Point TopLeft => Position;
        public Point BottomLeft => new Point(Position.X + Height - 1, Position.Y);

        public Point TopRight => new Point(Position.X, Position.Y + Width - 1);

        public Point BottomRight => new Point(Position.X + Height - 1, Position.Y + Width - 1);

        public override string ToString()
        {
            return $"Position: [{Position.X}, {Position.Y}], Width: {Width} Height: {Height}";
        }
    }
}