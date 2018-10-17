namespace Promethean.Core
{
    public class CrossRenderer : IRoomRenderer
    {
        public byte[,] GetTiles(Room room)
        {
            var arr = new byte[room.Height, room.Width];
            for (var x = 0; x < room.Height; x++)
            {
                for (var y = 0; y < room.Width; y++)
                {
                    var xLowerBound = room.Height * 0.333 - 1;
                    var xUpperBound = room.Height * 0.666;

                    var yLowerBound = room.Width * 0.333 - 1;
                    var yUpperBound = room.Width * 0.666;
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