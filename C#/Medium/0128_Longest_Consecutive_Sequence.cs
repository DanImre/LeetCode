using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_128
    {
        public Medium_128()
        {
            //9
            Console.WriteLine(LongestConsecutive(new int[] { 0, 3, 7, 2, 5, 8, 4, 6, 0, 1 }));
        }

        public int LongestConsecutive(int[] nums)
        {
            HashSet<int> hs = new HashSet<int>(nums);

            int longest = 0;

            foreach (var item in hs)
            {
                if (hs.Contains(item - 1))
                    continue;

                int j = item + 1;
                while (hs.Contains(j))
                    ++j;

                longest = Math.Max(longest, j - item);
            }

            return longest;
        }
    }
}
