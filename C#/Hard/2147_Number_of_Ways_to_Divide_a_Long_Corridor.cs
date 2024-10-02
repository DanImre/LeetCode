using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hard
{
    public class Hard_2147
    {
        public Hard_2147()
        {

        }
        public int NumberOfWays(string corridor)
        {
            int seatCount = corridor.Count(kk => kk == 'S');
            if (seatCount == 0 || seatCount % 2 == 1) //Can't devide to exactly 2 seats per section
                return 0;

            int MOD = (int)1e9 + 7;

            long solution = 1;

            int count = 0;
            int currentSection = 0;
            for (int i = 0; i < corridor.Length; i++)
                if (count < 2)
                {
                    if (corridor[i] == 'S')
                        ++count;
                }
                else if (count == 2)
                {
                    if (corridor[i] == 'P')
                        ++currentSection;
                    else
                    {
                        solution = (solution * (currentSection + 1)) % MOD;
                        currentSection = 0;
                        count = 1;
                    }
                }

            return (int)solution;
        }
    }
}
