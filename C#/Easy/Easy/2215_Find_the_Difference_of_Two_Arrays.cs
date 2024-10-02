using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_2215
    {
        public Easy_2215()
        {

        }
        public IList<IList<int>> FindDifference(int[] nums1, int[] nums2)
        {
            HashSet<int> one = new HashSet<int>(nums1);
            HashSet<int> two = new HashSet<int>(nums2);

            List<IList<int>> solution = new List<IList<int>>();
            solution.Add(new  List<int>());
            solution.Add(new  List<int>());

            foreach (var item in one)
                if(!two.Contains(item))
                    solution[0].Add(item);

            foreach (var item in two)
                if (!one.Contains(item))
                    solution[1].Add(item);

            return solution;
        }
    }
}
