using Algorithms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Arrays
{
    class GCD_ModifyMatrix_InfixtPostfix : IAlgorithm
    {
        int a, b;
        int nrow, ncol;
        int[,] mat = { { 1, 0, 0, 1 }, { 1, 1, 1, 1 }, { 1, 0, 1, 1 } };
        int[] a1 = { 10, 5, 15 };
        int[] b1 = { 20, 3, 2, 12 };
        int[] res = new int[70];


        public GCD_ModifyMatrix_InfixtPostfix(int Input1, int Input2)
        {
            a = Input1;
            b = Input2;
           }
        public void Execute()
        {
            //Console.WriteLine(GCDRecursive(a, b));
            //ModifyMatrix(mat);
           // sortedMerge(a1,b1,res,a1.Length,b1.Length);
           //Console.WriteLine(InfixToPostfix("a+b()"));

           int[] arr = new int[] { 4, 7, 8, -6, -4, -6, -8, 9, -6, 9, 15, 4 };
           subArray(arr, arr.Length);

        // Prints all subarrays in arr[0..n-1]
       
    }
        public void subArray(int[] arr,int n)
    {
            int count = 0;
            int maxcount = 0;
            int start = 0;
            int maxstart = 0;
            int sumsofar = 0;
            //{ -4, -7,8,6,4,6,8,9,-6,9,5,4};
            for (int i = 0; i < arr.Length; i++)
            {
                
                if (arr[i] > 0)
                {
                    count++;
                    sumsofar += arr[i];
                    if (count > maxcount) {
                        maxcount = count;
                        maxstart = start;
                    }
                        
                }
                else
                {
                    sumsofar = 0;
                    count = 0;
                    start = i+1;
                }
              
                
            }
            //Console.WriteLine(maxcount);
            //Console.WriteLine(maxstart);
             for(int j = maxstart; j < maxstart+maxcount; j++)
            {
                Console.WriteLine(arr[j]);
            }
        }
    public static int Prec(char c)
        {
            switch (c)
            {
                case '+':
                case '-': return 1;
                case '*':
                case '/': return 2;
                case '^':return 3;
                default: return -1;



            }
        }

        public string CItoP(string result, Stack<char> s, string exp) {
            for (int i = 0; i < exp.Length; i++)
            {
                char c = exp[i];
                if (char.IsLetterOrDigit(c))
                {
                    result += c;
                }
                else if (c == '(')
                {
                    s.Push(c);
                }
                else if (c == ')')
                {

                    while (s.Count > 0 && s.Peek() != '(')
                    {
                        result += s.Pop();
                    }
                    if(s.Peek() == '(')
                    {
                        s.Pop();
                    }
                    
                }

                else
                {
                    while (s.Count > 0 && Prec(c) <= Prec(s.Peek()))
                    {
                        result += s.Pop();
                    }
                    s.Push(c);

                }
            }

            while (s.Count > 0)
            {
                result += s.Pop();
            }
            return result;
        }
        public string InfixToPostfix(string exp)
        {
            string result = "";
            Stack<char> s = new Stack<char>();
            if (exp.Contains('(') && !exp.Contains(')'))
            return "Mismatched Paran";
            else if(exp.Contains(')') && !exp.Contains('('))
            return "Mismatched Paran";
            else { return CItoP(result, s, exp); }


        }
        static void sortedMerge(int[] a, int[] b,
                   int[] res, int n, int m)
        {

            // Sorting a[] and b[] 
            Array.Sort(a);
            Array.Sort(b);

            // Merge two sorted arrays into res[] 
            int i = 0, j = 0, k = 0;

            while (i < n && j < m)
            {
                if (a[i] <= b[j])
                {
                    res[k] = a[i];
                    i += 1;
                    k += 1;
                }
                else
                {
                    res[k] = b[j];
                    j += 1;
                    k += 1;
                }
            }

            while (i < n)
            {

                // Merging remaining 
                // elements of a[] (if any) 
                res[k] = a[i];
                i += 1;
                k += 1;
            }
            while (j < m)
            {

                // Merging remaining 
                // elements of b[] (if any) 
                res[k] = b[j];
                j += 1;
                k += 1;
            }
        }
        static int GCDRecursive(int a, int b)
        {
            if (b == 0)
                return a;
            return GCDRecursive(b, a % b);

            //iterative
            //while (a != b)
            //{
            //    if (a > b)
            //        a = a - b;
            //    else
            //        b = b - a;
            //}
            //return a;
        }
        public void ModifyMatrix(int[,] mat)
        {
            List<string> L = new List<string>();
            int R = mat.GetLength(0);
            int C = mat.GetLength(1);
            for (int i = 0; i < R; i++)
            {
                for (int j = 0; j < C; j++)
                {
                    if (mat[i, j] == 0)
                    {
                        L.Add(i + "," + j);
                    }
                }
            }

            for (int i = 0; i < L.Count; i++)
            {
                nrow = int.Parse(L[i].Split(',')[0]);
                ncol = int.Parse(L[i].Split(',')[1]);

                for (int row = 0; row < C; row++)
                {
                    mat[nrow, row] = 0;
                }
                for (int col = 0; col < R; col++)
                {
                    mat[col, ncol] = 0;
                }
            }
            for (int i = 0; i < R; i++)
            {
                for (int j = 0; j < C; j++)
                {
                    Console.WriteLine(mat[i,j] + " ");
                }
            }
        }


    }
}
