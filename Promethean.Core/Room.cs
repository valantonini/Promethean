
using System;

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
        public byte[,] GetTiles()
        {
            var arr = new byte[Height, Width];
            for (var x = 0; x < Height; x++)
            {
                for (var y = 0; y < Width; y++)
                {
                    var xLowerBound = Height * 0.333 - 1;
                    var xUpperBound = Height * 0.666;

                    var yLowerBound = Width * 0.333 - 1;
                    var yUpperBound = Width * 0.666;
                    if ((x > xLowerBound && x < xUpperBound) || (y > yLowerBound && y < yUpperBound))
                    {
                        arr[x, y] = Tile.Floor;
                    }
                    else
                    {
                        arr[x, y] = Tile.Empty;
                    }
                }
            }
            return arr;
        }
    }
}