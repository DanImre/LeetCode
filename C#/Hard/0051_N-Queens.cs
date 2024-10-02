using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hard
{
    public class Hard_51
    {
        public Hard_51()
        {

        }

        public IList<IList<string>> Solutions = new List<IList<string>>();
        public int N;
        public IList<IList<string>> SolveNQueens(int n)
        {
            N = n;

            BackTrack(0, new List<string>());

            return Solutions;
        }

        public void BackTrack(int row, IList<string> buffer)
        {
            if (row == N)
                Solutions.Add(new List<string>(buffer));

            for (int i = 0; i < N; i++)
            {
                int j = row;
                while (--j >= 0)
                {
                    if (buffer[j][i] == 'Q')
                        break;

                    int diagonalAmount = row - j;
                    if (diagonalAmount <= i && buffer[j][i -diagonalAmount] == 'Q')
                        break;
                    if (diagonalAmount < N - i && buffer[j][i + diagonalAmount] == 'Q')
                        break;
                }

                if (j >= 0)
                    continue;

                StringBuilder temp = new StringBuilder();
                for (int z = 0; z < N; z++)
                    if (z == i)
                        temp.Append('Q');
                    else
                        temp.Append('.');

                buffer.Add(temp.ToString());
                BackTrack(row + 1, buffer);
                buffer.RemoveAt(row);
            }
        }
    }
}
