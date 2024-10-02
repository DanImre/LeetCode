using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_57
    {
        public Medium_57()
        {
            
            //[[1,5],[6,9]]
            int[][] intervals = new int[][]
            {
                new int[] { 1, 3 },
                new int[] { 6, 9 }
            };
            int[] newInterval = new int[] { 2, 5 };
            
            /*
            //[[1,2],[3,10],[12,16]]
            int[][] intervals = new int[][]
            {
                new int[] { 1, 2 },
                new int[] { 3, 5 },
                new int[] { 6, 7 },
                new int[] { 8, 10 },
                new int[] { 12, 16 }
            };
            int[] newInterval = new int[] { 4, 8 };
            */
            Console.WriteLine("[" + string.Join(", ", Insert(intervals, newInterval).Select(kk => "[" + string.Join(", ", kk) + "]")) + "]");
        }

        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
            List<int[]> solution = new List<int[]>();

            foreach (var item in intervals)
            {
                if (item[0] > newInterval[1])
                {
                    solution.Add(newInterval);
                    newInterval = item;
                }
                else if (item[1] < newInterval[0])
                {
                    solution.Add(item);
                }
                else
                {
                    newInterval[0] = Math.Min(newInterval[0], item[0]);
                    newInterval[1] = Math.Max(newInterval[1], item[1]);
                }
            }

            solution.Add(newInterval);

            return solution.ToArray();
        }
    }
}
