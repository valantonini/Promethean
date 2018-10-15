namespace Promethean.Core
{
    public static class Tile
    {
        public const byte Empty = 1;

        public const byte Floor = 0;

        public const byte TopLeftInsideCorner = 2;
        public const byte TopRightInsideCorner = 3;
        public const byte BottomLeftInsideCorner = 4;
        public const byte BottomRightInsideCorner = 5;

        public const byte TopWall = 6;
        public const byte RightWall = 7;
        public const byte BottomWall = 8;
        public const byte LeftWall = 9;

        public const byte TopLeftOutsideCorner = 10;
        public const byte TopRightOutsideCorner = 11;
        public const byte BottomLeftOutsideCorner = 12;
        public const byte BottomRightOutsideCorner = 13;
    }

    public static class TileMask
    {
        public static readonly byte? wild = null;
        public static readonly byte open = Tile.Empty;
        public static readonly byte blck = Tile.Floor;
    }
}