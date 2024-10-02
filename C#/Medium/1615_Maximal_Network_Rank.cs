using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_1615
    {
        public Medium_1615()
        {

        }
        public int MaximalNetworkRank(int n, int[][] roads)
        {
            bool[][] cityIsConnected = new bool[n][];
            for (int i = 0; i < n; i++)
                cityIsConnected[i] = new bool[n];

            int[] roadsPerCity = new int[n];
            foreach (var item in roads)
            {
                ++roadsPerCity[item[0]];
                ++roadsPerCity[item[1]];
                cityIsConnected[item[0]][item[1]] = true;
                cityIsConnected[item[1]][item[0]] = true;
            }

            int max = -1;
            for (int i = 0; i < n; i++)
                for (int j = i + 1; j < n; j++)
                {
                    int tempSum = roadsPerCity[i] + roadsPerCity[j];
                    if (cityIsConnected[i][j])
                        --tempSum;

                    max = Math.Max(max, tempSum);
                }

            return max;
        }
    }
}
