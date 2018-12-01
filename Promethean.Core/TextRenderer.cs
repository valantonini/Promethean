using System.Text;

namespace Promethean.Core
{
    public static class TextRenderer
    {
        public static string RenderAsString(byte[,] arr)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine();

            for (var x = 0; x < arr.GetLength(0); x++)
            {
                for (var y = 0; y < arr.GetLength(1); y++)
                {
                    stringBuilder.Append(arr[x, y]);
                }
                stringBuilder.Append(System.Environment.NewLine);
            }

            return stringBuilder.ToString();
        }

        public static string RenderAsString(int[,] arr)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine();

            for (var x = 0; x < arr.GetLength(0); x++)
            {
                for (var y = 0; y < arr.GetLength(1); y++)
                {
                    stringBuilder.Append(arr[x, y].ToString().PadLeft(3, '0'));
                    stringBuilder.Append(' ');
                }
                stringBuilder.Append(System.Environment.NewLine);
                stringBuilder.Append(System.Environment.NewLine);
            }

            return stringBuilder.ToString();
        }

        public static string RenderAsString(byte?[,] arr)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine();
            for (var x = 0; x < arr.GetLength(0); x++)
            {
                for (var y = 0; y < arr.GetLength(1); y++)
                {
                    stringBuilder.Append(arr[x, y]?.ToString() ?? "x");
                }
                stringBuilder.Append(System.Environment.NewLine);
            }

            return stringBuilder.ToString();
        }
    }
}