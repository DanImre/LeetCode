using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_786
    {
        public Medium_786()
        {

        }
        public int[] KthSmallestPrimeFraction(int[] arr, int k)
        {
            PriorityQueue<(int numeratorIdx, int denominatorIdx), double> prq = new PriorityQueue<(int numerator, int denominator), double>();

            for (int i = 0; i < arr.Length; i++)
                prq.Enqueue((i, arr.Length - 1), (double)arr[i] / arr[arr.Length-1]);

            while (--k > 0)
            {
                var cur = prq.Dequeue();
                int numeratorIndex = cur.numeratorIdx;
                int denominatorIndex = cur.denominatorIdx - 1;
                if (denominatorIndex > numeratorIndex)
                    prq.Enqueue((numeratorIndex, denominatorIndex), (double)arr[numeratorIndex] / arr[denominatorIndex]);
            }

            var solution = prq.Dequeue();
            return new int[] { arr[solution.numeratorIdx], arr[solution.denominatorIdx] };
        }
    }
}
