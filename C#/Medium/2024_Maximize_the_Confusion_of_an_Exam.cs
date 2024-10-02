using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_2024
    {
        public Medium_2024()
        {
            //8
            Console.WriteLine(MaxConsecutiveAnswers("FFFTTFTTFT",3));

            //42
            Console.WriteLine(MaxConsecutiveAnswers("FFTFFTFFTTFTFTTTTTTFFFTFTFFTTTFFFFTFFFFFTTFFTFFTFFFFFFTFFFTFTFTFFFFTTFFTTTTTTTTTFFFTTTTFFFTFFFTTTTTF", 12));
        }
        //Correct sliding window solution:
        public int MaxConsecutiveAnswers(string answerKey, int k)
        {
            int max = 1;

            int i = 0;
            int j = 0;

            int CountF = 0;
            int CountI = 0;

            while (j < answerKey.Length)
            {
                if (answerKey[j] == 'F')
                    ++CountF;
                else
                    ++CountI;

                while (Math.Min(CountI, CountF) > k)
                {
                    if (answerKey[i] == 'F')
                        --CountF;
                    else
                        --CountI;
                    ++i;
                }

                max = Math.Max(max, CountF + CountI);
                ++j;
            }

            return max;
        }
        //Bad solution
        public int MaxConsecutiveAnswers2(string answerKey, int k)
        {
            List<(int from, int to)> sections = new List<(int from, int to)>();
            char curr = answerKey[0];
            int startIndex = 0;
            for (int i = 0; i < answerKey.Length; i++)
            {
                if (answerKey[i] == curr)
                    continue;

                curr = answerKey[i];
                sections.Add((startIndex, i - 1));
                startIndex = i;
            }
            sections.Add((startIndex, answerKey.Length - 1));


            int max = 1;
            for (int i = 0; i < sections.Count; i++)
            {
                int tempSum = sections[i].to - sections[i].from + 1;
                int tempK = k;
                for (int j = i + 1; j < sections.Count; j += 2) //every seconds section is of the same type
                {
                    int lengthOfCurrSection = sections[j].to - sections[j].from + 1;

                    if (tempK - lengthOfCurrSection < 0)
                    {
                        tempSum += tempK;
                        tempK = 0;
                        break;
                    }

                    tempK -= lengthOfCurrSection;
                    tempSum += lengthOfCurrSection;

                    if (j + 1 < sections.Count)
                        tempSum += sections[j + 1].to - sections[j + 1].from + 1;
                }

                if (tempK > 0)
                    tempSum += Math.Min(sections[i].from, tempK);

                max = Math.Max(max, tempSum);
            }

            return max;
        }
    }
}
