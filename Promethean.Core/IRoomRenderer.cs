using System;

namespace Promethean.Core
{
    public interface IRoomRenderer
    {
        byte[,] GetTiles(Room room);
    }

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

    public class RoomRenderers
    {
        private static volatile RoomRenderers _instance = null;
        private static readonly object _lock = new object();
        private RoomRenderers() { }

        public static RoomRenderers Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new RoomRenderers();
                        }
                    }
                }
                return _instance;
            }
        }

        public IRoomRenderer this[RoomType roomType]
        {
            get
            {
                switch (roomType)
                {
                    case RoomType.Square:
                    case RoomType.Rectangle:
                        return DefaultRenderer;

                    case RoomType.Cross:
                        return CrossRenderer;

                    case RoomType.Diamond:
                        return DiamondRenderer;

                    default:
                        throw new NotImplementedException($"Room renderer {roomType} not implemented");
                }
            }
        }

        public IRoomRenderer CrossRenderer = new CrossRenderer();
        public IRoomRenderer DefaultRenderer = new DefaultRenderer();
        public IRoomRenderer DiamondRenderer = new DiamondRenderer();
    }
}