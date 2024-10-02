using System.Text;

namespace Hard
{
    internal class _Program
    {
        static void Main(string[] args)
        {
            new Hard_3068();
        }

        public static int[][] DoubleIntArrayFromString(string input)
        {
            if (input[0] == '[')
                input = input.Substring(2, input.Length - 4);

            return input.Split("],[").Select(kk => kk.Split(',').Select(zz => int.Parse(zz)).ToArray()).ToArray();
        }
    }
}