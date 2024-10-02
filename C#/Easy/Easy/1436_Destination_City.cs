using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_1436
    {
        public Easy_1436()
        {

        }
        public string DestCity(IList<IList<string>> paths)
        {
            Dictionary<string, int> count = new Dictionary<string, int>();
            foreach (var item in paths)
            {
                if (!count.ContainsKey(item[1]))
                    count.Add(item[1], 0);
                if (!count.ContainsKey(item[0]))
                    count.Add(item[0], 0);

                count[item[0]]++;
            }

            foreach (var item in count)
                if (item.Value == 0)
                    return item.Key;

            return "";
        }
    }
}
