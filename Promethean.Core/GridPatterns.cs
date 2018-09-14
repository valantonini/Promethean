using System.Collections.Generic;

namespace Promethean.Core
{
    public static class GridPatterns
    {
        private static byte? wild = TileMask.wild;
        private static byte open = TileMask.open;
        private static byte blck = TileMask.blck;
        public static List<GridPattern> GridPatternList = new List<GridPattern>(){
            new GridPattern
            {
                Name = "Top Left Inside Corner",
                TileToApply = Tile.TopLeftInsideCorner,
                Pattern = new byte?[,]{
                    {wild,open,open},
                    {open,blck,blck},
                    {wild,blck,blck}
                },
                OffsetToApplyTile = TilePositionOffsets.TopLeft
            },

            new GridPattern
            {
                Name = "Top Right Inside Corner",
                TileToApply = Tile.TopRightInsideCorner,
                Pattern = new byte?[,]{
                    {open,open,wild},
                    {blck,blck,open},
                    {blck,blck,wild}
                },
                OffsetToApplyTile = TilePositionOffsets.TopRight
            },

            new GridPattern
            {
                Name = "Bottom Left Inside Corner",
                TileToApply = Tile.BottomLeftInsideCorner,
                Pattern = new byte?[,]{
                    {open,blck,blck},
                    {open,blck,blck},
                    {wild,open,wild}
                },
                OffsetToApplyTile = TilePositionOffsets.BottomLeft
            },

            new GridPattern
            {
                Name = "Bottom Right Inside Corner",
                TileToApply = Tile.BottomRightInsideCorner,
                Pattern = new byte?[,]{
                    {blck,blck,open},
                    {blck,blck,open},
                    {wild,open,wild}
                },
                OffsetToApplyTile = TilePositionOffsets.BottomRight
            }
        };
    }
}