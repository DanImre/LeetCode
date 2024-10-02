using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Medium
{
    public class Medium_39
    {
        public Medium_39()
        {
            HashSet<HashSet<int>> hashHash = new HashSet<HashSet<int>>();
            hashHash.Add(new HashSet<int>() { 1, 2, 3 });

            Console.WriteLine(hashHash.Contains(new HashSet<int>() { 1, 2, 3 }));
        }
        public IList<IList<int>> solutions = new List<IList<int>>();
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            BackStrack(candidates, 0, target, new Stack<int>());

            return solutions;
        }

        public void BackStrack(int[] candidates, int index, int target, Stack<int> chosen)
        {
            if (target == 0)
            {
                solutions.Add(chosen.ToList());
                return;
            }

            for (int i = index; i < candidates.Length; i++)
                if (target - candidates[i] >= 0)
                {
                    chosen.Push(candidates[i]);
                    BackStrack(candidates, i, target - candidates[i], chosen);
                    chosen.Pop();
                }
        }
    }
}
