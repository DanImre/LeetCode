using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_1637
    {
        public Medium_1637()
        {

        }

        public int MaxWidthOfVerticalArea(int[][] points)
        {
            Array.Sort(points, (a, b) => a[0].CompareTo(b[0]));

            int solution = 0;
            for (int i = 1; i < points.Length; i++)
                solution = Math.Max(solution, points[i][0] - points[i - 1][0]);

            return solution;
        }
    }
}
