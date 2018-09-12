using System.Drawing;

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

        public override string ToString()
        {
            return $"Position: [{Position.X}, {Position.Y}], Width: {Width} Height: {Height}";
        }
    }
}