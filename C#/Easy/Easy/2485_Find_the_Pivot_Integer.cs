using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_2485
    {
        public int PivotInteger(int n)
        {
            int sum = n * (n + 1) / 2;
            int countingSum = 0;
            for (int i = 1; i <= n; i++)
            {
                countingSum += i;
                sum -= i - 1;
                if (countingSum > sum)
                    return -1;
                if(sum == countingSum)
                    return i;
            }

            return -1;
        }
    }
}
