using Algorithms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    

    class RedundantBracesandRainWaterTapping : IAlgorithm
    {
    public void Execute()
    {
            Console.WriteLine(RedundantBraces("(a+((b*c)+c))"));

            int[] arr1 = new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
            Rainwaterstorage(arr1);
     }

        public void Rainwaterstorage(int[] arr)
        {
            int n = arr.Length;
            int[] left = new int[n];

            // Right [i] contains height of tallest bar to 
            // the right of ith bar including itself 
            int[] right = new int[n];

            // Initialize result 
            int water = 0;

            // Fill left array 
            left[0] = arr[0];
            for (int i = 1; i < n; i++)
                left[i] = Math.Max(left[i - 1], arr[i]);

            // Fill right array 
            right[n - 1] = arr[n - 1];
            for (int i = n - 2; i >= 0; i--)
                right[i] = Math.Max(right[i + 1], arr[i]);

            // Calculate the accumulated water element by element 
            // consider the amount of water on i'th bar, the 
            // amount of water accumulated on this particular 
            // bar will be equal to min(left[i], right[i]) - arr[i] . 
            for (int i = 0; i < n; i++)
            {
                water += Math.Min(left[i], right[i]) - arr[i];
            }


            Console.WriteLine(water);
        }
        public bool RedundantBraces(String str)
        {
            Stack<char> stack = new Stack<char>();
            int index = 0;
            while (index < str.Length)
            {
                char c = str[index];
                if (c == '(' || c == '+' || c == '-' || c == '*' || c == '/')
                {
                    stack.Push(c);
                }
                else if (c == ')')
                {
                    if (stack.Peek() == '(')
                    {
                        return true;
                    }
                    else
                    {
                        while (stack.Count != 0 && stack.Peek() != '(')
                        {
                            stack.Pop();
                        }
                        stack.Pop();
                    }
                }
                index++;
            }
            return false;
        }

    }
}
