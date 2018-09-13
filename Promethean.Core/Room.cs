
namespace Promethean.Core
{
    public class Room
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Point Position { get; set; }

        public Point RoomCentre => new Point()
        {
            X = Position.X + Width / 2,
            Y = Position.Y + Height / 2
        };

        public Point TopLeft => Position;
        public Point BottomLeft => new Point()
        {
            X = Position.X,
            Y = Position.Y + Height - 1
        };

        public Point TopRight => new Point()
        {
            X = Position.X + Width - 1,
            Y = Position.Y + Height - 1
        };

        public Point BottomRight => new Point()
        {
            X = Position.X + Width - 1,
            Y = Position.Y + Height - 1
        };

        public override string ToString()
        {
            return $"Position: [{Position.X}, {Position.Y}], Width: {Width} Height: {Height}";
        }
    }
}