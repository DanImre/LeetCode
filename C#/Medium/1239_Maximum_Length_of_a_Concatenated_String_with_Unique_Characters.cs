using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_1239
    {
        public Medium_1239()
        {

        }
        public IList<string> Arr = null!;
        public int MaxLength(IList<string> arr)
        {
            Arr = arr.Where(kk => kk.Distinct().Count() == kk.Length).ToArray();

            return Backtack(0, 0, 0);
        }

        public int Backtack(int mask, int length, int index)
        {
            if (index == Arr.Count)
                return length;

            int tempMask = 0;
            foreach (var item in Arr[index])
                tempMask |= (1 << item - 'a');

            int solution = 0;
            if ((tempMask & mask) == 0)
                solution = Backtack((tempMask | mask), length + Arr[index].Length, index + 1);

            return Math.Max(solution, Backtack(mask, length, index + 1));
        }
    }
}
