using Xunit;
using Promethean.Core;

namespace Promethean.Tests
{
    public class TestRoomTiler
    {
        [Fact]
        public void ShouldDetermingTopLeftCorner()
        {
            var theCorner = new byte[,]{
                {1,1,1},
                {1,0,0},
                {1,0,0}
            };

            var theMask = new byte?[,]{
                {null,1,1},
                {1,0,0},
                {null,0,0}
            };
        }

        public bool GridEqualsMask(byte[,] grid, byte?[,] mask)
        {
            for (var row = 0; row < mask.GetLength(0); row++)
            {
                for (var column = 0; column < mask.GetLength(1); column++)
                {

                }
            }

            return false;
        }

    }
}