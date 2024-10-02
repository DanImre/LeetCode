using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_2225
    {
        public Medium_2225()
        {

        }
        public IList<IList<int>> FindWinners(int[][] matches)
        {
            HashSet<int> distinctTeams = new HashSet<int>();

            Dictionary<int, int> loses = new Dictionary<int, int>();
            foreach (var match in matches)
            {
                if (!loses.ContainsKey(match[1]))
                    loses.Add(match[1], 1);
                else
                    loses[match[1]]++;

                distinctTeams.Add(match[0]);
                distinctTeams.Add(match[1]);
            }

            var first = new List<int>();
            var second = new List<int>();

            foreach (var item in distinctTeams)
                if (!loses.ContainsKey(item))
                    first.Add(item);
                else if (loses[item] == 1)
                    second.Add(item);

            first.Sort();
            second.Sort();

            return new List<IList<int>>() { first, second };
        }
    }
}
