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
                Pattern = new byte?[,]{
                    {open,open,open},
                    {open,blck,blck},
                    {wild,blck,blck}
                },
                PaintOffsets = new TilePoint[]{
                    new TilePoint { TileType = Tile.TopLeftInsideCorner, Position = TilePositionOffsets.TopLeft },
                    new TilePoint { TileType = Tile.TopWall, Position = TilePositionOffsets.Top },
                    new TilePoint { TileType = Tile.LeftWall, Position = TilePositionOffsets.Left }
                }
            },

            new GridPattern
            {
                Name = "Top Right Inside Corner",
                Pattern = new byte?[,]{
                    {open,open,wild},
                    {blck,blck,open},
                    {blck,blck,wild}
                },
                PaintOffsets = new TilePoint[]{
                    new TilePoint { TileType = Tile.TopRightInsideCorner, Position = TilePositionOffsets.TopRight },
                    new TilePoint { TileType = Tile.TopWall, Position = TilePositionOffsets.Top },
                    new TilePoint { TileType = Tile.RightWall, Position = TilePositionOffsets.Right }
                }
            },

            new GridPattern
            {
                Name = "Bottom Left Inside Corner",
                Pattern = new byte?[,]{
                    {open,blck,blck},
                    {open,blck,blck},
                    {wild,open,wild}
                },
                PaintOffsets = new TilePoint[]{
                    new TilePoint { TileType = Tile.BottomLeftInsideCorner, Position = TilePositionOffsets.BottomLeft },
                    new TilePoint { TileType = Tile.BottomWall, Position = TilePositionOffsets.Bottom },
                    new TilePoint { TileType = Tile.LeftWall, Position = TilePositionOffsets.Left }
                }
            },

            new GridPattern
            {
                Name = "Bottom Right Inside Corner",
                Pattern = new byte?[,]{
                    {blck,blck,open},
                    {blck,blck,open},
                    {wild,open,open}
                },
                PaintOffsets = new TilePoint[]{
                    new TilePoint { TileType = Tile.BottomRightInsideCorner, Position = TilePositionOffsets.BottomRight },
                    new TilePoint { TileType = Tile.BottomWall, Position = TilePositionOffsets.Bottom },
                    new TilePoint { TileType = Tile.RightWall, Position = TilePositionOffsets.Right }
                }
            },

            new GridPattern
            {
                Name = "Top Wall",
                Pattern = new byte?[,]{
                    {open,open,open},
                    {blck,blck,blck},
                    {blck,blck,blck}
                },
                PaintOffsets = new TilePoint[]{
                    new TilePoint { TileType = Tile.TopWall, Position = TilePositionOffsets.Top }
                }
            },

            new GridPattern
            {
                Name = "Bottom Wall",
                Pattern = new byte?[,]{
                    {blck,blck,blck},
                    {blck,blck,blck},
                    {open,open,open}
                },
                PaintOffsets = new TilePoint[]{
                    new TilePoint { TileType = Tile.BottomWall, Position = TilePositionOffsets.Bottom }
                }
            },

            new GridPattern
            {
                Name = "Left Wall",
                Pattern = new byte?[,]{
                    {open,blck,blck},
                    {open,blck,blck},
                    {open,blck,blck}
                },
                PaintOffsets = new TilePoint[]{
                    new TilePoint { TileType = Tile.LeftWall, Position = TilePositionOffsets.Left }
                }
            },

            new GridPattern
            {
                Name = "Right Wall",
                Pattern = new byte?[,]{
                    {blck,blck,open},
                    {blck,blck,open},
                    {blck,blck,open}
                },
                PaintOffsets = new TilePoint[]{
                    new TilePoint { TileType = Tile.RightWall, Position = TilePositionOffsets.Right }
                }
            },

            new GridPattern
            {
                Name = "Bottom Left Outside Wall",
                Pattern = new byte?[,]{
                    {blck,open,open},
                    {blck,blck,blck},
                    {blck,blck,blck}
                },
                PaintOffsets = new TilePoint[]{
                    new TilePoint { TileType = Tile.BottomLeftOutsideCorner, Position = TilePositionOffsets.Top }
                }
            },

            new GridPattern
            {
                Name = "Bottom Right Outside Wall",
                Pattern = new byte?[,]{
                    {open,open,blck},
                    {blck,blck,blck},
                    {blck,blck,blck}
                },
                PaintOffsets = new TilePoint[]{
                    new TilePoint { TileType = Tile.BottomRightOutsideCorner, Position = TilePositionOffsets.Top }
                }
            },

            new GridPattern
            {
                Name = "Top Right Outside Wall",
                Pattern = new byte?[,]{
                    {blck,blck,blck},
                    {blck,blck,blck},
                    {open,open,blck}
                },
                PaintOffsets = new TilePoint[]{
                    new TilePoint { TileType = Tile.TopRightOutsideCorner, Position = TilePositionOffsets.Bottom }
                }
            },

            new GridPattern
            {
                Name = "Top Left Outside Wall",
                Pattern = new byte?[,]{
                    {blck,blck,blck},
                    {blck,blck,blck},
                    {blck,open,open}
                },
                PaintOffsets = new TilePoint[]{
                    new TilePoint { TileType = Tile.TopLeftOutsideCorner, Position = TilePositionOffsets.Bottom }
                }
            },

            new GridPattern
            {
                Name = "Top Right Inside For Touching",
                Pattern = new byte?[,]{
                    {blck,open,open},
                    {open,blck,blck},
                    {open,blck,blck}
                },
                PaintOffsets = new TilePoint[]{
                    new TilePoint { TileType = Tile.BottomLeftOutsideCorner, Position = TilePositionOffsets.Top }
                }
            },


            new GridPattern
            {
                Name = "Bottom Right Inside For Touching",
                Pattern = new byte?[,]{
                    {blck,blck,open},
                    {blck,blck,open},
                    {open,open,blck}
                },
                PaintOffsets = new TilePoint[]{
                    new TilePoint { TileType = Tile.TopRightOutsideCorner, Position = TilePositionOffsets.Bottom }
                }
            }
        };
    }
}