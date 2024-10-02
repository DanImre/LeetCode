using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_46
    {
        public Medium_46()
        {
            List<int> list = new List<int>() { 1, 2, 4, 5, 6 };
            list.Insert(2, 3);
            list.RemoveAt(2);

            Console.WriteLine(string.Join(", ", list));
        }

        public List<IList<int>> solution;
        public IList<IList<int>> Permute(int[] nums)
        {
            solution = new List<IList<int>>();

            BackStrack(nums, new HashSet<int>());

            return solution;
        }

        public void BackStrack(int[] nums, HashSet<int> used)
        {
            if (used.Count == nums.Length)
            {
                solution.Add(used.ToList());
                return;
            }

            foreach (var item in nums)
            {
                if (!used.Add(item))
                    continue;

                BackStrack(nums, used);
                used.Remove(item);
            }
        }


    }
}
