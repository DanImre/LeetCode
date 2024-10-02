using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_1992
    {
        public Medium_1992()
        {

        }
        public int[][] FindFarmland(int[][] land)
        {
            List<int[]> solution = new List<int[]>();

            for (int i = 0; i < land.Length; i++)
                for (int j = 0; j < land[i].Length; j++)
                {
                    if (land[i][j] == 0)
                        continue;

                    int k;
                    int z = 0;
                    for (k = i; k < land.Length && land[k][j] == 1; k++)
                        for (z = j; z < land[k].Length && land[k][z] == 1; z++)
                            land[k][z] = 0;
                    k--;
                    z--;

                    solution.Add(new int[] { i, j, k, z });

                    j = z;
                }

            return solution.ToArray();
        }
    }
}
