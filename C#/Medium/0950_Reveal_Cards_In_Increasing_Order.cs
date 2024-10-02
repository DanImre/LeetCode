using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_950
    {
        public Medium_950()
        {

        }

        public int[] DeckRevealedIncreasing(int[] deck)
        {
            Array.Sort(deck);

            Queue<int> q = new Queue<int>();

            for (int i = 0; i < deck.Length; i++)
                q.Enqueue(i);

            int[] result = new int[deck.Length];
            for (int i = 0; i < deck.Length - 1; i++)
            {
                result[q.Dequeue()] = deck[i];
                q.Enqueue(q.Dequeue());
            }
            result[q.Dequeue()] = deck[deck.Length - 1];

            return result;
        }
    }
}
