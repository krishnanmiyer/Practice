using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //CakeType[] cakeTypes = new CakeType[] {
            //    new CakeType(7, 160),
            //    new CakeType(3, 90),
            //    new CakeType(2, 15),
            //};

            //int capacity = 20;

            //Console.WriteLine(maxDuffelBagValue(cakeTypes, capacity));

            //int[] ids = new int[5] { 1, 2, 1, 2, 4};
            //Console.WriteLine(uniqueId(ids));

            //int[] denominations = new int[] { 1, 5, 10, 25 };
            //Console.WriteLine(changePossibilitiesBottomUp(10, denominations));
            //prExclass PC = new prExclass();
            //ThreadStart TS = new ThreadStart(PC.ShowTime);
            //Thread t = new Thread(TS);
            //t.Start();
            //Console.ReadLine();

            //var t1 = new Thread(ShowTime);
            //t1.Start();
            //Console.ReadLine();

            //var locations = new int[,] { { 1, -3 }, { 1, 2}, {3, 4 } };

            //var test = closestLocations(3, locations, 1);

            //Console.WriteLine(IsPalindrome("aba"));

            //Console.WriteLine(ReverseWords("I love this world"));

            //Console.WriteLine(ReverseWords2("I love this world"));


            //var m = new int[,]
            //          { { 10, 20, 30, 40},
            //          { 15, 25, 35, 45},
            //          { 27, 29, 37, 48},
            //          { 32, 33, 39, 50}};

            //var a = findNumber(m, 4, 32);


            //var h = BuildHeap(new int[] { 4, 1, 3, 2, 16, 9, 10, 14, 8, 7 }, 0);

            //var m = new int[,]
            //          { { 1, 0, 0, 0},
            //          { 0, 1, 0, 0},
            //          { 0, 0, 1, 1},
            //          { 0, 0, 1, 0}};


            //var n = getNoOfIslands(m);

            //var result = IsAnagram("isanagram", "marganasi");

            //var result = lcs("abcdef", "acbcf");

            //Permute("abc", 0, 2);


            MaxSubArraySum(new int[] { 2, 4, 5, -8, 10 });

            //MaxContiguousSubArraySum(new int[] { 2, 4, 5, -8, 10 });

            //FibonacciIterative(10);
            //FibonacciRecursive();
            //FibonacciMemoization(10);

            Console.ReadLine();  
        }

        public static void FibonacciIterative(int n)
        {
            int f1 = 0;
            int f2 = 0;

            for (var i = 0; i <= n; i++)
            {
                if (i < 2)
                {
                    Console.Write(i);
                    f1 = 0;
                    f2 = i;
                }
                else
                {
                    var f3 = f1 + f2;
                    f1 = f2;
                    f2 = f3;
                    Console.Write(f3);
                }
            }
        }

        public static void FibonacciRecursive()
        {
            for (var i = 0; i <=10; i++)
            {
                Console.Write(FibonacciRecursive(i));
            }
        }

        public static int FibonacciRecursive(int n)
        {
            if (n < 2)
            {
                return n;
            }
            return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);         
        }

        public static int FibonacciMemoization(int n)
        {
            var fibo = new int[n + 1];
            fibo[0] = 0;
            fibo[1] = 1;

            for (var i = 2; i <= n; i++)
            {
                fibo[i] = fibo[i - 1] + fibo [i - 2];
            }
            return fibo[n];
        }

        public static int SubArraySum(int[] a, int k)
        {
            int current = 0;
            int start = 0;

            for (var i = 0; i <= a.Length; i++)
            {
                while (current > k && start < i - 1)
                {
                    current = current - a[start];
                    start++;
                }

                if (current == k)
                {
                    Console.WriteLine("Sum found between {0} and {1}", start, i - 1);
                    return 1;
                }
                current = current + a[i];
            }
            Console.WriteLine("No Subarray found");
            return 0;
        }

        public static int SubArrayWithNegative(int[] a, int k)
        {
            int current = 0;
            var dict = new Dictionary<int, int>();

            for (var i = 0; i <= a.Length; i++)
            {
                current = current + a[i];

                if (current == k)
                {
                    Console.WriteLine("Found subarray");
                    return 1;
                }

                if (dict.Any(x => x.Value == current - k))
                {
                    Console.WriteLine("Found subarray");
                    return 1;
                }

                dict.Add(current, i);
            }
            Console.WriteLine("Not Found subarray");
            return 0;
        }

        public static int MaxSubArraySum(int[] a)
        {
            int currentMax = a[0];
            int globalMax = a[0];

            for (int i = 1; i < a.Length; i++)
            {
                currentMax = Math.Max(a[i], currentMax + a[i]);
                if (currentMax > globalMax)
                {
                    globalMax = currentMax;
                }
            }
            return globalMax;
        }

        public static int MaxContiguousSubArraySum(int[] a)
        {
            int currentMax = a[0];
            int globalMax = 0;

            for (int i = 1; i < a.Length; i++)
            {
                if (currentMax + a[i] < currentMax)
                {
                    currentMax = 0;
                }
                else
                {
                    currentMax = currentMax + a[i];
                }
                
                globalMax = Math.Max(globalMax, currentMax);
            }
            return globalMax;
        }

        public static void Permute(string s, int start, int end)
        {
            if (start == end)
            {
                Console.WriteLine(s);
            }
            for (int j = start; j <= end; j++)
            {
                s = Swap(s, j, start);
                Permute(s, start + 1, end);
                s = Swap(s, j, start);
            }
        }

        public static string Swap(string s, int i, int j)
        {
            var tempStr = s.ToCharArray();
            var temp = tempStr[i];
            tempStr[i] = tempStr[j];
            tempStr[j] = temp;
            return string.Join("", tempStr);
        }


        public static bool IsPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s)) return false;

            var size = s.Length;

            for(var i = 0; i < size/2; i++)
            {
                if (s[i] != s[(size - 1) - i]) return false;
            }
            return true;
        }

        public static bool IsAnagram(string first, string second)
        {
            if (first.Length == 0 || second.Length==0 || first.Length != second.Length)
            {
                return false;
            }

            var numbers = new int[26];

            var offset = (int)'a';
            for(var i = 0; i < first.Length; i++)
            {
                var code = Math.Abs((int)first[i] - offset);
                numbers[code]++;

                code = Math.Abs((int)second[i] - offset);
                numbers[code]--;
            }

            for (int j = 0; j < numbers.Length; j++)
            {
                if (numbers[j] > 0) return false;
            }

            return true;
        }


        public static string ReverseWords(string s)
        {
            if (string.IsNullOrEmpty(s)) return "";

            var words = s.Split(' ');

            string temp = string.Empty;

            for (var i = 0; i < words.Length; i++)
            {
                for( var j = words[i].Length - 1; j >= 0; j--)
                {
                    temp = temp + words[i][j];
                }
                words[i] = temp;
                temp = "";
            }

            return string.Join(" ", words);
        }

        public static string ReverseWords2(string s)
        {
            if (string.IsNullOrEmpty(s)) return "";

            string temp = string.Empty;
            string newString = string.Empty;

            for (var i = 0; i < s.Length; i++)
            {
                if (s[i] == ' ')
                {
                    newString = newString + ' ' + temp;
                    temp = "";
                }
                else
                {
                    temp = s[i] + temp;
                }
            }
            return newString;
        }

        public static List<List<int>> closestLocations(int totalCrates, int[,] allLocations, int truckCapacity)
        {
            var distances = new Dictionary<int, double>();
            for (var i = 0; i < allLocations.Length; i++)
            {
                var distance = Math.Sqrt((allLocations[i, 0] * allLocations[i, 0]) + (allLocations[i, 1] * allLocations[i, 1]));
                distances.Add(i, distance);
            }

            var indexes = distances.OrderBy(pair => pair.Value).Select(x => x.Key).ToList();

            var closest = new List<List<int>>();

            int capacity = totalCrates < truckCapacity ? totalCrates : truckCapacity;

            for (int j = 0; j < capacity; j++)
            {
                closest.Add(new List<int> { allLocations[indexes[j], 0], allLocations[indexes[j], 1] });
            }

            return closest;
        }

        public static int findNumber(int[,] m, int n,  int x)
        {
            /*
                    m = new int[,]
                      { { 10, 20, 30, 40},
                      { 15, 25, 35, 45},
                      { 27, 29, 37, 48},
                      { 32, 33, 39, 50}};                        
             */
            if (m.Length < 1) return 0;

            int i = 0;
            int j = n - 1;

            while(i < n && j >= 0)
            {
                if (m[i,j] == x)
                {
                    Console.WriteLine("{0},{1}", i, j);
                    return 1;
                }
                else
                {
                    if (m[i,j] > x)
                    {
                        j--;
                    }
                    else
                    {
                        i++;
                    }
                }
            }

            Console.WriteLine("Not Found");
            return 0;
        }

        public static int findLargestElement(int[,] m, int n, int x)
        {


            return 0;
        }


        public class Node
        {
            public int Value;
            public Node Left;
            public Node Right;
        }

        public static bool DFS(Node root, int value)
        {
            var stack = new Stack<Node>();

            if (root == null) return false;

            stack.Push(root);

            while(stack.Count > 0)
            {
                var node = stack.Pop();

                if (node.Value == value)
                {
                    return true;
                }
                else if (node.Value < value)
                {
                    stack.Push(node.Left);
                }
                else
                {
                    stack.Push(node.Right);
                }
            }
            return false;
        }

        public static bool BinarySearch(int[] values, int value, int l, int r)
        {
            if (values.Length < 1 ) return false;

            if (r < l) return false;

            var mid = 1 + (r - l)/2;

            if (value == values[mid])
            {
                return true;
            }
            else if (value > values[mid])
            {
                return BinarySearch(values, value, mid + 1, r);
            }
            return BinarySearch(values, value, l, mid - 1);
        }

        private static bool BinarySearchTreeV2(int[] a, int l, int r, int x)
        {
            if (a == null || a.Length < 1) return false;

            if (l > r) return false;

            var m = (l + r) / 2;

            if (a[m] == x)
            {
                return true;
            }
            else if (a[m] < x)
            {
                return BinarySearchTreeV2(a, 0, m - 1, x);
            }
            else if (a[m] > x)
            {
                return BinarySearchTreeV2(a, m + 1, r, x);
            }
            return false;
        }

        public class LinkedListNode
        {
            public int Value;
            public LinkedListNode Next;
        }

        public static bool IsLinkedListCircular(LinkedListNode node)
        {
            if (node == null)
            {
                return false;
            }

            LinkedListNode hare = node;
            LinkedListNode tortoise = node;

            while (hare != null)
            {
                tortoise = tortoise.Next;
                hare = hare.Next.Next;

                if (hare == tortoise)
                {
                    return true;
                }
            }
            return false;
        }

        public static LinkedListNode FindFromEnd(LinkedListNode node, int k)
        {
            if (node == null)
            {
                return null;
            }

            LinkedListNode lead = node;
            LinkedListNode current = node;

            int count = 0;

            while (lead != null)
            {
                lead = lead.Next;
                count++;

                if (count > 5)
                {
                    current = current.Next;
                }
            }
            return current;
        }


        static Heap heap = new Heap();
        public static Heap BuildHeap(int[] a, int i)
        {
            if (i > a.Length - 1) return heap;

            heap.Value = a[i];
            heap.Left = BuildHeap(a, (2 * i) + 1);
            heap.Right = BuildHeap(a, (2 * i) + 2);

            return heap;
        }

        public class Heap
        {
            public int Value { get; set; }
            public Heap Left { get; set; }
            public Heap Right { get; set; }
        }

        public static int getBiggestSize(int[][] matrix)
        {
            int size = 0;
            int maxSize = 0;
            for(int row = 0; row < matrix.Length; row++)
            {
                for(int col = 0; col< matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 1)
                    {
                        size += getRegionSize(matrix, row, col);
                        maxSize = Math.Max(size, maxSize);
                    }
                }
            }

            return maxSize;
        }

        public static int getNoOfIslands(int[,] matrix)
        {
            int size = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 1)
                    {
                        size++;
                        setNeighbors(matrix, row, col);
                    }
                }
            }

            return size;
        }

        public static void setNeighbors(int[,] matrix, int row, int col)
        {
            if (row < 0 || col < 0 || row >= matrix.GetLength(0) || col >= matrix.GetLength(1))
            {
                return;
            }

            if (matrix[row, col] == 0)
            {
                return;
            }

            matrix[row, col] = 0;

            for (int r = row - 1; r <= row + 1; r++)
            {
                for (int c = col - 1; c <= col + 1; c++)
                {
                    setNeighbors(matrix, r, c);
                }
            }
        }

        
        public static int getRegionSize(int[][] matrix, int row, int col)
        {
            if (row < 0 || col < 0 || row >= matrix.GetLength(0) || col >= matrix.GetLength(1))
            {
                return 0;
            }

            if (matrix[row][col] == 0)
            {
                return 0;
            }

            int size = 1;

            matrix[row][col] = 0;

            for (int r = row - 1; r <= row + 1; r++)
            {
                for (int c = col - 1; c <= col + 1; c++)
                {
                    size += getRegionSize(matrix, r, c);
                }
            }

            return size;
        }

        //public class Movie
        //{
        //    public int getRating();
        //    public List<Movie> getSimilarMovies();
        //}

        //public static List<int> getMovieRecommendations(Movie m, int N)
        //{
        //    var movies = new HashSet<Movie>();
        //    movies.OrderByDescending(m => m.Rating).Take(N)


        //    // WRITE YOUR CODE HERE
        //}

        public static void ShowTime()
        {
            for (;;)
            {

                Console.WriteLine(DateTime.Now.ToString("hh:mm:ss tt"));
                Console.WriteLine("\a");
                Thread.Sleep(1000);
                Console.Clear();
            }
        }
        class prExclass
        {

        }

            public static int uniqueId(int[] ids)
        {
            int uniqueId = 0;

            foreach(int i in ids) {
                uniqueId ^= i;
            }

            return uniqueId;
        }


        public static long maxDuffelBagValue(CakeType[] cakeTypes, int weightCapacity)
        {

            // we make an array to hold the maximum possible value at every
            // duffel bag weight capacity from 0 to weightCapacity
            // starting each index with value 0
            long[] maxValuesAtCapacities = new long[weightCapacity + 1];

            for (int currentCapacity = 0; currentCapacity <= weightCapacity; currentCapacity++)
            {

                // set a variable to hold the max monetary value so far for currentCapacity
                long currentMaxValue = 0;

                foreach (CakeType cakeType in cakeTypes)
                {

                    // if a cake weighs 0 and has a positive value the value of our duffel bag is infinite!
                    if (cakeType.weight == 0 && cakeType.value != 0)
                    {
                        throw new Exception();
                    }

                    // if the current cake weighs as much or less than the current weight capacity
                    // it's possible taking the cake would give get a better value
                    if (cakeType.weight <= currentCapacity)
                    {

                        // so we check: should we use the cake or not?
                        // if we use the cake, the most kilograms we can include in addition to the cake
                        // we're adding is the current capacity minus the cake's weight. we find the max
                        // value at that integer capacity in our array maxValuesAtCapacities
                        long maxValueUsingCake = cakeType.value + maxValuesAtCapacities[currentCapacity - cakeType.weight];

                        // now we see if it's worth taking the cake. how does the
                        // value with the cake compare to the currentMaxValue?
                        currentMaxValue = Math.Max(maxValueUsingCake, currentMaxValue);
                    }
                }

                // add each capacity's max value to our array so we can use them
                // when calculating all the remaining capacities
                maxValuesAtCapacities[currentCapacity] = currentMaxValue;
            }
            return maxValuesAtCapacities[weightCapacity];
        }

        public static int changePossibilitiesBottomUp(int amount, int[] denominations)
        {
            int[] waysOfDoingNCents = new int[amount + 1]; // array of zeros from 0..amount
            waysOfDoingNCents[0] = 1;

            foreach (int coin in denominations)
            {
                for (int higherAmount = coin; higherAmount <= amount; higherAmount++)
                {
                    int higherAmountRemainder = higherAmount - coin;
                    waysOfDoingNCents[higherAmount] += waysOfDoingNCents[higherAmountRemainder];
                }
            }

            return waysOfDoingNCents[amount];
        }

        public static int lcs(string s1, string s2)
        {
            var auxillary = new int[s1.Length + 1, s2.Length + 1];

            for (int row = 1; row <= s1.Length; row++)
            {
                for (int col = 1; col <= s2.Length; col++)
                {
                    if (s1[row - 1] == s2[col - 1])
                    {
                        auxillary[row, col] = auxillary[row - 1, col - 1] + 1;
                    }
                    else
                    {
                        auxillary[row, col] = Math.Max(auxillary[row - 1, col], auxillary[row, col - 1]);
                    }
                }
            }

            return auxillary[s1.Length, s2.Length];
        }

        public class BSTNode
        {
            public BSTNode(int v)
            {
                Value = v;
            }

            int Value;
            public BSTNode Left;
            public BSTNode Right;
        }

        private static BSTNode BuildBSTFromSortedArray(int[] a, BSTNode root, int i)
        {
            if (i >= a.Length) return root;

            root = new BSTNode(a[i]);

            root.Left = BuildBSTFromSortedArray(a, root.Left, 2 * (i + 1));
            root.Right = BuildBSTFromSortedArray(a, root.Right, 2 * (i + 2));

            return root;
        }

    }


    class CakeType
    {
        public int weight;
        public int value;

        public CakeType(int weight, int value)
        {
            this.weight = weight;
            this.value = value;
        }

    }


}
