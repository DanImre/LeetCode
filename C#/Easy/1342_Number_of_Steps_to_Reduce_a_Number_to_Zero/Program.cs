namespace _1342_Number_of_Steps_to_Reduce_a_Number_to_Zero
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(NumberOfSteps3(14));
            Console.WriteLine(NumberOfSteps3(8));
            Console.WriteLine(NumberOfSteps3(123));
        }

        //Obvious solution
        public static int NumberOfSteps(int num)
        {
            int count = 0;
            while (num != 0)
            {
                ++count;
                if (num % 2 == 1)
                    --num;
                else
                    num /= 2;
            }

            return count;
        }

        //Faster solution in theory
        public static int NumberOfSteps2(int num)
        {
            if (num == 0)
                return 0;

            int count = 1;

            while (Math.Log2(num) % 1.0 != 0.0)
            {
                ++count;
                if (num % 2 == 1)
                    --num;
                else
                    num /= 2;
            }

            return count + (int)Math.Log2(num);
        }

        //rec
        public static int NumberOfSteps3(int num)
        {
            int count = 0;

            while (num % 2 == 0 && num != 0)
            {
                num /= 2;
                ++count;
            }

            if (num == 0)
                return count;
            else
                return count + 1 + NumberOfSteps3((num - 1));

        }
    }
}