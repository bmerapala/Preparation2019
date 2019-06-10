using Algorithms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Arrays
{

   //Refer Array subsequnece from Algorithmorizon
    class SubsequencesArrayString :IAlgorithm
    {
        String input;
        public SubsequencesArrayString(String _input)
        {
            input = _input;
        }
        public void Execute()
        {
            int[] temp = new int[input.Length];
            int index = 0;
            solve(input, index, temp);

        }
        private void solve(String input, int index, int[] temp)
        {
            if (index == input.Length)
            {
                print(input, temp);
                return;
            }
            //set the current index bit and solve it recursively
            temp[index] = 1;
            solve(input, index + 1, temp);
            //unset the current index bit and solve it recursively
            temp[index] = 0;
            solve(input, index + 1, temp);
        }

        private void print(String input, int[] temp)
        {
            String result = "";
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] == 1)
                    result += input[i];
            }
            if (result == "")
                result = "{Empty Set}";
            Console.WriteLine(result + " ");
        }

    }
}
