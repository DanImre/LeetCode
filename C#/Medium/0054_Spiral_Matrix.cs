using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_54
    {
        public Medium_54()
        {
            /*
            //[1,2,3,6,9,8,7,4,5]
            int[][] matrix = new int[][]{
                new int[]{ 1,2,3 },
                new int[]{ 4,5,6 },
                new int[]{ 7,8,9 }
            };
            /*
            //[1,2,3,4,8,12,11,10,9,5,6,7]
            int[][] matrix = new int[][]{
                new int[]{ 1,2,3,4 },
                new int[]{ 5,6,7,8 },
                new int[]{ 9,10,11,12 }
            };

            //[1,2,3,4]
            int[][] matrix = new int[][]{
                new int[]{ 1,2 },
                new int[]{ 4,3 }
            };

            //[1,2]
            int[][] matrix = new int[][]{
                new int[]{ 1,2 }
            };

            //[1,2]
            int[][] matrix = new int[][]{
                new int[]{ 1 },
                new int[]{ 2 }
            };

            //[2,5,8,-1,0,4]
            int[][] matrix = new int[][]{
                new int[]{ 2,5,8 },
                new int[]{ 4, 0, -1 }
            };

            //[1,2 .. 20]
            int[][] matrix = new int[][]{
                new int[]{ 1,2,3,4,5 },
                new int[]{ 14,15,16,17,6 },
                new int[]{ 13,20,19,18,7 },
                new int[]{ 12,11,10,9,8 }
            };
            */

            int[][] matrix = new int[][]{
                new int[]{ 1,2,3 },
                new int[]{ 16,17,4 },
                new int[]{ 15,18,5 },
                new int[]{ 14,19,6 },
                new int[]{ 13,20,7 },
                new int[]{ 12,21,8 },
                new int[]{ 11,10,9 },
            };

            Console.WriteLine("[" + string.Join(", ", SpiralOrder(matrix)) + "]");
        }

        public IList<int> SpiralOrder(int[][] matrix)
        {
            if (matrix.Length == 1)
                return matrix[0];

            if (matrix[0].Length == 1)
                return matrix.Select(kk => kk[0]).ToArray();

            List<int> solution = new List<int>();
            solution.Add(matrix[0][0]);
            int i = 0;
            int j = 0;
            int circlesDone = 0;

            while (true)
            {
                bool changed = false;
                while (j < matrix[i].Length - circlesDone - 1)
                {
                    ++j;
                    solution.Add(matrix[i][j]);

                    changed = true;
                }

                if (!changed)
                    break;

                changed = false;

                while (i < matrix.Length - circlesDone - 1)
                {
                    ++i;
                    solution.Add(matrix[i][j]);

                    changed = true;
                }

                if (!changed)
                    break;

                changed = false;

                while (j > circlesDone)
                {
                    --j;
                    solution.Add(matrix[i][j]);
                    
                    changed = true;
                }

                if (!changed)
                    break;

                changed = false;

                while (i > circlesDone + 1)
                {
                    --i;
                    solution.Add(matrix[i][j]);
                    
                    changed = true;
                }

                if (!changed)
                    break;

                ++circlesDone;
            }

            return solution;
        }
    }
}
