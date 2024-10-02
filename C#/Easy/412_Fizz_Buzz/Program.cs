namespace _412_Fizz_Buzz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            foreach (var item in FizzBuzz(3))
                Console.Write(item + ";");
            Console.WriteLine();

            foreach (var item in FizzBuzz(5))
                Console.Write(item + ";");
            Console.WriteLine();

            foreach (var item in FizzBuzz(15))
                Console.Write(item + ";");
            Console.WriteLine();
        }

        public static IList<string> FizzBuzz(int n)
        {
            IList<string> solution = new List<string>();
            for (int i = 1; i <= n; i++)
            {
                bool three = i % 3 == 0;
                bool five = i % 5 == 0;
                
                if (three && five)
                    solution.Add("FizzBuzz");
                else if (three)
                    solution.Add("Fizz");
                else if (five)
                    solution.Add("Buzz");
                else
                    solution.Add(i.ToString());
            }

            return solution;
        }
    }
}