using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_79
    {
        public Medium_79()
        {

        }
        public bool Exist(char[][] board, string word)
        {
            for (int i = 0; i < board.Length; i++)
                for (int j = 0; j < board[i].Length; j++)
                    if (backTracking(board, word, 0, (i, j)))
                        return true;

            return false;
        }

        public bool backTracking(char[][] board, string word, int index, (int x, int y) pos)
        {
            if (pos.x < 0 || pos.y < 0 || pos.x >= board.Length || pos.y >= board[pos.x].Length)
                return false;

            char character = board[pos.x][pos.y];

            if (character != word[index])
                return false;

            if (index == word.Length - 1)
                return true;

            board[pos.x][pos.y] = '#';
            bool solution = backTracking(board, word, index + 1, (pos.x + 1, pos.y))
                || backTracking(board, word, index + 1, (pos.x - 1, pos.y))
                || backTracking(board, word, index + 1, (pos.x, pos.y + 1))
                || backTracking(board, word, index + 1, (pos.x, pos.y - 1));
            board[pos.x][pos.y] = character;

            return solution;
        }
    }
}
