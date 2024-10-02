using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_56
    {
        public Medium_56()
        {
            
            //[[1,6],[8,10],[15,18]]
            int[][] intervals = new int[][]
            {
                new int[] { 1, 3 },
                new int[] { 2, 6 },
                new int[] { 8, 10 },
                new int[] { 15, 18 }
            };
            
            /*
            //[[1,5]]
            int[][] intervals = new int[][]
            {
                new int[] { 1, 4 },
                new int[] { 4, 5 }
            };
            */
            Console.WriteLine("[" + string.Join(",", Merge(intervals).Select(kk => "[" + string.Join(", ", kk) + "]")) + "]");
        }

        public int[][] Merge(int[][] intervals)
        {
            //Sorting, i dont know if needed
            for (int j = 1; j < intervals.Length; j++)
                for (int i = 0; i < intervals.Length - 1; i++)
                    if (intervals[i][0] > intervals[i + 1][0])
                    {
                        var temp = intervals[i];
                        intervals[i] = intervals[i + 1];
                        intervals[i + 1] = temp;
                    }
            List<int[]> solution = new List<int[]>();
            for (int i = 0; i < intervals.Length; i++)
            {
                int[] temp = new int[2];
                temp[0] = intervals[i][0];
                int secondValue = intervals[i][1];
                while (i < intervals.Length-1 && secondValue >= intervals[i + 1][0])
                {
                    ++i;
                    secondValue = Math.Max(secondValue, intervals[i][1]);
                }
                temp[1] = secondValue;
                solution.Add(temp);
            }

            return solution.ToArray();
        }
    }
}
