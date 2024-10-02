using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_202
    {
        public Easy_202()
        {
            Console.WriteLine(IsHappy(19));
            Console.WriteLine(IsHappy(2)); //False
        }
        public bool IsHappy(int n)
        {
            HashSet<int> triedNumbers = new HashSet<int>();

            while (n != 1)
            {
                int nextn = 0;
                while (n > 0)
                {
                    int temp = n % 10;
                    nextn += temp * temp;
                    n /= 10;
                }
                n = nextn;

                if (!triedNumbers.Add(n))
                    return false;
            }

            return true;
        }
        public int Pow2EveryDigit(int n)
        {
            int solution = 0;
            while (n > 0)
            {
                int temp = n % 10;
                solution += temp * temp;
                n /= 10;
            }

            return solution;
        }

    }
}
