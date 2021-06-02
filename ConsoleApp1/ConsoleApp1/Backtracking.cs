using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Backtracking
    {
        public static int[] SumOfSubsets(int[] input, int k)
        {
            List<int> res = new List<int>();
            SosBt(0, res, input, k);
            return res.ToArray();
        }

        private static void SosBt(int start, List<int> res, int[] input, int k)
        {
            int cur = res.Sum(x => x);
            if (cur == k ) return;

            if (cur > k) return;
            
            for (int i = start; i < input.Length; i++)
            {
                res.Add(input[i]);
                SosBt(start + 1, res, input, k);
                res.Remove(input[i]);
            }
        }
    }
}
