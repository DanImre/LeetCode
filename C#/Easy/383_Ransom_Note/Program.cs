namespace _383_Ransom_Note
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CanConstruct("a", "b"));
            Console.WriteLine(CanConstruct("aa", "ab"));
            Console.WriteLine(CanConstruct("aa", "aab"));
        }

        public static bool CanConstruct(string ransomNote, string magazine)
        {
            Dictionary<char, int> lettersInMagazine = new Dictionary<char, int>();
            for (int i = 'a'; i <= 'z'; i++)
                lettersInMagazine.Add((char)i, 0);
            
            foreach (var item in magazine)
                lettersInMagazine[item]++;

            foreach (var item in ransomNote)
            {
                if (lettersInMagazine[item] == 0)
                    return false;

                lettersInMagazine[item]--;
            }

            return true;
        }
    }
}