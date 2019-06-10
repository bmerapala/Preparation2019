using Algorithms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
   public class MedArrays:IAlgorithm
    {
        //[] arr = { 0,0, 1, 0, 1, 0,0 };
        int[] arr = { -1, -1, 1, -1, 1, -1, -1 };
        int[] arr1 = { 0, 1, 2, 2, 1, 0, 0, 2, 0, 1, 1, 0 };
        int[] arr2 = { 9,6,3,7,9,0,2,78,2,64 };
        int[] arr3 = { 45,90,21,45,98,46,90};
        int givenSum = 0;

        public MedArrays(int[] input)
        {

        }
        public void Execute()
        {
            // LargestSubarraywithequalzerosandones(arr,givenSum);
            // sortzerosonestwos(arr1);
             mergesortedarrys(arr2, arr3);
           // Rearrangehighandlow(arr2,arr2.Length);
        }
        public void LargestSubarraywithequalzerosandones(int[] arr, int sum)
        {
            int length = arr.Length;
            int maxarraylength = 0;
            int endingindex = -1;
            int startingindex = -1;
            if (length == 0)
            {
                Console.WriteLine("Array is empty");
            }
            Dictionary<int, int> hashMap = new Dictionary<int, int>();
            hashMap[0] = 0;
            int sumSoFar = 0;
            for (int i = 0; i < length; i++)
            {
                sumSoFar += arr[i];
                if (hashMap.ContainsKey(sumSoFar - sum))
                {
                    if ((i - hashMap[sumSoFar - sum]) > maxarraylength)
                    {
                        maxarraylength = i - hashMap[sumSoFar - sum];
                        endingindex = i;
                        startingindex = hashMap[sumSoFar - sum];
                    }

                }
                else
                {
                    hashMap[sumSoFar] = i + 1;
                }
            }
            Console.WriteLine(" Max Length zero's and one's subarray found at :: " + startingindex + " " + endingindex
                      );

        }
        public void sortzerosonestwos(int[] arr1)
        {
            int countzero = 0;
            int countone = 0;
            int counttwo = 0;

            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] == 0)
                countzero++;
                else if (arr1[i] == 1)
                countone++;
                else if (arr1[i] == 2)
                counttwo++;
             }
            for(int i = 0; i < countzero; i++)
            {
                arr1[i] = 0;
            }
            for (int i = countzero; i < countzero+countone; i++)
            {
                arr1[i] = 1;
            }
            for (int i = countzero+countone; i < countzero+countone+counttwo; i++)
            {
                arr1[i] = 2;
            }

            for(int i = 0; i < arr1.Length; i++)
            {
                Console.WriteLine(arr1[i] + ",");
            }
        }
        public void mergesortedarrys(int[] arr2, int[] arr3)
        {
            Array.Resize(ref arr3, arr2.Length + arr3.Length);
            int j = 0;
               for(int i = arr3.Length; i < arr2.Length + arr3.Length; i++)
                 {
                arr3[i-arr2.Length] = arr2[j];
                j++;
               }
            Array.Sort(arr3);
            for (int i = 0; i < arr3.Length; i++)
            {
                Console.WriteLine(arr3[i]);
            }
           
        }

        public void Rearrangehighandlow(int[] arr, int n)
        {
            Array.Sort(arr);
            int i = 0, j = n - 1;
            while (i < j)
            {
                Console.Write(arr[j--] + " ");
                Console.Write(arr[i++] + " ");
            }
            if (n % 2 != 0)
                Console.WriteLine(arr[i]);
        }

    }
}
