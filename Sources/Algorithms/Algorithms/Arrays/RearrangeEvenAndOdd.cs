using Algorithms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Arrays
{
    class RearrangeEvenAndOdd : IAlgorithm
    {
        int[] array;

        public RearrangeEvenAndOdd(int[] input)
        {
            array = input;

        }

        public void Execute()
        {
            int odd = 1;
            int even = 0;
            while (true)
            {
                while (even < array.Length && array[even] == 0)
                    even += 2;
                while (odd < array.Length && array[odd] == 1)
                    odd += 2;
                if (even < array.Length && odd < array.Length) { 
                int temp = array[even];
                array[even] = array[odd];
                array[odd] = temp;
            }
                else
                    break;
            }

            for (int i = 0; i < array.Length; i++)
                Console.Write(array[i] + " ");
        }

    }
}