using System;
using System.Collections.Generic;

namespace Promethean.Core
{
    public class RoomDistanceFromOriginComparer : IComparer<Room>
    {
        public int Compare(Room room1, Room room2)
        {
            var reference = new Point(0, 0);

            var room1DistanceFromReference = CalculateDistanceBetween2Points(reference, room1.RoomCentre);
            var room2DistanceFromReference = CalculateDistanceBetween2Points(reference, room2.RoomCentre);

            return room1DistanceFromReference.CompareTo(room2DistanceFromReference);
        }

        private double CalculateDistanceBetween2Points(Point origin, Point point)
        {
            var XaMinuxXbSquared = Math.Pow(point.X - origin.X, 2);
            var YaMinusYbSquared = Math.Pow(point.Y - origin.Y, 2);

            return Math.Sqrt(XaMinuxXbSquared + YaMinusYbSquared);
        }
    }
}