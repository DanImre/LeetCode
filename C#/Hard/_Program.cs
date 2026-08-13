using System.Text;

namespace Hard
{
    internal class _Program
    {
        static void Main(string[] args)
        {
            var asd = new _2213_Longest_Substring_of_One_Repeating_Character();
            Console.WriteLine(string.Join(", ", "babacc".ToArray()));
            asd.LongestRepeating("babacc", "bcb", [1, 3, 3]);
        }

        public static int[][] DoubleIntArrayFromString(string input)
        {
            if (input[0] == '[')
                input = input.Substring(2, input.Length - 4);

            return input.Split("],[").Select(kk => kk.Split(',').Select(zz => int.Parse(zz)).ToArray()).ToArray();
        }
    }
}