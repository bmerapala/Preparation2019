using Algorithms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class VPArrays : IAlgorithm
    {
        int[] arr = { 11, 15, 16, 18, 13, 12, 14 };
        int[] arr1 = { 16, 17, 4, 3, 5, 2 };
        int[] arr2 = { 2, 5, 2, 8, 5, 6, 8, 8 };

    public VPArrays(int[] input)
        {
        }
        public void Execute()
        {
            // missingrange(arr);
            // LeaderArray(arr1);
           sortbyfrequency(arr2);
        }
        public void sortbyfrequency(int[] arr)
        {
            Dictionary<int, int> D = new Dictionary<int, int>();

            for(int i = 0; i < arr.Length; i++)
            {
                if (D.ContainsKey(arr[i])) {
                    D[arr[i]] = D[arr[i]] + 1;
              }
                else
                {
                    D[arr[i]] = 1;
                }
            }
           //Dictionary<int, int> sortedDict = new Dictionary<int, int>();
           var sortedDict = from entry in D orderby entry.Value descending select entry;
            foreach (KeyValuePair<int,int> item in sortedDict )
            {
               for(int i = 0; i < item.Value; i++)
                {
                    Console.WriteLine(item.Key);
                }
            }
        }
        public void missingrange(int[] arr)
        {
            //naive
           
            int total = 0;
            int total1 = 0;
            Array.Sort(arr);
            int bu = arr[0];
            for (int i = 0; i < arr.Length + 1; i++)
            {
                total += bu++;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                total1 += arr[i];
            }

            int res = total - total1;


            Console.WriteLine(res);


            //hashing
            int n = arr.Length;
            Array.Sort(arr);
            HashSet<int> hs = new HashSet<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                hs.Add(arr[i]);
            }

                for (int i = arr[0]; i < arr[n-1]; i++)
                  {
                if (!hs.Contains(i))
                {
                    Console.WriteLine(i);
                }
              
            }
        }
        public void LeaderArray(int[] arr)
        {
            //method 1
            int max_from_right = arr[arr.Length - 1];

            // Rightmost element is always leader 
            Console.Write(max_from_right + " ");

            for (int i = arr.Length - 2; i >= 0; i--)
            {
                if (max_from_right < arr[i])
                {
                    max_from_right = arr[i];
                    Console.Write(max_from_right + " ");
                }
            }

            //method 2
           // int[] arr1 = { 16, 17, 4, 3, 5, 2 };

            for (int i = 0; i < arr.Length; i++)
            {
                int j;
                for (j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] <= arr[j])
                    {
                        break;
                    }

                }
                    if (j == arr.Length)
                    {
                        Console.WriteLine(arr[i]);
                    }
                
            }
           
        }
         }
}
