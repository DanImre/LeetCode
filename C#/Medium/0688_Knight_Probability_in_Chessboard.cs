using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_688
    {
        public Medium_688()
        {
            Console.WriteLine(KnightProbability(3,2,0,0)); //0,0625
        }
        public List<(int x, int y)> moves = new List<(int x, int y)>() { 
            (1, - 2), //UpRights
            (2, - 1),
            (1, 2), //DownRights
            (2, 1),
            (-1, - 2), //UpLefts
            (-2, - 1),
            (-1, 2), //DownLefts
            (-2, 1),
        };

        Dictionary<(int row, int column, int k), double> dp = new Dictionary<(int row, int column, int k), double>();
        public double KnightProbability(int n, int k, int row, int column)
        {
            if (row < 0 || column < 0 || row >= n || column >= n)
                return 0;

            if (k == 0)
                return 1;

            if (dp.ContainsKey((row, column, k)))
                return dp[(row, column, k)];

            double sum = 0;
            foreach (var item in moves)
                sum += KnightProbability(n, k - 1, row + item.x, column + item.y);

            dp.Add((row, column, k), sum / 8);

            return sum / 8;
        }
    }
}
