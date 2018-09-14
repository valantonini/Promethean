namespace Promethean.Core
{
    public class GridPattern
    {
        public string Name { get; set; }

        public byte TileToApply { get; set; }

        public byte?[,] Pattern { get; set; }

        public Point OffsetToApplyTile { get; set; } = TilePositionOffsets.Current;

    }
}