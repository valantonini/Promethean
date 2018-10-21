using System;
using Xunit;
using Promethean.Core;
using FluentAssertions;
using NSubstitute;
using System.Linq;

namespace Promethean.Tests
{
    public class TestMatrixExtensions
    {
        [Fact]
        public void ShouldSpiralOutFromCenter()
        {
            var target = new byte[5, 5];
            var start = new Point(2, 2);

            var positions = target.SpiralOutFromPosition(start).ToList();
            // for (var i = 0; i < positions.Count; i++)
            // {
            //     Console.WriteLine($"positions[{i}].X.Should().Be({positions[i].X});");
            //     Console.WriteLine($"positions[{i}].Y.Should().Be({positions[i].Y});");
            //     Console.WriteLine();
            // }
            positions[0].X.Should().Be(1);
            positions[0].Y.Should().Be(1);

            positions[1].X.Should().Be(1);
            positions[1].Y.Should().Be(2);

            positions[2].X.Should().Be(1);
            positions[2].Y.Should().Be(3);

            positions[3].X.Should().Be(2);
            positions[3].Y.Should().Be(1);

            positions[4].X.Should().Be(2);
            positions[4].Y.Should().Be(3);

            positions[5].X.Should().Be(3);
            positions[5].Y.Should().Be(1);

            positions[6].X.Should().Be(3);
            positions[6].Y.Should().Be(2);

            positions[7].X.Should().Be(3);
            positions[7].Y.Should().Be(3);

            positions[8].X.Should().Be(0);
            positions[8].Y.Should().Be(0);

            positions[9].X.Should().Be(0);
            positions[9].Y.Should().Be(1);

            positions[10].X.Should().Be(0);
            positions[10].Y.Should().Be(2);

            positions[11].X.Should().Be(0);
            positions[11].Y.Should().Be(3);

            positions[12].X.Should().Be(1);
            positions[12].Y.Should().Be(0);

            positions[13].X.Should().Be(1);
            positions[13].Y.Should().Be(1);

            positions[14].X.Should().Be(1);
            positions[14].Y.Should().Be(2);

            positions[15].X.Should().Be(1);
            positions[15].Y.Should().Be(3);

            positions[16].X.Should().Be(2);
            positions[16].Y.Should().Be(0);

            positions[17].X.Should().Be(2);
            positions[17].Y.Should().Be(1);

            positions[18].X.Should().Be(2);
            positions[18].Y.Should().Be(3);

            positions[19].X.Should().Be(3);
            positions[19].Y.Should().Be(0);

            positions[20].X.Should().Be(3);
            positions[20].Y.Should().Be(1);

            positions[21].X.Should().Be(3);
            positions[21].Y.Should().Be(2);

            positions[22].X.Should().Be(3);
            positions[22].Y.Should().Be(3);

        }
    }
}