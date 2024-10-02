using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_2483
    {
        public Medium_2483()
        {
            Console.WriteLine(BestClosingTime("YYNY"));
            
            Console.WriteLine(BestClosingTime("NNNNN"));
            Console.WriteLine(BestClosingTime("YYYY"));
            Console.WriteLine(BestClosingTime("Y"));
            Console.WriteLine(BestClosingTime("N"));
        }
        public int BestClosingTime(string customers)
        {
            int[] left = new int[customers.Length + 1];
            for (int i = 0; i < customers.Length; i++)
            {
                left[i + 1] = left[i];
                if (customers[i] == 'N')
                    ++left[i + 1];
            }

            int[] right = new int[customers.Length + 1];
            for (int i = customers.Length - 1; i >= 0; i--)
            {
                right[i] = right[i + 1];
                if (customers[i] == 'Y')
                    ++right[i];
            }


            int min = int.MaxValue;
            int minI = -1;
            for (int i = 0; i < customers.Length + 1; i++)
            {
                int tempSum = left[i] + right[i];
                if (tempSum >= min)
                    continue;

                min = tempSum;
                minI = i;
            }

            return minI;
        }
    }
}
