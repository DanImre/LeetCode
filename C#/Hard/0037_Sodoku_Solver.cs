using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hard
{
    public class Hard_37
    {
        public Hard_37()
        {

        }

        public void SolveSudoku(char[][] board)
        {
            SolveSudokuTemp(board);
        }

        public bool SolveSudokuTemp(char[][] board)
        {
            PrintBoard(board);
            if (board.All(x => x.All(y => y != '.')))
                return true;

            (int rowIndex, int colIndex, HashSet<char> values) = GetPossibleValues(board);
            foreach (var item in values)
            {
                board[rowIndex][colIndex] = item;
                if (SolveSudokuTemp(board))
                    return true;

                board[rowIndex][colIndex] = '.';
            }

            return false;
        }

        public (int rowIndex, int colIndex, HashSet<char> values) GetPossibleValues(char[][] board)
        {
            List<(int rowIndex, int colIndex, HashSet<char> values)> possibleValues = new();
            for (int i = 0; i < board.Length; i++)
                for (int j = 0; j < board[i].Length; j++)
                {
                    if (board[i][j] != '.')
                        continue;

                    HashSet<char> values = new(Enumerable.Range(1, 9).Select(x => (char)(x + '0')));
                    for (int k = 0; k < board.Length; k++)
                        values.Remove(board[k][j]);
                    for (int k = 0; k < board[i].Length; k++)
                        values.Remove(board[i][k]);
                    int boxRowStart = (i / 3) * 3;
                    int boxColStart = (j / 3) * 3;
                    for (int m = 0; m < 3; m++)
                        for (int n = 0; n < 3; n++)
                            values.Remove(board[boxRowStart + m][boxColStart + n]);

                    if (values.Count == 1)
                        return (i, j, values);

                    possibleValues.Add((i, j, values));
                }

            return possibleValues.MinBy(x => x.values.Count);
        }

        public void PrintBoard(char[][] board)
        {
            Thread.Sleep(5);
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("----------------------------------------");
            List<string> rows = board.Select(row => $"{string.Join(" ", row.Take(3))} | {string.Join(" ", row.Skip(3).Take(3))} | {string.Join(" ", row.Skip(6).Take(3))}").ToList();

            string boardView = $"{string.Join("\n\r", rows.Take(3))}\n\r{string.Join("", Enumerable.Repeat("-", 21))}\n\r{string.Join("\n\r", rows.Skip(3).Take(3))}\n\r{string.Join("", Enumerable.Repeat("-", 21))}\n\r{string.Join("\n\r", rows.Skip(6).Take(3))}";

            Console.WriteLine(boardView);
            Console.WriteLine("----------------------------------------");
            Console.WriteLine();
        }
    }
}
