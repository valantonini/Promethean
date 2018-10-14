namespace Promethean.Core
{
    public static class TilePositionOffsets
    {
        public static readonly Point TopLeft = new Point(-1, -1);
        public static readonly Point Top = new Point(-1, 0);
        public static readonly Point TopRight = new Point(-1, 1);

        public static readonly Point Left = new Point(0, -1);
        public static readonly Point Current = new Point(0, 0);
        public static readonly Point Right = new Point(0, 1);
        public static readonly Point BottomLeft = new Point(1, -1);
        public static readonly Point Bottom = new Point(1, 0);
        public static readonly Point BottomRight = new Point(1, 1);

        public static Point Of(this Point point, int row, int column)
        {
            return new Point(row + point.X, column + point.Y);
        }
    }
}