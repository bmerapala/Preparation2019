using Algorithms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Arrays
{
    class PermParanthesisBinaryOpDeckShuffle :IAlgorithm
    {
        string input;
        string str = "for (var i = 0; i < str.length); i++ {var chr = str[i]{}";
        //shuffle deck of cards
        int[] arr =  {0, 1, 2, 3, 4, 5, 6, 7, 8,
                   9, 10, 11, 12, 13, 14, 15,
                   16, 17, 18, 19, 20, 21, 22,
                   23, 24, 25, 26, 27, 28, 29,
                   30, 31, 32, 33, 34, 35, 36,
                   37, 38, 39, 40, 41, 42, 43,
                   44, 45, 46, 47, 48, 49, 50,
                   51};
        public PermParanthesisBinaryOpDeckShuffle(string _input)
        {
            input = _input;
        }

        public string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        public void Execute()
        {
           // Console.WriteLine(  Reverse(input));

            //sum of binary numbers(Refer Notepad);
           // permutations(input, 0, input.Length - 1);
            balancedparanthesis( str);
         shuffle(arr, arr.Length);

        }
        public void balancedparanthesis(string str)
        {

            char[] exp = str.ToCharArray();
            if (areParenthesisBalanced(exp))
                Console.WriteLine("Balanced ");
            else
                Console.WriteLine("Not Balanced ");

        }
        public void shuffle(int[] arr,int len)
        {
            Random rand = new Random();

            for(int i = 0; i < len; i++)
            {
                int r = i + rand.Next(len - i);

                int temp = arr[r];
                arr[r] = arr[i];
                arr[i] = temp;
            }
            for (int i = 0; i < 52; i++)
                Console.Write(arr[i] + " ");

        }
        public bool isMatchingPair(char character1, char character2)
        {
            if (character1 == '(' && character2 == ')')
                return true;
            else if (character1 == '{' && character2 == '}')
                return true;
            else if (character1 == '[' && character2 == ']')
                return true;
            else
                return false;
        }

        /* Return true if expression has balanced 
        Parenthesis */
        public bool areParenthesisBalanced(char[] exp)
        {
            /* Declare an empty character stack */
            Stack<char> st = new Stack<char>();
          

            /* Traverse the given expression to 
                check matching parenthesis */
            for (int i = 0; i < exp.Length; i++)
            {
                if (exp[i] == '{' || exp[i] == '(' || exp[i] == '[')
                    st.Push(exp[i]);
                
                if (exp[i] == '}' || exp[i] == ')' || exp[i] == ']')
                {
                    if (st.Count() == 0)
                    {
                        return false;
                    }
                    else if (!isMatchingPair(st.Pop(), exp[i]))
                    {
                        return false;
                    }
                }

            }
          if (st.Count() == 0) return true; 
          else  return false;
        }
        private void permutations(String str,
                               int l, int r)
        {
            if (l == r)
                Console.WriteLine(str);
            else
            {
                for (int i = l; i <= r; i++)
                {   
                    str = swap(str, l, i);
                    permutations(str, l + 1, r);

                   
                }
            }
        }
        public String swap(String a,int i, int j)
        {
            char temp;
            char[] charArray = a.ToCharArray();
            temp = charArray[i];
            charArray[i] = charArray[j];
            charArray[j] = temp;
            return new string(charArray);
            
        }
    }
}
