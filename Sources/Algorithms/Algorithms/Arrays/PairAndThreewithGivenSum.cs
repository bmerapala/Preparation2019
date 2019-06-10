using Algorithms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Arrays
{
    public class PairAndThreewithGivenSum : IAlgorithm
    {
        int[] _arrayInput;
        int _sum;
        int l;
        int r;
        int[] arr = {3,6,7,-3,-4,-6,-2,-7};
        int[] arr1 = { 5, 32, 1, 7, 10, 50,19, 21, 2 };
        int givenSum = 0;

        //string result;
        public PairAndThreewithGivenSum(int[] input, int sum)
        {
            _arrayInput = input;
            _sum = sum;
             l = 0;
             r = _arrayInput.Length - 1;
           
            //result = "";
        }

        public void Execute()
        {

            subarrayofgivensum(arr, givenSum);
           //findSubarrays(arr, givenSum);
           // twosummethods(_arrayInput);
           // threesummethods(_arrayInput);
           //thirdnumsumtriplet(arr1)
}
        public void thirdnumsumtriplet(int[] arr)
        {
            Array.Sort(arr);

            // for every element in arr 
            // check if a pair exist(in  
            // array) whose sum is equal 
            // to arr element 
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                int j = 0;
                int k = i - 1;
                while (j < k)
                {
                    if (arr[i] == arr[j] + arr[k])
                    {

                        // pair found 
                        Console.WriteLine("numbers are "
                                  + arr[i] + " " + arr[j]
                                        + " " + arr[k]);

                        return;
                    }
                    else if (arr[i] > arr[j] + arr[k])
                        j += 1;
                    else
                        k -= 1;
                }
            }

            // no such triplet is found in array 
            Console.WriteLine("No such triplet exists");
        }
        //Naive approach
        public void findSubarrays(int[] arr, int sum)
        {
            int n = arr.Length;
            for (int i = 0; i < n; i++)
            {
                int sum_so_far = 0;

                // consider all sub-arrays starting from i and ending at j
                for (int j = i; j < n; j++)
                {
                   //Console.WriteLine(i + "," +j);
                    // sum of elements so far
                    sum_so_far += arr[j];

                    // if sum so far is equal to the given sum
                    if (sum_so_far == sum)
                    {
                        Console.WriteLine( "subarray is found at " +i + " " + j);
                        //for (int k = i; k <= j; k++)
                        //{
                        //    Console.WriteLine(arr[k]);
                        //}
                    }
                }
            }
        }

      
        //hashing
        public void subarrayofgivensum(int[] arr, int sum)
        {
            int length = arr.Length;
            if (length == 0)
            {
                Console.WriteLine("Array is empty");
            }
            Dictionary<int,int> hashMap = new Dictionary<int, int>();
            hashMap[0]=0;
            int sumSoFar = 0;
            for (int i = 0; i < length; i++)
            {
                sumSoFar += arr[i];
                if (hashMap.ContainsKey(sumSoFar - sum))
                {
                    Console.WriteLine("Sub array is found at :: " +
                       hashMap[sumSoFar - sum] + " and " + i);
                }
                else
                {
                    hashMap[sumSoFar]= i + 1;
                }
            }
        }

        public void twosummethods(int[] _arrayInput)
        {
            //Brute Force
            //for(int i = 0; i < _arrayInput.Length; i++)
            //  {
            //      for(int j= i+1; j< _arrayInput.Length; j++)
            //      {
            //         if(_arrayInput[i] + _arrayInput[j] == _sum)
            //          {
            //              result += _arrayInput[i] + "," + _arrayInput[j] + " ";

            //            }

            //      }
            //  }
            //  return result; 


            //Hashing

            //HashSet<int> s = new HashSet<int>();
            //int count = 0;
            //for (int i = 0; i < _arrayInput.Length; ++i)
            //{
            //    int temp = _sum - _arrayInput[i];

            //    // checking for condition 
            //    if (s.Contains(temp))
            //    {
            //        Console.Write("Pair with given sum " +
            //                      _sum + " is (" + _arrayInput[i] +
            //                           ", " + temp + ")");
            //        count++;
            //    }
            //    s.Add(_arrayInput[i]);
            //}
            //Console.WriteLine("count" +count);

            //pointers
            int l, r;

            /* Sort the elements */
            Array.Sort(_arrayInput);


            l = 0;
            r = _arrayInput.Length - 1;
            while (l < r)
            {
                if (_arrayInput[l] + _arrayInput[r] == _sum)
                {
                    Console.WriteLine(_arrayInput[l] + " " + _arrayInput[r]);
                    l++;
                }
                else if (_arrayInput[l] + _arrayInput[r] < _sum)
                    l++;
                else
                    r--;

            }
            if (l == r)
            {
                return;
            }
        }
        public void threesummethods(int[] _arrayInput)
        {
            //3 numbers sum(Pointers and bruteforce refer GeeksforGeeks)
            for (int i = 0; i < _arrayInput.Length; i++)
            {

                HashSet<int> s = new HashSet<int>();
                int twosum = _sum - _arrayInput[i];

                for (int j = i + 1; j < _arrayInput.Length; j++)
                {
                    int threesum = twosum - _arrayInput[j];

                    if (s.Contains(threesum))
                    {
                        Console.WriteLine("(" + _arrayInput[i] + "," + _arrayInput[j] + "," + threesum + ")");
                    }

                    s.Add(_arrayInput[j]);
                }
            }
        }
    }

}
