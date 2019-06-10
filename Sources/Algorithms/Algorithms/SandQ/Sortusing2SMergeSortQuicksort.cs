using Algorithms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class Sortusing2SMergeSortQuicksort:IAlgorithm
    {
       public void Execute()
        {
            Stack<int> input = new Stack<int>();
            input.Push(34);
            input.Push(3);
            input.Push(31);
            input.Push(98);
            input.Push(92);
            input.Push(23);
            int[] arr= { 12, 11, 13, 5, 6, 7 };

            //sortstack(input);
            //MergeSort(arr);
            //Quicksort(arr);

            foreach(int item in arr)
            {
                Console.WriteLine(item);
            }
        }
        public void QuickSort(int[] arr)
        {

        }
        public void MergeSort(int[] arr)
        {
            int l = 0;
            int r = arr.Length - 1;
           

            sort(l, r, arr);

        }
        public void sort(int l, int r, int[] arr)
        {
            if (l < r) { 
            int m = (l + r) / 2;

            sort(l, m, arr);
            sort(m + 1, r, arr);

            merge(l, m, r, arr);
            }
        }
        public void merge(int l, int m,int r, int[] arr )
        {
            int n1 = m - l+1;
            int n2 = r - m;

            int[] temp1 = new int[n1];
            int[] temp2 = new int[n2];

            for (int i = 0; i < n1; i++)
                temp1[i] = arr[l + i];
            for (int j = 0; j < n2; j++)
                temp2[j] = arr[m +1+ j];

           int i1 = 0, j1 = 0,k = l;
            while (i1<n1 && j1 < n2)
            {
                if (temp1[i1] <= temp2[j1])
                {
                    arr[k] = temp1[i1];
                    i1++;
                   
                }
                else
                {
                    arr[k] = temp2[j1];
                    j1++;
                   
                }
                k++;
            }

            while (i1 < n1)
            {
                arr[k] = temp1[i1];
                i1++;
                k++;
            }
            while (j1 < n2)
            {
                arr[k] = temp2[j1];
                j1++;
                k++;
            }


        }
        public void sortstack(Stack<int> input)
        {
            Stack<int> tmpStack = new Stack<int>();
            while (input.Count > 0)
            {
                // pop out the first element  
                int tmp = input.Pop();

                // while temporary stack is not empty and  
                // top of stack is greater than temp  
                while (tmpStack.Count > 0 && tmpStack.Peek() > tmp)
                {
                    // pop from temporary stack and  
                    // push it to the input stack  
                    input.Push(tmpStack.Pop());
                }

                // push temp in tempory of stack  
                tmpStack.Push(tmp);
            }
            while (tmpStack.Count > 0)
            {
                Console.Write(tmpStack.Pop() + " ");
            }
        }
    }
}
