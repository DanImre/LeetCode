using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hard
{
    public class Hard_68
    {
        public Hard_68()
        {
            /*var list = FullJustify(new string[] { "This", "is", "an", "example", "of", "text", "justification." },
            16);*/
            
            var list = FullJustify(new string[] { "What", "must", "be", "acknowledgment", "shall", "be" },
            16);

            foreach (var item in list)
                Console.WriteLine("|" + item + "|");
            Console.WriteLine();
        }
        public IList<string> FullJustify(string[] words, int maxWidth)
        {
            List<string> solution = new List<string>();

            List<List<string>> wordsPerLayer = new List<List<string>>();
            List<int> sumPerLayer = new List<int>();

            int i = 0;
            while (i < words.Length)
            {
                List<string> activeLayer = new List<string>();

                int tempSum = 0;
                int temp = maxWidth;
                while (i < words.Length && words[i].Length <= temp)
                {
                    activeLayer.Add(words[i]);
                    temp -= words[i].Length + 1;

                    tempSum += words[i].Length;

                    ++i;
                }
                sumPerLayer.Add(tempSum);
                wordsPerLayer.Add(activeLayer);
            }

            for (int j = 0; j < wordsPerLayer.Count - 1; j++)
            {
                int toSubstitute = maxWidth - sumPerLayer[j];

                StringBuilder strBulder;

                if (wordsPerLayer[j].Count == 1)
                {
                    strBulder = new StringBuilder(wordsPerLayer[j][0]);
                    for (int ll = 0; ll < toSubstitute; ll++)
                        strBulder.Append(' ');

                    solution.Add(strBulder.ToString());
                    continue;
                }

                strBulder = new StringBuilder();

                int spaces = toSubstitute / (wordsPerLayer[j].Count - 1);
                int extraspaces = toSubstitute % (wordsPerLayer[j].Count - 1);
                Console.WriteLine(j + " -- " + toSubstitute + " | " + spaces);

                int k = 0;
                while (k < wordsPerLayer[j].Count - 1)
                {
                    strBulder.Append(wordsPerLayer[j][k]);

                    strBulder.Append(new string(' ', spaces));
                    if(extraspaces > 0)
                    {
                        --extraspaces;
                        strBulder.Append(' ');
                    }
                    ++k;
                }
                strBulder.Append(wordsPerLayer[j][k]);

                solution.Add(strBulder.ToString());
            }

            int spacesTillMax = maxWidth - sumPerLayer.Last();

            StringBuilder sb = new StringBuilder(string.Join(" ",wordsPerLayer.Last()));

            sb.Append(new string(' ', maxWidth - sb.Length));

            solution.Add(sb.ToString());

            return solution;
        }
    }
}
