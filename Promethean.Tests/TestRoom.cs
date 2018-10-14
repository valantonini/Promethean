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
            var room = new Room(9, 7, 3, 5);

            room.RoomCentre.X.Should().Be(7);
            room.RoomCentre.Y.Should().Be(8);
        }
    }
}
