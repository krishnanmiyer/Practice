using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = new string[] { "acdb"};
            var board = new char[,]
   {
     { 'a', 'b'},
     { 'c', 'd'}
};

            var result = FindWords(board, words);
            Console.WriteLine(string.Join(",", result.ToArray()));
        }

        public static IList<string> FindWords(char[,] board, string[] words)
        {
            var answers = new List<string>();

            foreach (var word in words)
            {
                if (IsAdjacent(board, word))
                {
                    answers.Add(word);
                }
            }
            return answers;
        }

        public static bool IsAdjacent(char[,] board, string word)
        {
            for (var i = 0; i <= board.GetUpperBound(0); i++)
            {
                for (var j = 0; j <= board.GetUpperBound(1); j++)
                {
                    if (board[i, j] == word[0])
                    {
                        var result = IsAdjacent(board, word, 1, i, j);
                        if (result) return true;
                    }
                }
            }
            return false;
        }

        public static bool IsAdjacent(char[,] board, string word, int index, int row, int col)
        {
            if (index >= word.Length)
            {
                return true;
            }

            char c = word[index];
            if (board[row, col] == c)
            {
                return IsAdjacent(board, word, index + 1, row, col);
            }
            else if (col - 1 > 0 && board[row, col - 1] == c)
            {
                col--;
                return IsAdjacent(board, word, index + 1, row, col);
            }
            else if (col + 1 <= board.GetUpperBound(1) && board[row, col + 1] == c)
            {
                col++;
                return IsAdjacent(board, word, index + 1, row, col);
            }
            else if (row - 1 > 0 && board[row - 1, col] == c)
            {
                row--;
                return IsAdjacent(board, word, index + 1, row, col);
            }
            else if (row + 1 <= board.GetUpperBound(0) && board[row + 1, col] == c)
            {
                row++;
                return IsAdjacent(board, word, index + 1, row, col);
            }
            return false;
        }
    }
}
