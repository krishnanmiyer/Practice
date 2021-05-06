using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class TileProblem
    {
        public static bool IsTileValid(string input, string[] tiles)
        {
            foreach(string w in tiles)
            {
                if (!IsMatchFound(w, input)) return false;
            }

            return true;
        }


        public static bool IsMatchFound(string tile, string input)
        {
            int tLen = tile.Length;
            int nLen = input.Length;

            int maxpatterns = nLen - tLen;

            /* A loop to slide pat[] one by one */
            for (int i = 0; i <= maxpatterns; i++)
            {
                int j;
                /* For current index i, check for pattern match */
                for (j = 0; j < tLen; j++)
                {
                    char s1 = input[i + j];
                    char s2 = tile[j];

                    if (s1 != s2)
                    {
                        break;
                    }
                        
                }



                if (j == tLen)  // if pat[0...tLen-1] = txt[i, i+1, ...i+tLen-1]
                    return true;
            }
            return false;
        }

    }
}
