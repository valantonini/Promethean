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

            #region assertions
            positions[0].X.Should().Be(1);
            positions[0].Y.Should().Be(1);

            positions[1].X.Should().Be(1);
            positions[1].Y.Should().Be(2);

            positions[2].X.Should().Be(1);
            positions[2].Y.Should().Be(3);

            positions[3].X.Should().Be(2);
            positions[3].Y.Should().Be(3);

            positions[4].X.Should().Be(3);
            positions[4].Y.Should().Be(3);

            positions[5].X.Should().Be(3);
            positions[5].Y.Should().Be(2);

            positions[6].X.Should().Be(3);
            positions[6].Y.Should().Be(1);

            positions[7].X.Should().Be(2);
            positions[7].Y.Should().Be(1);

            positions[8].X.Should().Be(0);
            positions[8].Y.Should().Be(0);

            positions[9].X.Should().Be(0);
            positions[9].Y.Should().Be(1);

            positions[10].X.Should().Be(0);
            positions[10].Y.Should().Be(2);

            positions[11].X.Should().Be(0);
            positions[11].Y.Should().Be(3);

            positions[12].X.Should().Be(0);
            positions[12].Y.Should().Be(4);

            positions[13].X.Should().Be(1);
            positions[13].Y.Should().Be(4);

            positions[14].X.Should().Be(2);
            positions[14].Y.Should().Be(4);

            positions[15].X.Should().Be(3);
            positions[15].Y.Should().Be(4);

            positions[16].X.Should().Be(4);
            positions[16].Y.Should().Be(4);

            positions[17].X.Should().Be(4);
            positions[17].Y.Should().Be(3);

            positions[18].X.Should().Be(4);
            positions[18].Y.Should().Be(2);

            positions[19].X.Should().Be(4);
            positions[19].Y.Should().Be(1);

            positions[20].X.Should().Be(4);
            positions[20].Y.Should().Be(0);

            positions[21].X.Should().Be(3);
            positions[21].Y.Should().Be(0);

            positions[22].X.Should().Be(2);
            positions[22].Y.Should().Be(0);

            positions[23].X.Should().Be(1);
            positions[23].Y.Should().Be(0);
            #endregion
        }
        [Fact]
        public void ShouldSpiralOutFromCenter2()
        {
            var start = new Point(6, 6);

            var positions = MatrixExtensions.SpiralOutFromPosition(start, new Point(0, 0), new Point(7, 7)).ToList();

            #region assertions
            positions[0].X.Should().Be(5);
            positions[0].Y.Should().Be(5);

            positions[1].X.Should().Be(5);
            positions[1].Y.Should().Be(6);

            positions[2].X.Should().Be(5);
            positions[2].Y.Should().Be(7);

            positions[3].X.Should().Be(6);
            positions[3].Y.Should().Be(7);

            positions[4].X.Should().Be(7);
            positions[4].Y.Should().Be(7);

            positions[5].X.Should().Be(7);
            positions[5].Y.Should().Be(6);

            positions[6].X.Should().Be(7);
            positions[6].Y.Should().Be(5);

            positions[7].X.Should().Be(6);
            positions[7].Y.Should().Be(5);

            positions[8].X.Should().Be(4);
            positions[8].Y.Should().Be(4);

            positions[9].X.Should().Be(4);
            positions[9].Y.Should().Be(5);

            positions[10].X.Should().Be(4);
            positions[10].Y.Should().Be(6);

            positions[11].X.Should().Be(4);
            positions[11].Y.Should().Be(7);

            positions[12].X.Should().Be(7);
            positions[12].Y.Should().Be(4);

            positions[13].X.Should().Be(6);
            positions[13].Y.Should().Be(4);

            positions[14].X.Should().Be(5);
            positions[14].Y.Should().Be(4);

            positions[15].X.Should().Be(3);
            positions[15].Y.Should().Be(3);

            positions[16].X.Should().Be(3);
            positions[16].Y.Should().Be(4);

            positions[17].X.Should().Be(3);
            positions[17].Y.Should().Be(5);

            positions[18].X.Should().Be(3);
            positions[18].Y.Should().Be(6);

            positions[19].X.Should().Be(3);
            positions[19].Y.Should().Be(7);

            positions[20].X.Should().Be(7);
            positions[20].Y.Should().Be(3);

            positions[21].X.Should().Be(6);
            positions[21].Y.Should().Be(3);

            positions[22].X.Should().Be(5);
            positions[22].Y.Should().Be(3);

            positions[23].X.Should().Be(4);
            positions[23].Y.Should().Be(3);

            positions[24].X.Should().Be(2);
            positions[24].Y.Should().Be(2);

            positions[25].X.Should().Be(2);
            positions[25].Y.Should().Be(3);

            positions[26].X.Should().Be(2);
            positions[26].Y.Should().Be(4);

            positions[27].X.Should().Be(2);
            positions[27].Y.Should().Be(5);

            positions[28].X.Should().Be(2);
            positions[28].Y.Should().Be(6);

            positions[29].X.Should().Be(2);
            positions[29].Y.Should().Be(7);

            positions[30].X.Should().Be(7);
            positions[30].Y.Should().Be(2);

            positions[31].X.Should().Be(6);
            positions[31].Y.Should().Be(2);

            positions[32].X.Should().Be(5);
            positions[32].Y.Should().Be(2);

            positions[33].X.Should().Be(4);
            positions[33].Y.Should().Be(2);

            positions[34].X.Should().Be(3);
            positions[34].Y.Should().Be(2);

            positions[35].X.Should().Be(1);
            positions[35].Y.Should().Be(1);

            positions[36].X.Should().Be(1);
            positions[36].Y.Should().Be(2);

            positions[37].X.Should().Be(1);
            positions[37].Y.Should().Be(3);

            positions[38].X.Should().Be(1);
            positions[38].Y.Should().Be(4);

            positions[39].X.Should().Be(1);
            positions[39].Y.Should().Be(5);

            positions[40].X.Should().Be(1);
            positions[40].Y.Should().Be(6);

            positions[41].X.Should().Be(1);
            positions[41].Y.Should().Be(7);

            positions[42].X.Should().Be(7);
            positions[42].Y.Should().Be(1);

            positions[43].X.Should().Be(6);
            positions[43].Y.Should().Be(1);

            positions[44].X.Should().Be(5);
            positions[44].Y.Should().Be(1);

            positions[45].X.Should().Be(4);
            positions[45].Y.Should().Be(1);

            positions[46].X.Should().Be(3);
            positions[46].Y.Should().Be(1);

            positions[47].X.Should().Be(2);
            positions[47].Y.Should().Be(1);

            positions[48].X.Should().Be(0);
            positions[48].Y.Should().Be(0);

            positions[49].X.Should().Be(0);
            positions[49].Y.Should().Be(1);

            positions[50].X.Should().Be(0);
            positions[50].Y.Should().Be(2);

            positions[51].X.Should().Be(0);
            positions[51].Y.Should().Be(3);

            positions[52].X.Should().Be(0);
            positions[52].Y.Should().Be(4);

            positions[53].X.Should().Be(0);
            positions[53].Y.Should().Be(5);

            positions[54].X.Should().Be(0);
            positions[54].Y.Should().Be(6);

            positions[55].X.Should().Be(0);
            positions[55].Y.Should().Be(7);

            positions[56].X.Should().Be(7);
            positions[56].Y.Should().Be(0);

            positions[57].X.Should().Be(6);
            positions[57].Y.Should().Be(0);

            positions[58].X.Should().Be(5);
            positions[58].Y.Should().Be(0);

            positions[59].X.Should().Be(4);
            positions[59].Y.Should().Be(0);

            positions[60].X.Should().Be(3);
            positions[60].Y.Should().Be(0);

            positions[61].X.Should().Be(2);
            positions[61].Y.Should().Be(0);

            positions[62].X.Should().Be(1);
            positions[62].Y.Should().Be(0);
            #endregion
        }

        private static void PrintPositionOrderMap(List<Point> points)
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
                intMap[p.X, p.Y] = i + 1;
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