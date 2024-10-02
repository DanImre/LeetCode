using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Medium
{
    public class Medium_120
    {
        public Medium_120()
        {
            
        }
        public int MinimumTotal(IList<IList<int>> triangle)
        {
            for (int i = triangle.Count - 2; i >= 0; i--)
                for (int j = 0; j <= i; j++)
                    triangle[i][j] += Math.Min(triangle[i + 1][j], triangle[i + 1][j + 1]);

            return triangle[0][0];
        }
    }
}
