using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_74
    {
        public Medium_74()
        {

        }
        public bool SearchMatrix(int[][] matrix, int target)
        {
            int m = matrix.Length;
            int n = matrix[0].Length;

            int start = 0;
            int end = m * n - 1;

            while (start < end)
            {
                int mid = (start + end) / 2;
                if (matrix[mid / n][mid % n] < target)
                    start = mid + 1;
                else
                    end = mid - 1;
            }

            return matrix[start / n][start % n] == target;
        }
    }
}
