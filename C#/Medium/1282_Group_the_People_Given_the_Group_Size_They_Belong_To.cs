using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_1282
    {
        public Medium_1282()
        {

        }
        public IList<IList<int>> GroupThePeople(int[] groupSizes)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            IList<IList<int>> solution = new List<IList<int>>();
            for (int i = 0; i < groupSizes.Length; i++)
            {
                if (!dic.ContainsKey(groupSizes[i]))
                {
                    dic.Add(groupSizes[i], solution.Count);
                    solution.Add(new List<int>());
                }

                solution[dic[groupSizes[i]]].Add(i);

                if (solution[dic[groupSizes[i]]].Count == groupSizes[i])
                    dic.Remove(groupSizes[i]);
            }

            return solution;
        }
    }
}
