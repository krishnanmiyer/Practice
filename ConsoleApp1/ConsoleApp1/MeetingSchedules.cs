using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class MeetingSchedules
    {
        public static int[][] FindFreeTime(int[][] input)
        {
            //1. Sort input by [0]
            Array.Sort(input, new Comparison<int[]>( 
                (x, y) => { 
                    return x[0]<y[0] ? -1 : (x[0] > y[0] ? 1 : 0);  
                } 
            ));


            //2. Loop through the time and find all time where  there is different end time of prev and start time of next
            List<int[]> result = new List<int[]>();

            for(int i = 1; i < input.Length; i++)
            {
                if (input[i - 1][1] < input[i][0])
                {
                    //3. Add resulting difference to a output array
                    result.Add(new int[] { input[i - 1][1], input[i][0] });
                }
            }

            return result.ToArray();
        }
    }
}
