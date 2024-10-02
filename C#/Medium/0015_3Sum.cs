using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_15
    {
        public Medium_15()
        {
            //int[] nums = new int[] { -1, 0, 1, 2, -1, -4 }; //[[-1,-1,2],[-1,0,1]]
            //int[] nums = new int[] { 0, 0, 0, 0 }; //[[0,0,0]]
            int[] nums = new int[] { -2, 0, 1, 1, 2 }; //[[-2,0,2],[-2,1,1]]

            Console.WriteLine("[" + string.Join(", ", ThreeSum(nums).Select(kk => "[" + kk[0] + ", " + kk[1] + ", " + kk[2] + "]")) + "]"); 
        }
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            List<int> sortedArray = new List<int>(nums);
            sortedArray.Sort();

            HashSet<(int, int, int)> usedTriplets = new HashSet<(int, int, int)>();

            IList<IList<int>> solution = new List<IList<int>>();
            for (int i = 0; i < sortedArray.Count - 2; i++)
            {
                //puts sortedArray[i] to the front
                List<List<int>> temp = TwoSum(i + 1, sortedArray, (-1) * sortedArray[i]);
                foreach (var item in temp)
                {
                    if (usedTriplets.Add((item[0], item[1], item[2])))
                        solution.Add(item);
                }
            }

            return solution;
        }

        //From 167, just modified a bit
        public List<List<int>> TwoSum(int start, List<int> numbers, int target)
        {
            int i = start;
            int j = numbers.Count - 1;

            List<List<int>> solution = new List<List<int>>();

            while (i < j)
            {
                int sum = numbers[i] + numbers[j];

                if (sum == target)
                    solution.Add(new List<int>() { (-1) * target, numbers[i], numbers[j] });
                
                if (sum < target)
                    i++;
                else
                    j--;
            }

            return solution;
        }
    }
}
