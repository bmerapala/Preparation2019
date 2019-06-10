using Algorithms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Arrays
{
    public class pair
    {
        public int first, second;
        public pair(int f, int s)
        {

            first = f;
            second = s;
        }
    }
    class SymtricPairs_abeqcdPairs_SubArr : IAlgorithm
    {
       
        int[,] arr;
        int[] inputarr = { 1, 2, 3, 4, 5, 6, 7, 8 };
        int[] A = { 2, 3, 0, 5, 1, 1, 2 };
        int[] B = { 0, 5, 1 };

       
        public SymtricPairs_abeqcdPairs_SubArr(int[,] _arr)
        {
            arr = _arr;
        }
       
        public void Execute()
        {
            // arr[] = {{11, 20}, {30, 40}, {5, 10}, {40, 30}, {10, 5}}

            //  SymmetricPairs(arr);
             abcdPairs(inputarr);
            //digSum(1655);
           // Console.WriteLine(SubArray(A, B, A.Length, B.Length));
        }
        //sum of digits until it becomes 1 digit
        static int digSum(int n)
        {
            if (n == 0)
                return 0;
            return (n % 9 == 0) ? 9 : (n % 9);
        }
        public void SymmetricPairs(int[,] arr)
        {
            Dictionary<int, int> D = new Dictionary<int, int>();
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                int first = arr[i, 0];
                int second = arr[i, 1];

                if (!D.ContainsKey(second))
                {
                    D[first] = second;
                }
                else
                {
                    int val = D[second];
                    if (val != 0 && val == first)
                    {
                        Console.WriteLine("(" + second + ", " + first + ")");
                    }
                }
            }
        }

        public void abcdPairs(int[] arr1)
        {
            Dictionary<int, pair> Di = new Dictionary<int, pair>();
           
            for (int i = 0; i < arr1.Length; i++)
            {
                for(int j = i; j < arr1.Length; j++)
                {
                    int prod = arr1[i] * arr1[j];
                    if (!Di.ContainsKey(prod))
                    {
                        
                        Di[prod] = new pair(i, j);

                    }
                    else
                    {
                        pair p = Di[prod];
                        
                        Console.WriteLine(arr1[p.first]
                              + " " + arr1[p.second]
                              + " " + "and" + " " +
                             arr1[i] + " " + arr1[j]);

                    }
                }
            }
        }

        public bool SubArray(int[] A, int[] B,int m, int n)
        {
            int i = 0, j = 0;
            while(i<m && j < n)
            {
               if( A[i] == B[j])
                {
                    i++;
                    j++;

                    if (j == n)
                    {
                        //Console.WriteLine(  (j+1) + " " + (i - 1) );
                        return true;
                    }
                }

                else
                {
                    j = 0;
                    i++;
                }
            }
            return false;
        }
    }

    
}
