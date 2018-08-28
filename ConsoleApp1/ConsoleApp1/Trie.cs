using System;
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
}