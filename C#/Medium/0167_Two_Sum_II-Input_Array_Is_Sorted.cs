using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_167
    {
        public Medium_167()
        {
            //int[] numbers = new int[] { 2, 7, 11, 15 }; //[1,2]
            //int[] numbers = new int[] { 2,3,4 }; //[1,3]
            int[] numbers = new int[] { -1,0 }; //[1,2]


            Console.WriteLine("[" + string.Join(", ", TwoSum(numbers,-1)) + "]");
        }
        public int[] TwoSum(int[] numbers, int target)
        {
            int i = 0;
            int j = numbers.Length - 1;

            while (i < j)
            {
                //Using var, cuz it might fit into a byte
                var sum = numbers[i] + numbers[j];

                if (sum == target)
                    return new int[] { i + 1, j + 1 };

                if (sum < target)
                    i++;
                else
                    j--;
            }

            return null;
        }
    }
}
