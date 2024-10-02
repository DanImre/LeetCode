using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_2610
    {
        public Medium_2610()
        {

        }

        public IList<IList<int>> FindMatrix(int[] nums)
        {
            IList<HashSet<int>> list = new List<HashSet<int>>();
            foreach (var item in nums)
            {
                bool CoudAdd = false;
                for (int i = 0; i < list.Count && !CoudAdd; i++)
                    CoudAdd = list[i].Add(item);

                if (!CoudAdd)
                    list.Add(new HashSet<int> { item });
            }

            return list.Select(kk => kk.ToArray()).ToArray();
        }
    }
}
