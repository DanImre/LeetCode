using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_211
    {
        public Medium_211()
        {

        }

        public class WordDictionary
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

            public WordDictionary()
            {
                root = new Node();
            }

            public void AddWord(string word)
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
                Queue<(Node node, int index)> q = new Queue<(Node node, int index)>();
                q.Enqueue((root,0));

                while (q.Count != 0)
                {
                    var curr = q.Dequeue();

                    if(curr.index == word.Length)
                    {
                        if (curr.node.isWord)
                            return true;

                        continue;
                    }

                    if (word[curr.index] == '.')
                    {
                        foreach (var item in curr.node.children.Values)
                            q.Enqueue((item, curr.index + 1));
                    }
                    else if (curr.node.children.ContainsKey(word[curr.index]))
                        q.Enqueue((curr.node.children[word[curr.index]], curr.index + 1));
                }

                return false;
            }
        }


    }
}
