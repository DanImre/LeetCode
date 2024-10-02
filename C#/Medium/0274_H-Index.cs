using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_274
    {
        public Medium_274()
        {
            Console.WriteLine(HIndex(new int[] { 3, 0, 6, 1, 5 })); //3
            Console.WriteLine(HIndex(new int[] { 1, 3, 1 })); //1
            Console.WriteLine(HIndex(new int[] { 100 })); //1
            Console.WriteLine(HIndex(new int[] { 1, 2 })); //1
            Console.WriteLine(HIndex(new int[] { 0, 1 })); //1
            Console.WriteLine(HIndex(new int[] { 0 })); //0
            Console.WriteLine(HIndex(new int[] { 0, 1, 0 })); //1
            Console.WriteLine(HIndex(new int[] { 2, 4, 8, 9, 9, 3 })); //4


            Console.WriteLine(HIndex(new int[] { 1, 1, 3, 6, 7, 10, 7, 1, 8, 5, 9, 1, 4, 4, 3 })); //6
            Console.WriteLine(HIndex(new int[] { 0, 0 })); //0
        }
        public int HIndex(int[] citations)
        {
            List<int> aslist = citations.ToList();
            aslist.Sort();

            while (aslist.Count > 1 && aslist[aslist.Count / 2] == 0)
                aslist.RemoveAt(aslist.Count / 2);

            if (aslist.Count == 1)
                return citations[0] == 0 ? 0 : 1;

            int i = aslist.Count / 2;

            if (aslist.Count - i < aslist[i])
            {
                while (i >= 0 && aslist.Count - i <= aslist[i])
                    --i;
                if (i != aslist.Count / 2)
                    ++i;
            }
            else
                while (i < aslist.Count && aslist.Count - i > aslist[i])
                    ++i;

            return Math.Min(aslist.Count - i, aslist[i]);
        }
    }
}
