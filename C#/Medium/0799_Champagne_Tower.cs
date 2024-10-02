using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_799
    {
        public Medium_799()
        {
            Console.WriteLine(ChampagneTower(100000009,33,17));
        }
        public double ChampagneTower(int poured, int query_row, int query_glass)
        {
            double[][] glasses = new double[query_row + 1][];
            for (int i = 0; i <= query_row; i++)
                glasses[i] = new double[i + 1];

            glasses[0][0] = poured;
            for (int i = 0; i < query_row; i++)
                for (int j = 0; j <= i; j++)
                {
                    double pouredValuePerSide = (glasses[i][j] - 1) / 2;
                    if (pouredValuePerSide <= 0)
                        continue;

                    glasses[i + 1][j] += pouredValuePerSide;
                    glasses[i + 1][j + 1] += pouredValuePerSide;
                }

            return Math.Min(1, glasses[query_row][query_glass]);
        }
    }
}
