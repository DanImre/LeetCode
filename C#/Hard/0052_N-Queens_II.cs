using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hard
{
    public class Hard_52
    {
        public Hard_52()
        {
            TotalNQueens(4);
        }

        public List<(int x, int y)> placedQueenPositions = new List<(int x, int y)>();
        public int TotalNQueens(int n)
        {
            return backTrack(n, 0, 0);
        }
        /* pos example:
         * 0 1 2
         * 3 4 5
         * 6 7 8
         */

        public int backTrack(int n, int posX, int posY)
        {
            if (placedQueenPositions.Count == n)
                return 1;

            int sum = 0;

            while (posX < n)
            {
                if (!placedQueenPositions.Any(kk => kk.x == posX || kk.y == posY || Math.Abs(kk.x - posX) == Math.Abs(kk.y - posY)))
                {
                    placedQueenPositions.Add((posX, posY));
                    sum += backTrack(n, posX + 1, 0); //skipping the row
                    placedQueenPositions.RemoveAt(placedQueenPositions.Count - 1);
                }

                if (posY == n - 1)
                {
                    ++posX;
                    posY = 0;
                }
                else
                    ++posY;
            }

            return sum;
        }

    }
}
