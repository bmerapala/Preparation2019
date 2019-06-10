using Algorithms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class SubstringsAndSubArrays :IAlgorithm
    {
        int[] arr1;
        int[] arr2;
        int min;
        int result;
        public SubstringsAndSubArrays(int[] _arr1, int[] _arr2)
        {
            arr1 =_arr1;
            arr2 = _arr2;
            min= int.MinValue;
        }
        public void Execute()
        {
          indexofsubstringinstring("a","bhavana");

            //Union & Intersection of 2 arrays
            //HashSet<int> s1 = new HashSet<int>();
            //HashSet<int> s2 = new HashSet<int>();

            //foreach(int item in arr1)
            //{
            //    s1.Add(item);
            //}

            //foreach(int item in arr2)
            //{

            //    s1.Add(item);
            //    //union
            //    //if (s1.Contains(item)){
            //    //    Console.WriteLine(item + " ");
            //    //}
            //}

            //foreach(int item in s1)
            //{
            //    Console.WriteLine(item + " ");
            //}

            //Get all the substrings
            //for (int i = 0; i < n; i++)
            //    for (int j = 1; j <= n - i; j++)
            //        Console.WriteLine(str.Substring(i, j));

            //Mode

            Dictionary<int, int> D = new Dictionary<int, int>();
            foreach(int item in arr1)
            {
                if (D.ContainsKey(item)){
                    D[item] = D[item]+1;
                }
                else
                {
                    D[item] = 1;
                }
            }


            //foreach(KeyValuePair<int, int> item in D)
            //{
            //    Console.WriteLine(item.Key + " " + item.Value );
            //}

            foreach(int key in D.Keys)
            {
                 
                if (D[key] > min)
                {
                    min = D[key];
                    result = key;
                }
            }
          //  Console.WriteLine(result);
    }

        public void indexofsubstringinstring(string s1,string s2)
        {
            int M = s1.Length;
            int N = s2.Length;

            for (int i = 0; i < N; i++)
            {
                for (int j = 1; j <= N-i; j++)
                {
                    if (s2.Substring(i, j) == s1)
                    {
                        Console.WriteLine(i);
                        break;
                    }
                 }
            }

            //for (int i = 0; i <= N - M; i++)
            //{
            //    int j;

            //    for (j = 0; j < M; j++)
            //        if (s2[i + j] != s1[j])
            //            break;

            //    if (j == M)
            //        return i;
            //}

            //return -1;
        }
    }
}
