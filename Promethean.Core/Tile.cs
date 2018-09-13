namespace Promethean.Core
{
    public static class Tile
    {
        public static byte? Any => null;

        public static byte Open => 1;

        public static byte Floor => 0;

        public static byte TopLeftInsideCorner => 2;
        public static byte TopRightInsideCorner => 3;
        public static byte BottomLeftInsideCorner => 4;
        public static byte BottomRightInsideCorner => 5;

        public static byte TopWall => 6;
        public static byte RightWall => 7;
        public static byte BottomWall => 8;
        public static byte LeftWall => 9;
        // public static byte Floor => 0;
        // public static byte Floor => 0;

    }

    public static class TileMask
    {
        public static byte? wild => Tile.Any;
        public static byte open => Tile.Open;
        public static byte blck => Tile.Floor;
    }
}