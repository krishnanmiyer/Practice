//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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

        public int MaximalSquare(string[][] matrix)
        {
            int h = matrix.Length;
            int w = matrix[0].Length;
            int[][] aux = new int[h][];

            int result = 0;
            for (int r = 0; r < h; r++)
            {
                for (int c = 0; c < w; c++)
                {
                    if (matrix[r][c] == "1")
                    {
                        if (aux[r]==null)
                        {
                            aux[r] = new int[w];
                        }
                        aux[r][c] = 1;

                        if (r > 0 && c > 0)
                        {
                            aux[r][c] = 1 + Math.Min(aux[r - 1][c], Math.Min(aux[r][c - 1], aux[r - 1][c - 1]));
                        }
                        result = Math.Max(result, aux[r][c]);
                    }
                }
            }

            return result * result;
        }
    
        public int[][][] FindRectangles(int[][] input)
        {
            if (input.Length == 0) return new int[0][][];

            List<int[][]> result = new List<int[][]>();

            for(int i=0; i < input.Length; i++)
            {
                for(int j = 0; j < input[i].Length; j++)
                {
                    if (input[i][j] == 0)
                    {
                        result.Add(new int[2][] { new int[] { i, j }, new int[] { i, j } });
                        input[i][j] = 1;
                        GetPixes(input, i, j, result);
                    }
                }
            }

            return result.ToArray();
        }

        private void GetPixes(int[][] input, int row, int col, List<int[][]> result)
        {
            int maxi = row, maxj = col;

            for (int i = row; i < input.Length; i++)
            {
                for (int j = col; j < input[i].Length; j++)
                {
                    if (input[i][j] == 0)
                    {
                        maxi = i;
                        maxj = j;
                        input[i][j] = 1;
                    }
                    else
                    {
                        var items = result[result.Count - 1];
                        items[1][0] = maxi;
                        items[1][1] = maxj;
                        return;
                    }
                }
            }
        }
    }
}
