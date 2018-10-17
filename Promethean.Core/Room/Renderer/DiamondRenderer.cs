namespace Promethean.Core
{
    public class DiamondRenderer : IRoomRenderer
    {
        public byte[,] GetTiles(Room room)
        {
            var offset = 0;
            var yMiddle = room.Width / 2;
            var arr = new byte[room.Height, room.Width];

            //TODO: ineffecient
            for (var x = 0; x < room.Height; x++)
            {
                for (var y = 0; y < room.Width; y++)
                {
                    arr[x, y] = Tile.Empty;
                }
            }

            for (var x = 0; x < room.Height; x++)
            {
                for (var y = yMiddle - offset; y <= yMiddle + offset; y++)
                {
                    arr[x, y] = Tile.Floor;
                }
                offset = x < room.Height / 2 ? offset + 1 : offset - 1;
            }

            return arr;
        }
    }
}