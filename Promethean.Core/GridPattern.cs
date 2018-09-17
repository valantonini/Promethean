namespace Promethean.Core
{
    public class GridPattern
    {
        public string Name { get; set; }

        public byte?[,] Pattern { get; set; }

        public TilePoint[] PaintOffsets { get; set; } = new TilePoint[0];
    }
}