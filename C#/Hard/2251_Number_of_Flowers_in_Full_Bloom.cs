using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hard
{
    public class Hard_2251
    {
        public Hard_2251()
        {

        }
        public int[] FullBloomFlowers(int[][] flowers, int[] people)
        {
            int[] solution = new int[people.Length];

            //Started blooming before
            Array.Sort(flowers, (a, b) => a[0].CompareTo(b[0]));
            for (int i = 0; i < people.Length; i++)
                solution[i] = BinarySearch(0, people[i], flowers); 

            //Minus already bloomed
            Array.Sort(flowers, (a, b) => a[1].CompareTo(b[1]));
            for (int i = 0; i < people.Length; i++)
                solution[i] -= BinarySearch(1, people[i] - 1, flowers);

            return solution;

        }
        public int BinarySearch(int startOrEnd, int target, int[][] flowers)
        {
            int start = 0;
            int end = flowers.Length;
            while (start < end)
            {
                int mid = start + (end - start) / 2;

                if (flowers[mid][startOrEnd] > target)
                    end = mid;
                else
                    start = mid + 1;
            }

            return start;
        }
    }
}
