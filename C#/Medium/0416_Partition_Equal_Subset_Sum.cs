using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_416
    {
        public Medium_416()
        {

        }
        public int[] Nums = null!;
        public Dictionary<(int, int), bool> Memo = null!;
        public int Target = 0;
        public bool CanPartition(int[] nums)
        {
            int sum = nums.Sum();
            if (sum % 2 == 1)
                return false;
            
            Nums = nums;
            Memo = new Dictionary<(int, int), bool>();
            Target = sum / 2;

            return Backtrack(0, 0);
        }

        public bool Backtrack(int index, int sum)
        {
            if (sum >= Target)
                return sum == Target;
            if (index == Nums.Length)
                return false;

            if(Memo.ContainsKey((index,sum)))
                return Memo[(index, sum)];

            bool solution = Backtrack(index + 1, sum) || Backtrack(index + 1, sum + Nums[index]);
            Memo[(index, sum)] = solution;

            return solution;
        }
    }
}
