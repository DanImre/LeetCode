using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_2125
    {
        public Medium_2125()
        {

        }
        public int NumberOfBeams(string[] bank)
        {
            int solution = 0;

            int prevCount = 0;
            foreach (var item in bank)
            {
                int count = item.Count(kk => kk == '1');
                if (count == 0)
                    continue;

                solution += prevCount * count;
                prevCount = count;
            }

            return solution;
        }
    }
}
