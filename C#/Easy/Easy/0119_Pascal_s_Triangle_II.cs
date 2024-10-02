using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_119
    {
        public Easy_119()
        {

        }

        public IList<int> GetRow(int rowIndex)
        {
            int[] solution = new int[rowIndex + 1];
            solution[0] = 1;

            int prevNum = 1;
            int actrow = 1;
            while (actrow <= rowIndex)
            {
                for (int i = 0; i < actrow - 1; i++)
                {
                    int temp = solution[i];
                    solution[i] = prevNum;
                    prevNum = temp + solution[i + 1];
                }
                solution[actrow - 1] = prevNum;
                solution[actrow] = 1;

                prevNum = 1;
                ++actrow;
            }

            return solution;
        }

    }
}
