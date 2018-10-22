using System;
using Xunit;
using Promethean.Core;
using FluentAssertions;
using NSubstitute;
using System.Linq;
using System.Collections.Generic;

namespace Promethean.Tests
{
    public class TestMatrixExtensions
    {
        [Fact]
        public void ShouldSpiralOutFromCenter()
        {
            var start = new Point(2, 2);

            var positions = MatrixExtensions.SpiralOutFromPosition(start, new Point(0, 0), new Point(4, 4)).ToList();
            PrintPositions(positions);
        }
        [Fact]
        public void ShouldSpiralOutFromCenter2()
        {
            var start = new Point(8, 8);

            var positions = MatrixExtensions.SpiralOutFromPosition(start, new Point(0, 0), new Point(9, 9)).ToList();
            PrintPositions(positions);
        }

        private static void PrintPositions(List<Point> points)
        {
            var minX = points.Min(p => p.X);
            var maxX = points.Max(p => p.X);
            var minY = points.Min(p => p.Y);
            var maxY = points.Max(p => p.Y);

            var height = maxX - minX + 1;
            var width = maxY - minY + 1;

            var intMap = new int[height, width];

            for (var i = 0; i < points.Count; i++)
            {
                var p = points[i];
                intMap[p.X, p.Y] = i;
            }

            Console.WriteLine(TextRenderer.RenderAsString(intMap));
        }

        private static void PrintAssertions(List<Point> positions)
        {
            for (var i = 0; i < positions.Count; i++)
            {
                Console.WriteLine($"positions[{i}].X.Should().Be({positions[i].X});");
                Console.WriteLine($"positions[{i}].Y.Should().Be({positions[i].Y});");
                Console.WriteLine();
            }
        }

        private static void PrintPoints(List<Point> positions)
        {
            for (var i = 0; i < positions.Count; i++)
            {
                Console.WriteLine($"{positions[i].ToString()}");
            }
        }
    }
}