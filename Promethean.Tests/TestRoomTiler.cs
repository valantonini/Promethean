using Xunit;
using Promethean.Core;
using FluentAssertions;

namespace Promethean.Tests
{
    public class TestRoomTiler
    {
        [Fact]
        public void ShouldDetermingTopLeftCorner()
        {
            var wild = TileMask.wild;
            var open = TileMask.open;
            var blck = TileMask.blck;

            var theGrid = new byte[,]{
                {open,open,open},
                {open,blck,blck},
                {open,blck,blck}
            };

            var level = new Level(3, 3);
            for (var y = 0; y < theGrid.GetLength(0); y++)
            {
                for (var x = 0; x < theGrid.GetLength(1); x++)
                {
                    level.SetTileByXandY(x, y, theGrid[y, x]);
                }
            }

            var theMask = new byte?[,]{
                {wild,open,open},
                {open,blck,blck},
                {wild,blck,blck}
            };

            LevelTiler.SurroundingAreaMatchesPattern(level, new Point(1, 1), theMask).Should().Be(true);
        }
    }
}