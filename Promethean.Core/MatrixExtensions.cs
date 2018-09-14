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

        public static byte[,] Explode(this byte[,] matrix, int explodeFactor)
        {
            var exploded = new byte[matrix.GetLength(0) * explodeFactor, matrix.GetLength(1) * explodeFactor];
            for (var row = 0; row < matrix.GetLength(0); row++)
            {
                for (var column = 0; column < matrix.GetLength(1); column++)
                {
                    for (var xR = 0; xR < explodeFactor; xR++)
                    {
                        for (var xY = 0; xY < explodeFactor; xY++)
                        {
                            exploded[row * explodeFactor + xR, column * explodeFactor + xY] = matrix[row, column];
                        }
                    }
                }
            }
            return exploded;
        }
    }
}