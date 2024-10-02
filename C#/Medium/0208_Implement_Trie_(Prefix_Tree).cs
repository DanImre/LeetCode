using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_208
    {
        public Medium_208()
        {

        }

        public class Trie
        {
            private class Node
            {
                public Dictionary<char, Node> children;
                public bool isWord;
                public Node(bool isWord = false)
                {
                    children = new Dictionary<char, Node>();
                    this.isWord = isWord;
                }
            }

            private Node root;

            public Trie()
            {
                root = new Node();
            }

            public void Insert(string word)
            {
                Node curr = root;
                for (int i = 0; i < word.Length; i++)
                    if (curr.children.ContainsKey(word[i]))
                        curr = curr.children[word[i]];
                    else
                    {
                        Node temp = new Node();
                        curr.children.Add(word[i], temp);
                        curr = temp;
                    }

                curr.isWord = true;
            }

            public bool Search(string word)
            {
                Node curr = root;
                for (int i = 0; i < word.Length; i++)
                    if (curr.children.ContainsKey(word[i]))
                        curr = curr.children[word[i]];
                    else
                        return false;

                return curr.isWord;
            }

            public bool StartsWith(string prefix)
            {
                Node curr = root;
                for (int i = 0; i < prefix.Length; i++)
                    if (curr.children.ContainsKey(prefix[i]))
                        curr = curr.children[prefix[i]];
                    else
                        return false;

                return true;
            }
        }


    }
}
