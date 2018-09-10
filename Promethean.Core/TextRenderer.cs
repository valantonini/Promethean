using System.Text;

namespace Promethean.Core
{
    public static class TextRenderer
    {
        public static string RenderAsString(byte[,] arr)
        {
            var stringBuilder = new StringBuilder();

            for (var row = 0; row < arr.GetLength(0); row++)
            {
                for (var column = 0; column < arr.GetLength(1); column++)
                {
                    stringBuilder.Append(arr[row, column]);
                }
                stringBuilder.Append(System.Environment.NewLine);
            }

            return stringBuilder.ToString();
        }
    }
}