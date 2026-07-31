using System.Text;

namespace Hard
{
    internal class _Program
    {
        static void Main(string[] args)
        {
            var solver = new Hard_37();

            //char[][] board = new char[][]
            //{
            //    new char[] { '5', '3', '.', '.', '7', '.', '.', '.', '.' },
            //    new char[] { '6', '.', '.', '1', '9', '5', '.', '.', '.' },
            //    new char[] { '.', '9', '8', '.', '.', '.', '.', '6', '.' },
            //    new char[] { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
            //    new char[] { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
            //    new char[] { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
            //    new char[] { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
            //    new char[] { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
            //    new char[] { '.', '.', '.', '.', '8', '.', '.', '7', '9' }
            //};

            char[][] board = new char[][]
            {
                new char[] { '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                new char[] { '.', '9', '.', '.', '1', '.', '.', '3', '.' },
                new char[] { '.', '.', '6', '.', '2', '.', '7', '.', '.' },
                new char[] { '.', '.', '.', '3', '.', '4', '.', '.', '.' },
                new char[] { '2', '1', '.', '.', '.', '.', '.', '9', '8' },
                new char[] { '.', '.', '.', '.', '.', '.', '.', '.', '.' },
                new char[] { '.', '.', '2', '5', '.', '6', '4', '.', '.' },
                new char[] { '.', '8', '.', '.', '.', '.', '.', '1', '.' },
                new char[] { '.', '.', '.', '.', '.', '.', '.', '.', '.' }
            };

            solver.SolveSudoku(board);

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("----------------------------------------");
            solver.PrintBoard(board);
        }

        public static int[][] DoubleIntArrayFromString(string input)
        {
            if (input[0] == '[')
                input = input.Substring(2, input.Length - 4);

            return input.Split("],[").Select(kk => kk.Split(',').Select(zz => int.Parse(zz)).ToArray()).ToArray();
        }
    }
}