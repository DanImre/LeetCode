using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hard
{
    public class Hard_2551
    {
        public Hard_2551()
        {
            //4
            Console.WriteLine(PutMarbles(new int[] { 1, 3, 5, 1 }, 2));
        }
        public long PutMarbles(int[] weights, int k)
        {
            //Get all possible pairs:
            int[] pairWeight = new int[weights.Length - 1];
            for (int i = 0; i < weights.Length - 1; i++)
                pairWeight[i] = weights[i] + weights[i + 1];

            Array.Sort(pairWeight);

            /* //These cansel each other out
            long min = weights[0] + weights[weights.Length - 1];
            long max = weights[0] + weights[weights.Length - 1];
            */

            long min = 0;
            long max = 0;

            for (int i = weights.Length - k; i < weights.Length - 1; i++)
                max += pairWeight[i];

            for (int i = 0; i < k-1; i++)
                min += pairWeight[i];

            return max - min;
        }
    }
}
