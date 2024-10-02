using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Hard
{
    public class Hard_212
    {
        /*
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
        }*/
        public Hard_212()
        {
            char[][] board = "o,a,a,n],[e,t,a,e],[i,h,k,r],[i,f,l,v".Split("],[").Select(kk => kk.Split(",").Select(zz => zz.First()).ToArray()).ToArray();
            string[] words = new string[] { "oath", "pea", "eat", "rain" };

            Console.WriteLine(string.Join(", ", FindWords(board,words)));
        }
        //FOR sure with trie

        public class Node
        {
            public Node[] children;
            public string word;
            public Node()
            {
                children = new Node[26];
                word = null;
            }
        }

        List<string> solution = new List<string>();
        public IList<string> FindWords(char[][] board, string[] words)
        {
            Node root = new Node();
            foreach (var item in words)
            {
                Node temp = root;
                foreach (var i in item)
                {
                    if (temp.children[i - 'a'] == null)
                        temp.children[i - 'a'] = new Node();

                    temp = temp.children[i - 'a'];
                }
                temp.word = item;
            }

            for (int i = 0; i < board.Length; i++)
                for (int j = 0; j < board[i].Length; j++)
                    DFS(i, j, root, board);

            return solution;
        }
        public void DFS(int i, int j, Node node, char[][] board)
        {
            if(i < 0  || j < 0 || i == board.Length || j == board[i].Length) 
                return;

            char character = board[i][j];

            if (character == '#' || node.children[character - 'a'] == null)
                return;

            node = node.children[character - 'a'];
            if (node.word != null)
            {
                solution.Add(node.word);
                node.word = null;
            }

            board[i][j] = '#';
            DFS(i - 1, j, node, board);
            DFS(i + 1, j, node, board);
            DFS(i, j - 1, node, board);
            DFS(i, j + 1, node, board);

            board[i][j] = character;
        }
    }
}
