using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_2849
    {
        public Medium_2849()
        {

        }
        public bool IsReachableAtTime(int sx, int sy, int fx, int fy, int t)
        {
            int distX = Math.Abs(fx - sx);
            int distY = Math.Abs(fy - sy);

            if (distX == 0 && distY == 0 && t == 1)
                return false;

            return Math.Max(distX, distY) <= t;
        }
    }
}
