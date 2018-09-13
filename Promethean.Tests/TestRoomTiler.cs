using Xunit;
using Promethean.Core;
using FluentAssertions;
using System.Drawing;

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

            var theMask = new byte?[,]{
                {wild,open,open},
                {open,blck,blck},
                {wild,blck,blck}
            };

            LevelTiler.GridEqualsMask(theGrid, new Point(1, 1), theMask).Should().Be(true);
        }
    }
}