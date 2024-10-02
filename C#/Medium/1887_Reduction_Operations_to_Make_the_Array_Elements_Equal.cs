using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_1887
    {
        public int ReductionOperations(int[] nums)
        {
            Dictionary<int,int> frequency = new Dictionary<int,int>();
            foreach (var item in nums)
            {
                if (!frequency.ContainsKey(item))
                    frequency.Add(item, 0);
                ++frequency[item];
            }

            int sum = 0;
            int distinctCount = 0;
            int[] sortedKeys = frequency.Keys.ToArray();
            Array.Sort(sortedKeys);
            foreach (var item in sortedKeys)
            {
                sum += distinctCount * frequency[item];
                ++distinctCount;
            }

            return sum;
        }
    }
}
