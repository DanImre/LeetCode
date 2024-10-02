using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_1287
    {
        public Easy_1287()
        {

        }
        public int FindSpecialInteger(int[] arr)
        {
            int forth = arr.Length / 4;
            for (int i = 0; i < arr.Length - forth; i++)
                if (arr[i + forth] == arr[i])
                    return arr[i];

            return -1;
        }
    }
}
