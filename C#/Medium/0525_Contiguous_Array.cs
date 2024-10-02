using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class _0525_Contiguous_Array
    {
        public int FindMaxLength(int[] nums)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();

            int sum = 0;
            int wl = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i] == 0 ? -1 : 1;
                if (sum == 0)
                    wl = i + 1;
                else if (dic.ContainsKey(sum))
                    wl = Math.Max(wl, i - dic[sum]);
                else
                    dic.Add(sum, i);
            }

            return wl;
        }
    }
}
