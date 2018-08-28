using System;
using System.Text;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class WordBreak {
        List<string> words = new List<string> {"mobile","samsung","sam","sung",
                            "man","mango","icecream","and",
                             "go","i","like","ice","cream"};

        public string BuildSentence(string sentence) {

            var temp = string.Empty;
            var sb = new StringBuilder();

            foreach(char c in sentence) {
                temp = temp + c;

                if (words.Contains(temp)) {
                    sb.AppendFormat("{0} ", temp);
                    temp = "";
                }
            }
            return sb.ToString();
        
        }

        public bool BuildSentence2(string sentence) {
            for(var i = 0; i < sentence.Length; i++) {
                if (words.Contains(sentence.Substring(0, i)) && BuildSentence2(sentence.Substring(i, sentence.Length - i))) {
                    return true;
                }
            }

            return false;
        }
    }
}