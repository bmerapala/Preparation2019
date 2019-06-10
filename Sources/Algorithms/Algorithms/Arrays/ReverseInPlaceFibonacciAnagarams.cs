using Algorithms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Arrays
{
    class ReverseInPlaceFibonacciAnagarams :IAlgorithm
    {
        string[] strarr;
       
        int n = 10;
        string str = "I have beautiful eyes";
        string res = "";
        string re = "";
        int wordlen = 0;
      
        public ReverseInPlaceFibonacciAnagarams(string[]  _input)
        {
            strarr = _input;
           }
        public void Execute()
        {

         //   NRfibonacci(n);
          //  ReverseInPlace(str);
           pairsofanagrams(strarr);
           anagramstogether(strarr);
}

       public void NRfibonacci(int n)
        {
            //NR Fibonacci
            int[] fibo = { 0, 1 };

            if (n <= 1) Console.WriteLine (n);

            for (var i = 2; i <= n; i++)
            {
                fibo[i] = fibo[i - 1] + fibo[i - 2];
            }

            Console.WriteLine(fibo[n]);

        }
        public void ReverseInPlace(string str)
        {
            //reverse in place without using extra space
           
            for (int i = str.Length-1; i >= 0; i--)
            {
                res += str[i];
            }
          
            for (int i=res.Length-1;i>=0;i--)
            {

                if (res[i] == ' ' || i==0)
                {
                     if (i == 0)
                    {
                        re += " ";
                    }
                   re += res.Substring(i,wordlen+1);
                   
                    wordlen = 0;
                }
                else
                    wordlen++;
            }


            Console.WriteLine(re.Substring(1));

            //reverse in place
            //    Stack<char> st = new Stack<char>();


            //for (int i = 0; i < str.Length; i++)
            //{
            //    if (str[i] != ' ')
            //    {
            //        st.Push(str[i]);

            //    }

            //    else
            //    {
            //        while (st.Count > 0)
            //        {
            //            res += st.Pop();
            //        }
            //        res += " ";
            //    }
            //}

            //while (st.Count > 0)
            //{
            //    res += st.Pop();
            //}
            //Console.WriteLine(res);
        }
        public void pairsofanagrams(string[] strarr)
        {
            //Print all pairs of anagrams in a given array of strings

            for (int i = 0; i < strarr.Length; i++)
            {
                for (int j = i + 1; j < strarr.Length; j++)
                {
                    if (areAnagrams(strarr[i], strarr[j]))
                    {
                        Console.WriteLine(strarr[i] + " and " + strarr[j] + " are anagrams ");
                    }
                }
            }

        }
        public void anagramstogether(string[] strarr)
        {
            //print all anagrams together

            Dictionary<int, List<string>> st = new Dictionary<int, List<string>>();

            for (int i = 0; i < strarr.Length; i++)
            {
                char[] chararray = strarr[i].ToCharArray();
                Array.Sort(chararray);
                string newword = new String(chararray);
                int n = newword.GetHashCode();

                if (st.ContainsKey(n))
                {
                    List<string> words = st[n];
                    words.Add(strarr[i]);
                    //Console.WriteLine(string.Join(", ", words));
                    st[n] = words;
                }
                else
                {
                    List<string> words = new List<string>();
                    words.Add(strarr[i]);

                    st[n] = words;

                }

            }

            foreach (KeyValuePair<int, List<string>> item in st)
            {
                if (item.Value.Count > 1)
                {
                    Console.WriteLine(getListdata(item.Value));
                }

            }

        }
        public string getListdata(List<string> wordslist)
        {
            string res = "";
            foreach(string item in wordslist)
            {
                res += item + " ";
            }
            return res;
        }

        public bool areAnagrams(string str1,string str2)
        {
            int no_of_chars = 256;
            int[] count1 =new int[no_of_chars];
            int[] count2 =new int[no_of_chars];
            for (int i = 0; i < str1.Length && i< str2.Length; i++)
            {
                
                count1[str1[i]]++;
                count2[str2[i]]++;
            }
            
            if(str1.Length != str2.Length)
            {
                return false;
            }
            else
            {
                for(int i=0;i<no_of_chars;i++){
                    if(count1[i] != count2[i])
                    {
                        return false;
                    }
                }

            }
            return true;
        }
    }
}
