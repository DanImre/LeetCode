using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_165
    {
        public Medium_165()
        {

        }
        public int CompareVersion(string version1, string version2)
        {
            List<int> numbers1 = version1.Split('.').Select(kk => int.Parse(kk)).ToList();
            List<int> numbers2 = version2.Split('.').Select(kk => int.Parse(kk)).ToList();

            while (numbers1.Count < numbers2.Count)
                numbers1.Add(0);
            while (numbers2.Count < numbers1.Count)
                numbers2.Add(0);

            for (int i = 0; i < numbers1.Count; i++)
                if (numbers1[i] < numbers2[i])
                    return -1;
                else if (numbers1[i] > numbers2[i])
                    return 1;

            return 0;
        }
    }
}
