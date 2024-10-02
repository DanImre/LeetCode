using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_55
    {
        public Medium_55()
        {
            Console.WriteLine(CanJump2(new int[] { 2, 3, 1, 1, 4 }));
            Console.WriteLine(CanJump2(new int[] { 3, 2, 1, 0, 4 }));
            Console.WriteLine(CanJump2(new int[] { 2, 0, 6, 9, 8, 4, 5, 0, 8, 9, 1, 2, 9, 6, 8, 8, 0, 6, 3, 1, 2, 2, 1, 2, 6, 5, 3, 1, 2, 2, 6, 4, 2, 4, 3, 0, 0, 0, 3, 8, 2, 4, 0, 1, 2, 0, 1, 4, 6, 5, 8, 0, 7, 9, 3, 4, 6, 6, 5, 8, 9, 3, 4, 3, 7, 0, 4, 9, 0, 9, 8, 4, 3, 0, 7, 7, 1, 9, 1, 9, 4, 9, 0, 1, 9, 5, 7, 7, 1, 5, 8, 2, 8, 2, 6, 8, 2, 2, 7, 5, 1, 7, 9, 6 }));
        }
        //Time limit exceded
        public  bool CanJump(int[] nums)
        {
            return recursiveSOlution(nums, nums.Length - 1);
        }

        public  bool recursiveSOlution(int[] nums, int index)
        {
            if (index == 0)
                return true;

            List<int> positionsFromIndex = new List<int>();
            for (int i = 0; i < index; i++)
                if (nums[i] >= index - i)
                    positionsFromIndex.Add(i);

            foreach (var item in positionsFromIndex)
                if (recursiveSOlution(nums, item))
                    return true;

            return false;
        }

        //Second try
        public bool CanJump2(int[] nums)
        {
            if (nums.Length == 1)
                return true;

            bool[] canReachTheEnd = new bool[nums.Length];
            for (int i = 0; i < nums.Length; i++)
                canReachTheEnd[i] = false;

            //Can reach the end in one step
            Stack<int> canReach = new Stack<int>();
            for (int i = 0; i < nums.Length - 1; i++)
                if (nums[i] >= nums.Length - 1 - i)
                {
                    canReach.Push(i);
                    canReachTheEnd[i] = true;
                }

            while (!canReachTheEnd[0] && canReach.Count != 0)
            {
                int actIndex = canReach.Pop();
                for (int i = 0; i < actIndex; i++)
                {
                    if (canReachTheEnd[i])
                        continue;

                    if (nums[i] >= actIndex - i)
                    {
                        canReach.Push(i);
                        canReachTheEnd[i] = true;
                    }
                }
            }

            return canReachTheEnd[0];
        }

        //Correct solution, O(n) time O(1) space
        public bool CanJumpCorrect(int[] nums)
        {

            // The end of the array is true, since that means we are at the solution.
            int nearestTrue = nums.Length - 1;

            // Working backwards through the array we want to check if our current num can jump us to the nearest 'TRUE'.
            for (int i = nums.Length - 2; i >= 0; i--)
            {
                // If we can jump to the nearest true, we become the nearest true.
                if (i + nums[i] >= nearestTrue)
                {
                    nearestTrue = i;
                }
            }

            // If the nearest true is the start, the entire solution is jumpable.
            return nearestTrue == 0;
        }
    }
}
