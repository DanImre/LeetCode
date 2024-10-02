using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hard
{
    public class Hard_1326
    {
        public Hard_1326()
        {
            int[] ranges = new int[] { 4, 0, 0, 0, 0, 0, 0, 0, 4 };
            Console.WriteLine(MinTaps(8, ranges));
        }
        //Without sorting
        public int MinTaps(int n, int[] ranges)
        {
            int curr = 0;
            int max = 0;
            int count = 0;

            while (max < n)
            {
                for (int i = 0; i < ranges.Length; i++)
                    if ((i - ranges[i]) <= curr && (i + ranges[i]) > max)
                        max = ranges[i] + i;

                if (curr == max)
                    return -1;

                ++count;
                curr = max;
            }

            return count;
        }
        public int MinTapsWithSorting(int n, int[] ranges)
        {
            (int left, int right)[] intervals = new (int left, int right)[ranges.Length];
            for (int i = 0; i < ranges.Length; i++)
                intervals[i] = (i - ranges[i], i + ranges[i]);

            Array.Sort(intervals, (a, b) => a.left.CompareTo(b.left));

            int count = 0;
            int index = 0;

            int currSpot = 0;

            while (index < intervals.Length)
            {
                int max = 0;
                while (index < intervals.Length && intervals[index].left <= currSpot)
                {
                    max = Math.Max(max, intervals[index].right);
                    Console.WriteLine(index + " :: " + max);
                    ++index;
                }

                if (max <= currSpot)
                    return -1;

                ++count;
                if (max >= n)
                    return count;

                currSpot = max;
            }

            return count;
        }
    }
}
