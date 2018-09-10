using System;
using Xunit;
using Promethean.Core;
using FluentAssertions;
using NSubstitute;

namespace Promethean.Tests
{
    public class TestRommGenerator
    {
        [Fact]
        public void ShouldDetermineCorrectMaxLeavingBorderOf1()
        {
            var options = new Options()
            {
                Width = 100,
                Height = 90,
                RoomWidth = 5,
                RoomHeight = 3
            };

            var mockRandom = Substitute.For<IPsuedoRandom>();
            var roomGenerator = new RoomGenerator(mockRandom);

            roomGenerator.Generate(options);

            mockRandom.Received().Next(1, 95);
            mockRandom.Received().Next(1, 87);
        }
    }
}
