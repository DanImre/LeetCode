using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_3005
    {
        public Easy_3005()
        {

        }
        public int MaxFrequencyElements(int[] nums)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            foreach (int num in nums)
                if (dic.ContainsKey(num))
                    dic[num] += 1;
                else
                    dic.Add(num, 1);

            int max = 0;
            int counter = 0;
            foreach (var item in dic.Values)
                if (max < item)
                {
                    max = item;
                    counter = 1;
                }
                else if (max == item)
                    ++counter;

            return counter * max;
        }
    }
}
