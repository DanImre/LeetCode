using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_36
    {
        public Medium_36()
        {
            //Cant really test here
            char[][] board = new char[][] {
            new char[] {'5','3','.','.','7','.','.','.','.' },
            new char[] {'6','.','.','1','9','5','.','.','.' },
            new char[] {'.','9','8','.','.','.','.','6','.' },
            new char[] {'8','.','.','.','6','.','.','.','3' },
            new char[] {'4','.','.','8','.','3','.','.','1' },
            new char[] {'7','.','.','.','2','.','.','.','6' },
            new char[] {'.','6','.','.','.','.','2','8','.' },
            new char[] {'.','.','.','4','1','9','.','.','5' },
            new char[] {'.','.','.','.','8','.','.','7','9' }
            };

            Console.WriteLine(IsValidSudoku(board));
        }
        public bool IsValidSudoku(char[][] board)
        {
            byte[][] countForRows = new byte[9][];
            byte[][] countForColumns = new byte[9][];
            byte[][] countForSquares = new byte[9][];
            for (int i = 0; i < 9; i++)
            {
                byte[] temp1 = new byte[9];
                byte[] temp2 = new byte[9];
                byte[] temp3 = new byte[9];

                Array.Fill(temp1, (byte)0);
                Array.Fill(temp2, (byte)0);
                Array.Fill(temp3, (byte)0);

                countForRows[i] = temp1;
                countForColumns[i] = temp2;
                countForSquares[i] = temp3;
            }

            for (int i = 0; i < board.Length; i++)
                for (int j = 0; j < board[i].Length; j++)
                {
                    if (board[i][j] == '.')
                        continue;

                    int value = board[i][j] - 49;

                    if (++countForRows[i][value] > 1
                        || ++countForColumns[j][value] > 1
                        || ++countForSquares[(i - (i % 3)) + (j / 3)][value] > 1)
                        return false;
                }

            return true;
        }
    }
}
