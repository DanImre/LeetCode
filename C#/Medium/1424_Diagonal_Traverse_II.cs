using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_1424
    {
        public Medium_1424()
        {

        }
        public int[] FindDiagonalOrder(IList<IList<int>> nums)
        {
            Dictionary<int, List<int>> dic = new Dictionary<int, List<int>>();

            for (int i = nums.Count - 1; i >= 0; i--)
                for (int j = 0; j < nums[i].Count; j++)
                {
                    int sum = i + j;
                    if(!dic.ContainsKey(sum))
                        dic.Add(sum, new List<int>() { nums[i][j] });
                    else
                        dic[sum].Add(nums[i][j]);
                }

            List<int> solution = new List<int>();
            var sortedKeys = dic.Keys.ToList();
            sortedKeys.Sort();
            foreach (var item in sortedKeys)
                foreach (var i in dic[item])
                    solution.Add(i);

            return solution.ToArray();
        }
    }
}
