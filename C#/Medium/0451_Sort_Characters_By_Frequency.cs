using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_451
    {
        public Medium_451()
        {
            //Console.WriteLine(FrequencySort("tree"));
            Console.WriteLine(FrequencySort("cccaaa"));
            Console.WriteLine(FrequencySort("Aabb"));
        }
        public string FrequencySort(string s)
        {
            Dictionary<char, int> dic = new Dictionary<char, int>();

            foreach (var item in s)
                if (dic.ContainsKey(item))
                    dic[item]++;
                else
                    dic.Add(item, 1);

            List<(int, char)> list = new List<(int, char)>();
            foreach (var item in dic)
                list.Add((item.Value, item.Key));

            list.Sort((a, b) => b.Item1.CompareTo(a.Item1));

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
                sb.Append(list[i].Item2, list[i].Item1);

            return sb.ToString();
        }
    }
}
