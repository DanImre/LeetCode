using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_435
    {
        public Medium_435()
        {

        }
        //Time Limit Exceeded
        public int EraseOverlapIntervals1(int[][] intervals)
        {
            Array.Sort(intervals, (a,b) => a[0].CompareTo(b[0]));
            //cant really use dp..

            int solution = int.MaxValue;

            Queue<(int index, int skipped, int time)> q = new Queue<(int index, int skipped, int time)>();
            q.Enqueue((0, 0, int.MinValue));
            while (q.Count != 0)
            {
                var curr = q.Dequeue();

                if (solution <= curr.skipped) //Already found a better solution
                    continue;

                if (curr.index == intervals.Length)
                {
                    solution = curr.skipped;
                    continue;
                }

                //Two options, skip or not
                q.Enqueue((curr.index + 1, curr.skipped + 1, curr.time)); //Skip

                if (intervals[curr.index][0] >= curr.time) //If its an opcion not to skip
                    q.Enqueue((curr.index + 1, curr.skipped, intervals[curr.index][1]));
            }

            return solution;
        }
        //Correct solution, sort by end, not start
        public int EraseOverlapIntervals(int[][] intervals)
        {
            Array.Sort(intervals, (a, b) => a[1].CompareTo(b[1]));

            int count = 0;
            int time = intervals[0][1];

            for (int i = 1; i < intervals.Length; i++)
                if (intervals[i][0] < time)
                    count++;
                else
                    time = intervals[i][1];

            return count;
        }
    }
}
