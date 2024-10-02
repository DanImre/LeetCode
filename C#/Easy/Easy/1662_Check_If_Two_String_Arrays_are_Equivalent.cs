using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_1662
    {
        public Easy_1662()
        {

        }
        public bool ArrayStringsAreEqual(string[] word1, string[] word2)
        {
            StringBuilder one = new StringBuilder();
            foreach (var item in word1)
                one.Append(item);

            string word = one.ToString();
            int index = 0;
            foreach (var item in word2)
                for (int j = 0; j < item.Length; j++)
                {
                    if (index == word.Length || word[index] != item[j])
                        return false;

                    ++index;
                }

            return index == word.Length;
        }
    }
}
