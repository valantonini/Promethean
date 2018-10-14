namespace Promethean.Core
{
    public static class RoomExtensions
    {
        public static bool Intersects(this Room source, Room target, int buffer)
        {
            if (source.BottomRight.Y + buffer < target.TopLeft.Y - buffer || target.BottomRight.Y + buffer < source.TopLeft.Y - buffer)
            {
                return false;
            }

            if (source.BottomRight.X + buffer < target.TopLeft.X - buffer || target.BottomRight.X + buffer < source.TopLeft.X - buffer)
            {
                return false;
            }

            return true;
        }



    }
}