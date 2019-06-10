using Algorithms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Arrays
{
    public class RemoveDuplicatesfromString : IAlgorithm
    {
        string _input;

        public RemoveDuplicatesfromString(string input)
        {
            _input = input;
        }

        public void Execute()
        {
            int[] arr = { 1, 2, 2,3, 4};
            int ans=  RemoveDuplicatedArray(arr);
            for (int i = 0; i < ans; i++)
            {
                Console.Write(arr[i] + " ");
            }

          


            //Brute force
            string result = "";

            foreach (char value in _input)
            {
                // See if character is in the result already.
                if (result.IndexOf(value) == -1)
                {
                    // Append to the result.
                    result += value;
                }
            }
            Console.WriteLine(result) ;
           
            }

   
        public int RemoveDuplicatedArray(int[] A)
        {
            if (A.Length == 0 || A.Length == 1) return A.Length;

            int index = 0; // The real data
           

            for (int i = 1; i < A.Length; i++)
            {
                if (A[i] != A[index])
                {
                    index++;
                    A[index] = A[i];
                }
            }

            return index + 1;
        }

        //hashing
        //HashSet<Char> s = new HashSet<Char>();
        // //String[] s2 = new String[30];
        // for (int i = 0; i < _input.Length; i++)
        // {
        //     s.Add(_input[i]);

        // }
        // foreach (Char item in s)
        //     Console.WriteLine(item);


    }
}
