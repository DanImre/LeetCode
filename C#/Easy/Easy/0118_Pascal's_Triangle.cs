using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_118
    {
        public Easy_118()
        {
            Generate(5);
        }
        public IList<IList<int>> Generate(int numRows)
        {
            int[][] solution = new int[numRows][];
            for (int i = 0; i < numRows; i++)
            {
                solution[i] = new int[i + 1];
                solution[i][0] = 1;
                for (int j = 1; j < i; j++)
                    solution[i][j] = solution[i - 1][j - 1] + solution[i - 1][j];
                solution[i][i] = 1;
                Console.WriteLine(string.Join(", ", solution[i]));
            }
            return solution;
        }
    }
}
