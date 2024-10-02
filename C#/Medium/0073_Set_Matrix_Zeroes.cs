using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_73
    {
        public Medium_73()
        {
            //[[1,0,1],[0,0,0],[1,0,1]]
            int[][] matrix = new int[][]
            {
                new int[]{ 1, 1, 1 },
                new int[]{ 1, 0, 1 },
                new int[]{ 1, 1, 1 }
            };


            SetZeroes(matrix);
            Console.WriteLine("[" + string.Join(", ", matrix.Select(kk => "[" + string.Join(", ", kk) + "]")) + "]");
        }

        //O(n + m) space and O(n*m) time
        public void SetZeroes(int[][] matrix)
        {
            HashSet<int> rows = new HashSet<int>();
            HashSet<int> cols = new HashSet<int>();

            for (int i = 0; i < matrix.Length; i++)
                for (int j = 0; j < matrix[i].Length; j++)
                    if (matrix[i][j] == 0)
                    {
                        rows.Add(i);
                        cols.Add(j);
                    }

            for (int i = 0; i < matrix.Length; i++)
                for (int j = 0; j < matrix[i].Length; j++)
                    if (rows.Contains(i) || cols.Contains(j))
                        matrix[i][j] = 0;
        }
    }
}
