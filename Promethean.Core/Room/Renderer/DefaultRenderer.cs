namespace Promethean.Core
{
    public class DefaultRenderer : IRoomRenderer
    {
        public byte[,] GetTiles(Room room)
        {
            var arr = new byte[room.Height, room.Width];
            for (var x = 0; x < room.Height; x++)
            {
                for (var y = 0; y < room.Width; y++)
                {
                    arr[x, y] = Tile.Floor;
                }
            }
            return arr;
        }
    }
}