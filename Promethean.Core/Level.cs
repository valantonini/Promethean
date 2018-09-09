namespace Promethean.Core
{
    public class Level
    {
        private byte[,] _level;

        public Level(int width, int height)
        {
            _level = new byte[width,height];
        }
    }
}