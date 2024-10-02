using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_1266
    {
        public Easy_1266()
        {

        }
        public int MinTimeToVisitAllPoints(int[][] points)
        {
            int solution = 0;
            for (int i = 1; i < points.Length; i++)
                solution += Math.Max(Math.Abs(points[i - 1][0] - points[i][0]), Math.Abs(points[i - 1][1] - points[i][1]));
            return solution;
        }
    }
}
