using Algorithms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Arrays
{
    class LongestPalindromeUniqueCommonSubstring : IAlgorithm
    {
        string str1, str2;
        int[] arr = { -1,-2,-3,-4,50,60,-7,-8,-9,-10};
        int[] arr1 = { 0, 0, 6, 5, 0 };
        public  LongestPalindromeUniqueCommonSubstring(string input1, string input2)
        {
            str1 = input1;
            str2 = input2;
        }
        public void Execute()
        {
            //LongestUniqueSubstr(str1, str2);
            // MaxSumSubarray(arr,arr.Length);
            //   Removezeros(arr1);
            //CharsAddedToMakePalindrome("ABAADC");
            //Console.WriteLine(myAtoi("-765"));
            // PowerFunction(-1,1,20);
            //Add2BinaryStrings("1101", "110111");
            // Console.WriteLine(Multiply2Strings("15","27"));
            Console.WriteLine(Add2strings("150", "2"));



        }

        public string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
             return new string(charArray);
            //return charArray;
        }

        public string Add2strings(string str1, string str2)
        {
            if (str1.Length > str2.Length)
            {
                string t = str1;
                str1 = str2;
                str2 = t;
            }

            // Take an empty string for storing result  
            string str = "";

            // Calculate lenght of both string  
            int n1 = str1.Length, n2 = str2.Length;
            int diff = n2 - n1;

            // Initialy take carry zero  
            int carry = 0;

            // Traverse from end of both strings  
            for (int i = n1 - 1; i >= 0; i--)
            {
                // Do school mathematics, compute sum of  
                // current digits and carry  
                int sum = ((int)(str1[i] - '0') +
                        (int)(str2[i + diff] - '0') + carry);
                str += (char)(sum % 10 + '0');
                carry = sum / 10;
            }

            // Add remaining digits of str2[]  
            for (int i = n2 - n1 - 1; i >= 0; i--)
            {
                int sum = ((int)(str2[i] - '0') + carry);
                str += (char)(sum % 10 + '0');
                carry = sum / 10;
            }

            // Add remaining carry  
            if (carry > 0)
                str += (char)(carry + '0');

            
            return Reverse(str);

        }

        //public string Multiply2Strings(string num1, string num2)
        //{
        //    if (num1.Length == 0 || num2.Length == 0) return "";
        //    if (num1.Equals("0") || num2.Equals("0")) return "0";
        //    char[] c1 = Reverse(num1);
        //    char[] c2 = Reverse(num2);
        //    char[] c = new char[c1.Length + c2.Length + 1];
        //    for(int i = 0; i < c.Length; i++)
        //    {
        //        c[i] = '0';
        //    }
        //    for (int i = 0; i < c2.Length; i++)
        //    {
        //        int dig2 = c2[i] - '0';
        //        int carry = 0;
        //        for (int j = 0; j < c1.Length; j++)
        //        {
        //            int dig1 = c1[j] - '0';
        //            int temp = c[i + j] - '0';
        //            int cur = dig1 * dig2 + temp + carry;
        //            c[i + j] = (char)(cur % 10 + '0');
        //            carry = cur / 10;
        //        }
        //        c[i + c1.Length] = (char)(carry + '0');
        //    }

        //     Array.Reverse(c);
        //   string ret = new string(c);
        //    int pos = 0;
        //    while (ret[pos] == '0' && pos < ret.Length) pos++;
        //    return ret.Substring(pos);
        //}
        public void Add2BinaryStrings(string str1, string str2)
        {
            //uncomment reverse function
            str1 = Reverse(str1);
            str2 = Reverse(str2);

            string str3 = "";
            char c = '0';
            string dum = "";

            if (str1.Length > str2.Length)
            {

                for (int i = 0; i < str1.Length - str2.Length; i++)
                {
                    dum += '0';
                }
                str2 += dum;

            }

            else
            {
                for (int i = 0; i < str2.Length - str1.Length; i++)
                {
                    dum += '0';
                }
                str1 += dum;


            }
            for (int i = 0; i < str1.Length; i++)
            {
                char f = str1[i];
                char s = str2[i];
                if (f == '0' && s == '0' && c == '0')
                {
                    str3 += 0;
                    c = '0';
                    if (str3.Length == str1.Length)
                    {
                        str3 += c;
                    }
                }
                else if (f == '0' && s == '1' && c == '0')
                {
                    str3 += 1;
                    c = '0';
                    if (str3.Length == str1.Length)
                    {
                        str3 += c;
                    }
                }
                else if (f == '1' && s == '0' && c == '0')
                {
                    str3 += 1;
                    c = '0';
                    if (str3.Length == str1.Length)
                    {
                        str3 += c;
                    }
                }
                else if (f == '1' && s == '1' && c == '0')
                {
                    str3 += 0;
                    c = '1';
                    if (str3.Length == str1.Length)
                    {
                        str3 += c;
                    }
                }
                else if (f == '0' && s == '0' && c == '1')
                {
                    str3 += 1;
                    c = '0';
                    if (str3.Length == str1.Length)
                    {
                        str3 += c;
                    }
                }
                else if (f == '0' && s == '1' && c == '1')
                {
                    str3 += 0;
                    c = '1';
                    if (str3.Length == str1.Length)
                    {
                        str3 += c;
                    }
                }
                else if (f == '1' && s == '0' && c == '1')
                {
                    str3 += 0;
                    c = '1';
                    if (str3.Length == str1.Length)
                    {
                        str3 += c;
                    }
                }
                else if (f == '1' && s == '1' && c == '1')
                {
                    str3 += 1;
                    c = '1';
                    if (str3.Length == str1.Length)
                    {
                        str3 += c;
                    }
                }
            }
            str3 = Reverse(str3);
            Console.WriteLine(str3);


        }
        public void PowerFunction(int num, int power,int d)
        {
            int res = 1;
          for(int i = 0; i < power; i++)
            {
                
                res = res * num;
                
            }
     
           
            Console.WriteLine(res%d);

        }
        public bool isNumericChar(char x)
        {
            return (x >= '0' && x <= '9') ? true : false;
        }
        public int myAtoi(string str)
        {

            // Initialize result 
            int res = 0;

            // Initialize sign as positive 
            int sign = 1;

            // Initialize index of first digit 
            int i = 0;

            // If number is negative, then 
            // update sign 
            if (str[0] == '-')
            {
                sign = -1;

                // Also update index of first 
                // digit 
                i++;
            }

            // Iterate through all digits 
            // and update the result 
            for (; i < str.Length; ++i){
                if (isNumericChar(str[i]) == false)
                    return 0;
                res = res * 10 + str[i] - '0';
              

            }
               

            // Return result with sign 
            return sign * res;
        }
        public void CharsAddedToMakePalindrome(string s)
        {
            int cnt = 0;
            int flag = 0;

            while (s.Length > 0)
            {
                // if string becomes palindrome then break  
                if (isPalindrome(s))
                {
                    flag = 1;
                    break;
                }
                else
                {
                    cnt++;
                    s = s.Substring(0, s.Length - 1);
                }
            }

            // print the number of insertion at front  
            if (flag == 1)
            {
                Console.WriteLine(cnt);
            }
        
    }
        public void Removezeros(int[] arr1)
        {
            

            //1st method 
            HashSet<int> hs = new HashSet<int>();
            for (int i = 0; i < arr1.Length; i++)
            {
                if (!hs.Contains(arr[i]))
                {
                    hs.Add(arr1[i]);
                }
            }

            if (hs.Contains(0))
            {
                hs.Remove(0);
            }

            int[] arr2 = hs.ToArray();
            for (int i = 0; i < arr2.Length; i++)
            {
                Console.WriteLine(arr2[i]);
            }

            //2nd method 

            //int n = 0;
            //for (int i = 0; i < arr1.Length; i++)
            //{
            //    if (arr1[i] != 0)
            //        n++;
            //}

            //int[] newArray = new int[n];
            //int j = 0;

            //for (int i = 0; i < arr1.Length; i++)
            //{
            //    if (arr1[i] != 0)
            //    {
            //        newArray[j] = arr1[i];
            //        j++;
            //    }
            //}

            //for (int i = 0; i < newArray.Length; i++)
            //{
            //    Console.WriteLine(newArray[i]);
            //}
        }
        public void MaxSumSubarray(int[] a, int size)
        {
            int max_so_far = int.MinValue,
          max_ending_here = 0, start = 0,
          end = 0, s = 0;

            for (int i = 0; i < size; i++)
            {
                max_ending_here += a[i];

                if (max_so_far < max_ending_here)
                {
                    max_so_far = max_ending_here;
                    start = s;
                    end = i;
                }

                if (max_ending_here < 0)
                {
                    max_ending_here = 0;
                    s = i + 1;
                }
            }
            Console.WriteLine("Maximum contiguous " +
                             "sum is " + max_so_far);
            Console.WriteLine("Starting index " +
                                          start);
            Console.WriteLine("Ending index " +
                                          end);




        }
        public bool isUnique(string str)
        {
            HashSet<char> H = new HashSet<char>();
            for(int i = 0; i < str.Length; i++) {
                if (H.Contains(str[i]))
                {
                    return false;
                }
                else { H.Add(str[i]); }
               
            }
            return true;
           

        }
        public bool isPalindrome(string str)
        {
            int len = str.Length;
            for(int i = 0; i < str.Length; i++)
            {
                if (str[i] != str[len - 1])
                {
                    return false;
                }
                len--;
            }
            return true ;
        }
        public void LongestUniqueSubstr(string str1, string str2)
        {
            int maxLength = int.MinValue;
            string result = "";
           
            for (int i = 0; i < str1.Length; i++)
            {
                string subs = str1.Substring(i);
               
                for (int j = subs.Length; j >= 0; j--)
                {
                    string subs_sub = subs.Substring(0, j);
                    if (subs_sub.Length <= 1)
                        continue;
                    Console.WriteLine(subs_sub);
                    if (str2.Contains(subs_sub))
                    {
                        if (subs_sub.Length > maxLength)
                        {
                            maxLength = subs_sub.Length;
                            result = subs_sub;
                        }
                    }
                    //if (isPalindrome(subs_sub))
                    //{
                    //    if (subs_sub.Length> maxLength) {
                    //        maxLength = subs_sub.Length;
                    //        result = subs_sub;
                    //    }
                    //}

                }
            }
            Console.WriteLine(result + " " + maxLength );
        }

    }
}
