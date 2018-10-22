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
            var start = new Point(2, 2);

            var positions = MatrixExtensions.SpiralOutFromPosition(start, new Point(0, 0), new Point(4, 4)).ToList();
            // for (var i = 0; i < positions.Count; i++)
            // {
            //     Console.WriteLine($"positions[{i}].X.Should().Be({positions[i].X});");
            //     Console.WriteLine($"positions[{i}].Y.Should().Be({positions[i].Y});");
            //     Console.WriteLine();
            //     Console.WriteLine($"{positions[i].ToString()}");
            // }

        }
        [Fact]
        public void ShouldSpiralOutFromCenter2()
        {
            var start = new Point(8, 8);

            var positions = MatrixExtensions.SpiralOutFromPosition(start, new Point(0, 0), new Point(9, 9)).ToList();

            var intmap = new int[10, 10];
            for (var i = 0; i < positions.Count; i++)
            {
                // Console.WriteLine($"positions[{i}].X.Should().Be({positions[i].X});");
                // Console.WriteLine($"positions[{i}].Y.Should().Be({positions[i].Y});");
                // Console.WriteLine();
                Console.WriteLine($"{positions[i].ToString()}");
                var p = positions[i];
                intmap[p.X, p.Y] = i;
            }
            Console.WriteLine(TextRenderer.RenderAsString(intmap));

        }
    }
}