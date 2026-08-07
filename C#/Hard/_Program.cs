using System.Text;

namespace Hard
{
    internal class _Program
    {
        static void Main(string[] args)
        {
            var solver = new _3348_Smallest_Divisible_Digit_Product_II();
            Console.WriteLine(solver.SmallestNumber("1234", 256));
        }

        public static int[][] DoubleIntArrayFromString(string input)
        {
            if (input[0] == '[')
                input = input.Substring(2, input.Length - 4);

            return input.Split("],[").Select(kk => kk.Split(',').Select(zz => int.Parse(zz)).ToArray()).ToArray();
        }
    }
}