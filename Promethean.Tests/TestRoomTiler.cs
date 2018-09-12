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
            var theGrid = new byte[,]{
                {1,1,1},
                {1,0,0},
                {1,0,0}
            };

            var theMask = new byte?[,]{
                {null,1,1},
                {1,0,0},
                {null,0,0}
            };

            LevelTiler.GridEqualsMask(theGrid, new Point(1, 1), theMask).Should().Be(true);
        }
    }
}