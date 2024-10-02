using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_452
    {
        public Medium_452()
        {
            //2
            //string s = "10,16],[2,8],[1,6],[7,12";

            //4
            //string s = "1,2],[3,4],[5,6],[7,8";

            //2
            string s = "1,2],[2,3],[3,4],[4,5";

            int[][] points = s.Split("],[").Select(kk => kk.Split(",").Select(zz => int.Parse(zz)).ToArray()).ToArray();
            Console.WriteLine(FindMinArrowShots(points));
        }
        public int FindMinArrowShots(int[][] points)
        {
            //Sort Points
            /* Too slow sort
            for (int i = 0; i < points.Length - 1; i++)
                for (int j = 0; j < points.Length -i - 1; j++)
                {
                    if (points[j][0] > points[j + 1][0])
                    {
                        var temp = points[j];
                        points[j] = points[j + 1];
                        points[j + 1] = temp;
                    }
                }*/

            Array.Sort(points, (x, y) => x[1].CompareTo(y[1]));

            int count = 1;
            int[] currentSection = points[0];
            for (int i = 1; i < points.Length; i++)
            {
                //In
                if (currentSection[0] <= points[i][1] && currentSection[1] >= points[i][0])
                {
                    currentSection[0] = Math.Max(currentSection[0], points[i][0]);
                    currentSection[1] = Math.Min(currentSection[1], points[i][1]);
                } 
                else
                {
                    ++count;
                    currentSection = points[i];
                }
            }

            return count;
        }
    }
}
