using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_649
    {
        public Medium_649()
        {
            Console.WriteLine("RDRRRRRDDDDDRRDRDRDRDDDDRRRDDDRDRDRDRDRRRRDDDDRRRDDDDRRDDR".Count(KK => KK == 'D'));
            Console.WriteLine("RDRRRRRDDDDDRRDRDRDRDDDDRRRDDDRDRDRDRDRRRRDDDDRRRDDDDRRDDR".Count(KK => KK == 'R'));
        }
        public string PredictPartyVictory(string senate)
        {
            Queue<int> dQ = new Queue<int>();
            Queue<int> rQ = new Queue<int>();

            for (int i = 0; i < senate.Length; i++)
                if (senate[i] == 'R')
                    rQ.Enqueue(i);
                else
                    dQ.Enqueue(i);

            while (rQ.Count > 0 && dQ.Count > 0)
            {
                int currD = dQ.Dequeue();
                int currR = rQ.Dequeue();
                if(currD < currR)
                    dQ.Enqueue(currD + senate.Length);
                else
                    rQ.Enqueue(currR + senate.Length);
            }

            if (rQ.Count == 0)
                return "Dire";

            return "Radiant";
        }
    }
}
