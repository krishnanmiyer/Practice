//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp1
{

    //    //1. Find rectangles
    //    //2. Find all squares
    //    //3. Find largest rectangle
    //    //4. Find max sum rectangle

    //    public class TwoDArray
    //    {

    //        int[,] m = { 
    //                {1, 0, 1, 1, 1, 1, 1},
    //                {1, 1, 0, 1, 1, 1, 1},
    //                {1, 1, 1, 0, 0, 0, 1},
    //                {1, 0, 1, 0, 0, 0, 1},
    //                {1, 0, 1, 1, 1, 1, 1},
    //                {1, 1, 1, 0, 0, 0, 0},
    //                {1, 1, 1, 1, 1, 1, 1},
    //                {1, 1, 0, 1, 1, 1, 0} 
    //            };

    //        private int[,] PrintAllRectangles(int[,] m)
    //        {
    //            int rLen = m.GetLength(0);
    //            int cLen = m.GetLength(1);

    //            if (rLen < 1) return m;

    //            for(int r = 0; r < rLen; r++)
    //            {
    //                for(int c = 0; c < cLen; c++)
    //                {
    //                    if (m[r,c] == 1)
    //                    {
    //                        for(int k = r; k < m.Length; k++)
    //                        {
    //                            for (int m = )
    //                        }
    //                    }
    //                }

    //            }



    //            return null;
    //        }
    //    }


    public class Historgram
    {
        public int LargestRectangle(int[] heights)
        {
            Stack<int> stack = new Stack<int>();
            int max = 0;
            stack.Push(0);

            for (int i = 1; i < heights.Length; i++)
            {
                int cur = heights[i];

                if (cur > heights[stack.Peek()])
                {
                    stack.Push(i);
                }
                else
                {
                    while(stack.Count > 0 && cur < heights[stack.Peek()])
                    {
                        int temp = heights[stack.Pop()];

                        if (stack.Count == 0)
                        {
                            max = Math.Max(max, temp * i);
                        }
                        else
                        {
                            max = Math.Max(max, temp * (i - stack.Peek() - 1));
                        }
                    }
                    stack.Push(i);
                }
            }

            if (stack.Count > 0)
            {
                int i = heights.Length;
                while (stack.Count > 0)
                {
                    int temp = heights[stack.Pop()];

                    if (stack.Count == 0)
                    {
                        max = Math.Max(max, temp * i);
                    }
                    else
                    {
                        max = Math.Max(max, temp * (i - stack.Peek() - 1));
                    }
                }
            }

            return max;
        }
    }
}
