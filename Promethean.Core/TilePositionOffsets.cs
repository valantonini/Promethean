namespace Promethean.Core
{
    public static class TilePositionOffsets
    {
        public static Point TopLeft => new Point(-1, -1);
        public static Point Top => new Point(-1, 0);
        public static Point TopRight => new Point(-1, 1);

        public static Point Left => new Point(0, -1);
        public static Point Current => new Point(0, 0);
        public static Point Right => new Point(0, 1);
        public static Point BottomLeft => new Point(1, -1);
        public static Point Bottom => new Point(1, 0);
        public static Point BottomRight => new Point(1, 1);

        public static Point Of(this Point point, int row, int column)
        {
            return new Point(row + point.X, column + point.Y);
        }
    }
}