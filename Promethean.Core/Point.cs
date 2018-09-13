namespace Promethean.Core
{
    public class Point
    {
        private int _x = 0;
        private int _y = 0;

        public int X
        {
            get => _x;
            set => _x = value;
        }

        public int Y
        {
            get => _y;
            set => _y = value;
        }

        public int Row
        {
            get => _y;
            set => _y = value;
        }


        public int Column
        {
            get => _x;
            set => _x = value;
        }

        public Point(int x = 0, int y = 0)
        {
            _x = x;
            _y = y;
        }
    }
}