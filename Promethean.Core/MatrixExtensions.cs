namespace Promethean.Core
{
    public static class MatrixExtensions
    {
        public static void SetValue(this byte[,] matrix, Point point, byte value)
        {
            matrix[point.Y, point.X] = value;
        }

        public static byte GetValue(this byte[,] matrix, Point point)
        {
            return matrix[point.Y, point.X];
        }
    }
}