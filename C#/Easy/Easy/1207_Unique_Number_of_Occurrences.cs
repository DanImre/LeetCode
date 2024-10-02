using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_1207
    {
        public Easy_1207()
        {

        }
        public bool UniqueOccurrences(int[] arr)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            foreach (int item in arr)
                if (!dic.ContainsKey(item))
                    dic.Add(item, 1);
                else
                    ++dic[item];

            HashSet<int> hs = new HashSet<int>();
            foreach (var item in dic.Values)
                if (!hs.Add(item))
                    return false;

            return true;
        }
    }
}
