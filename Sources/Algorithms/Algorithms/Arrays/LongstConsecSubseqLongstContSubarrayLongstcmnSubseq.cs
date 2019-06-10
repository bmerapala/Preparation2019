using Algorithms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Arrays
{
    class LongstConsecSubseqLongstContSubarrayLongstcmnSubseq : IAlgorithm
    {
        int[] arr;
        int[] arr1 = { 10, 12, 12, 10, 10, 11, 10 };
        String s1 = "AXYT";
        String s2 = "AYZX";

        
        public LongstConsecSubseqLongstContSubarrayLongstcmnSubseq(int[] input)
        {
            arr = input;

        }
        public void Execute()
        {
            
            //LongstConsecSubseq(arr, arr.Length);
            Console.WriteLine(LongstContSubarray(arr1));
            LCS(s1,s2);

        }
        public int LongstContSubarray(int[] arr1){
            int max_len = 0;

            for(int i = 0; i < arr1.Length-1; i++)
            {
                HashSet<int> hs = new HashSet<int>();
                hs.Add(arr1[i]);

                int max = arr1[i];
                int min = arr1[i];
                
                for(int j=i+1;j<arr1.Length; j++)
                {
                    if (hs.Contains(arr1[j])) break;
                    else hs.Add(arr1[j]);

                     max = Math.Max(max,arr1[j]);
                     min = Math.Min(min, arr1[j]);

                    if (max - min == j - i) {

                        max_len = Math.Max(max_len, max - min + 1);
                    }                }
            }
            return max_len;
        }
        public int LongstConsecSubseq(int[] arr,int n)
        {
            HashSet<int> S = new HashSet<int>();
            int ans = 0;

            // Hash all the array elements  
            for (int i = 0; i < n; ++i)
            {
                S.Add(arr[i]);
            }

            // check each possible sequence from the start  
            // then update optimal length  
            for (int i = 0; i < n; ++i)
            {
                // if current element is the starting  
                // element of a sequence  
                if (!S.Contains(arr[i] - 1))
                {
                    // Then check for next elements in the  
                    // sequence  
                    int j = arr[i];
                    while (S.Contains(j))
                    {
                        j++;
                    }

                    // update  optimal length if this length  
                    // is more  
                    if (ans < j - arr[i])
                    {
                        ans = j - arr[i];
                    }
                }
            }
            return ans;
        }

        public void LCS(string s1, string s2)
        {
            char[] X = s1.ToCharArray();
            char[] Y = s2.ToCharArray();
            int m = X.Length;
            int n = Y.Length;
            Console.Write("Length of LCS is" + " "
                    + lcs(X, Y, m, n));
        }
        static int lcs(char[] X, char[] Y, int m, int n)
        {
            if (m == 0 || n == 0)
                return 0;
            if (X[m - 1] == Y[n - 1])
                return 1 + lcs(X, Y, m - 1, n - 1);
            else
                return Math.Max(lcs(X, Y, m, n - 1), lcs(X, Y, m - 1, n));
        }
    }
}
