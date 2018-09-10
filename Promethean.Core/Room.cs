using System.Drawing;

namespace Promethean.Core
{
    public class Room
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Point Position { get; set; }
        
        public override string ToString()
        {
            return $"Position: [{Position.X}, {Position.Y}], Width: {Width} Height: {Height}";
        }
    }
}