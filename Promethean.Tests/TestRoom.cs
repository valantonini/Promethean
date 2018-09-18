using System;
using Xunit;
using Promethean.Core;
using FluentAssertions;
using NSubstitute;

namespace Promethean.Tests
{
    public class TestRoom
    {
        [Fact]
        public void ShouldDetermineCorrectRoomCenter()
        {
            var room = new Room();
            room.Position = new Point(3, 5);

            room.Height = 9;
            room.Width = 7;

            room.RoomCentre.X.Should().Be(7);
            room.RoomCentre.Y.Should().Be(8);
        }
    }
}
