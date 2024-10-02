using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_2352
    {
        public Medium_2352()
        {

        }
        public int EqualPairs(int[][] grid)
        {
            int solution = 0;

            Dictionary<string, int> dicRow = new Dictionary<string, int>();
            Dictionary<string, int> dicCol = new Dictionary<string, int>();

            for (int i = 0; i < grid.Length; i++)
            {
                string currRow = string.Join(',', grid[i]);
                if (dicRow.ContainsKey(currRow))
                    ++dicRow[currRow];
                else
                    dicRow.Add(currRow, 1);

                if (dicCol.ContainsKey(currRow))
                    solution += dicCol[currRow];

                StringBuilder currColSB = new StringBuilder();
                for (int j = 0; j < grid.Length - 1; j++)
                {
                    currColSB.Append(grid[j][i]);
                    currColSB.Append(',');
                }
                currColSB.Append(grid[grid.Length - 1][i]);

                string currCol = currColSB.ToString();
                if (dicCol.ContainsKey(currCol))
                    ++dicCol[currCol];
                else
                    dicCol.Add(currCol, 1);

                if (dicRow.ContainsKey(currCol))
                    solution += dicRow[currCol];
            }
            return solution;
        }
    }
}
