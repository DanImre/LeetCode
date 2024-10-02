using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_347
    {
        public Medium_347()
        {
            
        }
        public int[] TopKFrequent(int[] nums, int k)
        {
            Dictionary<int, int> counts = new Dictionary<int, int>();

            foreach (var item in nums)
                if(!counts.ContainsKey(item))
                    counts.Add(item, 1);
                else
                    counts[item]++;

            return counts.OrderByDescending(x => x.Value).Take(k).Select(kk => kk.Key).ToArray();
        }
    }
}
