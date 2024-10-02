using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_189
    {
        public Medium_189()
        {

        }
        //Easy solution
        public void Rotate(int[] nums, int k)
        {
            int[] numsCopy = new int[nums.Length];
            nums.CopyTo(numsCopy, 0);

            for (int i = 0; i < nums.Count(); i++)
            {
                int indextoPlace = (i + k) % nums.Length;

                nums[indextoPlace] = numsCopy[i];
            }
        }

        //without using additional memory  - O(1) space
        //time limit exceded
        public void Rotate2(int[] nums, int k)
        {
            k %= nums.Length;

            for (int lll = 0; lll < k; lll++)
            {
                //Always push it by one
                int numberToPlace = nums[0];
                for (int i = 0; i < nums.Count() - 1; i++)
                {
                    int temp = nums[i + 1];
                    nums[i + 1] = numberToPlace;
                    numberToPlace = temp;
                }
                nums[0] = numberToPlace;

            }
        }
    }
}
