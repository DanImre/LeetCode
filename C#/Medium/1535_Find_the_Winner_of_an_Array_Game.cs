using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_1535
    {
        public Medium_1535()
        {

        }
        public int GetWinner(int[] arr, int k)
        {
            int winsInARow = 0;
            int max = arr[0];
            for (int i = 1; i < arr.Length && winsInARow != k; i++)
                if (arr[i] > max)
                {
                    max = arr[i];
                    winsInARow = 1;
                }
                else
                    ++winsInARow;

            return max;
        }
    }
}
