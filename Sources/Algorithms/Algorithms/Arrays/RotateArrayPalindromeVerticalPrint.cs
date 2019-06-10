using Algorithms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Arrays
{
    class RotateArrayPalindromeVerticalPrint :IAlgorithm
    {
        int[] arr;
        int k;
  
        public RotateArrayPalindromeVerticalPrint(int[] array, int rotateBy)
        {
            arr = array;
            k = rotateBy;
        }
        public void Execute()
        {
           // RotateAnArray(arr);
          

        }

      public void RotateAnArray(int[] arr){

            //o(n) approach
      int[] result=new int[arr.Length];

            for (var i = 0; i < k; i++)
            {
                result[i] = arr[arr.Length - k + i];
            }

            var j = 0;
            for (var i = k; i < arr.Length; i++)
            {
                result[i] = arr[j];
                j++;
            }
            for (int i = 0; i < result.Length; i++)
                Console.Write(result[i] + " ");

            //2nd method

            //for (int i = 0; i < k; i++)
            //{
            //    leftshift(arr);
            //}
            //for (int i = 0; i < arr.Length; i++)
            //    Console.Write(arr[i] + " ");

        }

        public void leftshift(int[] arr)
        {
            int i, temp = arr[0];
            for (i = 0; i < arr.Length - 1; i++)
            {
                arr[i] = arr[i + 1];
            }
            arr[i] = temp;

        }

    }
}
