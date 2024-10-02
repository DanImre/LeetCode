using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_1481
    {
        public Medium_1481()
        {

        }
        public int FindLeastNumOfUniqueInts(int[] arr, int k)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            foreach (var item in arr)
            {
                if (dic.ContainsKey(item))
                    dic[item]++;
                else
                    dic[item] = 1;
            }

            List<int> list = dic.Select(kk => kk.Value).ToList();
            list.Sort();

            int i = 0;
            while (i < list.Count && (k -= list[i]) >= 0)
                ++i;

            return list.Count - i;
        }
    }
}
