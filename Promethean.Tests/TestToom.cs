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
            room.Position = new Point()
            {
                X = 3,
                Y = 5
            };
            room.Width = 7;
            room.Height = 9;

            room.RoomCentre.X.Should().Be(6);
            room.RoomCentre.Y.Should().Be(9);
        }
    }
}
