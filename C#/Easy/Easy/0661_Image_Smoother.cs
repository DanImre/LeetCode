using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_661
    {
        public Easy_661()
        {

        }
        public int[][] ImageSmoother(int[][] img)
        {
            int[][] solution = new int[img.Length][];
            for (int i = 0; i < img.Length; i++)
            {
                solution[i] = new int[img[i].Length];
                for (int j = 0; j < img[i].Length; j++)
                {
                    int sum = 0;
                    int count = 0;
                    for (int li = Math.Max(0, i - 1); li <= Math.Min(i + 1, img.Length - 1); li++)
                        for (int lj = Math.Max(0, j - 1); lj <= Math.Min(j + 1, img[i].Length - 1); lj++)
                        {
                            sum += img[li][lj];
                            count++;
                        }

                    solution[i][j] = sum / count;
                }
            }

            return solution;
        }
    }
}
