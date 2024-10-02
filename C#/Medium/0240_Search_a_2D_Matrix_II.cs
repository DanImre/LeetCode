using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_240
    {
        public Medium_240()
        {

        }
        public bool SearchMatrix(int[][] matrix, int target)
        {
            int row = 0;
            int col = matrix[0].Length - 1;

            while (col >= 0 && row < matrix.Length)
            {
                if (target == matrix[row][col])
                    return true;

                if (matrix[row][col] > target)
                    col--;
                else
                    row++;
            }

            return false;
        }
    }
}
