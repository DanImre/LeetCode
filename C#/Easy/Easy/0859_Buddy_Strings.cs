using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Easy
{
    public class Easy_859
    {
        public Easy_859()
        {

        }
        public bool BuddyStrings(string s, string goal)
        {
            if (s.Length != goal.Length)
                return false;

            int[] charactersS = new int[26];
            int[] charactersGoal = new int[26];

            for (int i = 0; i < s.Length; i++)
            {
                ++charactersS[s[i] - 'a'];
                ++charactersGoal[goal[i] - 'a'];
            }

            bool hasSameCharacter = charactersS.Any(kk => kk > 1);

            //If not made with the same characters
            for (int i = 0; i < 26; i++)
                if (charactersS[i] != charactersGoal[i])
                    return false;

            //Every char is unique, if by swapping one we get the other, than its a win
            int[] swapIndexes = new int[2];
            int index = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != goal[i])
                {
                    //Would have to swap more then once
                    if (index == 2)
                        return false;

                    swapIndexes[index] = i;
                    ++index;
                }
            }
            
            if (index != 2)
                return hasSameCharacter; //Can swap the same characters

            return goal[swapIndexes[0]] == s[swapIndexes[1]]
                && goal[swapIndexes[1]] == s[swapIndexes[0]];
        }
    }
}
