using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_229
    {
        public Medium_229()
        {

        }
        public IList<int> MajorityElement(int[] nums)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            foreach (var item in nums)
                if(!dic.ContainsKey(item))
                    dic.Add(item, 1);
                else
                    dic[item]++;

            int limit = nums.Length / 3;
            return dic.Where(kk => kk.Value > limit).Select(kk => kk.Key).ToArray();
        }
    }
}
