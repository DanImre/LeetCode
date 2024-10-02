using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_238
    {
        public Medium_238()
        {

        }
        public int[] ProductExceptSelf(int[] nums)
        {
            int productOfAll = 1;
            int numberOfZeros = 0;

            foreach (var item in nums)
            {
                if (item != 0)
                    productOfAll *= item;
                else
                    numberOfZeros++;
            }

            int[] solution = new int[nums.Length];

            if (numberOfZeros == 0)
                for (int i = 0; i < nums.Length; i++)
                    solution[i] = productOfAll / nums[i];
            else if (numberOfZeros == 1)
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] != 0)
                        solution[i] = 0;
                    else
                        solution[i] = productOfAll;
                }
            else
                for (int i = 0; i < nums.Length; i++)
                    solution[i] = 0;

            return solution;
        }
    }
}
