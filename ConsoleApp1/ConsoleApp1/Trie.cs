using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class TrieNode
    {
        public Dictionary<char, TrieNode> Children {get; set;}
        public bool IsComplete {get; set;}

        public TrieNode() {
            Children = new Dictionary<char, TrieNode>();
            IsComplete = false;
        }
    }

    public class Trie {
        private TrieNode _root;

        public Trie() {
            _root = new TrieNode();
        }


        public bool Search(string word) {
            TrieNode current = _root;
            for (var i = 0; i < word.Length; i++) {
                if (!current.Children.ContainsKey(word[i])) return false;
                current = current.Children[word[i]];
            }
            return current.IsComplete;
        }

        public bool SearchR(TrieNode current, string word, int index){
            if (index >= word.Length) return current.IsComplete;
            if(!current.Children.ContainsKey(word[index])) return false;
            return SearchR(current.Children[word[index]], word, index + 1);
        }

        public bool SearchR(string word){
            return SearchR(_root, word, 0);
        }        

        public void Insert(string word) {
            TrieNode current = _root;

            for (var i = 0; i < word.Length; i++) {
                if (!current.Children.ContainsKey(word[i])) {
                    var node = new TrieNode();
                    current.Children.Add(word[i], node);
                    current = node;
                }
            }
            current.IsComplete = true;
        }

        public void InsertR(string word) {
            InsertR(_root, word, 0);
        }
        public void InsertR(TrieNode current, string word, int index) {
            if (index >= word.Length) {
                current.IsComplete = true;
                return;
            }
            
            if (!current.Children.ContainsKey(word[index])) {
                var node = new TrieNode();
                current.Children.Add(word[index], node);
                current = node;
            }
            else {
                current = current.Children[word[index]];
            }
            InsertR(current, word, index + 1);
        }        
    }



    public class TrieNodeV2
    {
        public char Value { get; set; }

        public TrieNodeV2[] Children { get; set; }

        public bool IsComplete { get; set; }

        public TrieNodeV2(char c)
        {
            Value = c;
        }

        public TrieNodeV2() { }

    }

    public class TrieV2
    {
        private TrieNodeV2 _root;

        public TrieV2()
        {
            _root = new TrieNodeV2();
        }

        public bool Search(string word)
        {
            if (_root == null) return false;

            TrieNodeV2 current = _root;

            for(int i = 0; i < word.Length; i++)
            {
                for(int j = 0; j < current.Children.Length; j++)
                {
                    if (current.Children[j].Value == word[i])
                    {
                        current = current.Children[j];

                        if (i == word.Length - 1 && current.IsComplete) return true;

                        break;
                    }
                }
            }

            return false;
        }

        private bool SearchR(string word)
        {
            return SearchR(_root, word, 0);
        }

        private bool SearchR(TrieNodeV2 node, string word, int index)
        {
            if (index == word.Length - 1) return node.IsComplete;

            for (int j = 0; j < node.Children.Length; j++)
            {
                if (node.Children[j].Value == word[index])
                {
                    return SearchR(node.Children[j], word, index++);
                }
            }

            return false;
        }
    }
}