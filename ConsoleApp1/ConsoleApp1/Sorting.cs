namespace ConsoleApp1
{
    public class Sorting
    {
        public void MergeSort(int[] input, int start, int end)
        {
            if (start >= end) return;
            
            int mid = (start+end) / 2;

            MergeSort(input, start, mid);
            MergeSort(input, mid+ 1, end);
            Merge(input, start, mid, end);
        }

        private void Merge(int[] input, int start, int mid, int end)
        {
            int[] temp = new int[end - start + 1];

            int i = start, j = mid + 1, k = 0;

            //merge both halves to temp
            while(i <= mid && j <=end)
            {
                if (input[i] <= input[j])
                {
                    temp[k] = input[i];
                    i++;
                }
                else
                {
                    temp[k] = input[j];
                    j++;
                }
                k++;
            }

            //merge left overs to temp
            while(i <= mid)
            {
                temp[k] = input[i];
                k++; i++;
            }

            while(j <= end)
            {
                temp[k] = input[j];
                k++; j++;
            }

            //merge temp to main array
            for(i = start; i <= end; i++)
            {
                input[i] = temp[i - start];
            }
        }
    }
}
