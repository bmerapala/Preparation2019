using Algorithms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Arrays
{
    class FirstNonrptnChar_EquilibruimIndex_CommonPrefix : IAlgorithm 
    {

        string str;
        int[] arr = { -7, 1, 5, 2, -4, 3, 0 };
        string str1 = "MMMDXCV";
        string[] arr1 = {"geelsforgeeks", "geeks","geek", "geekper"};
        int k = 3;
        int n = 438237764;
        static string[] one = {"", "one ", "two ", "three ", "four ",
                    "five ", "six ", "seven ", "eight ",
                    "nine ", "ten ", "eleven ", "twelve ",
                    "thirteen ", "fourteen ", "fifteen ", 
                    "sixteen ", "seventeen ", "eighteen ",
                    "nineteen "};

        // strings at index 0 and 1 are not used, 
        // they is to make array indexing simple 
        static string[] ten = {"", "", "twenty ", "thirty ", "forty ",
                    "fifty ", "sixty ", "seventy ", "eighty ",
                    "ninety "};
        public FirstNonrptnChar_EquilibruimIndex_CommonPrefix(string input)
        {
            str = input;

        }
        public void Execute()
        {
            firstnonrepeatingchar(str);
            //  equilibriumindex(arr);
            //  romanNumerals(str1);
            // xlessthanyPairs(arr);
            //   inttoroman(5643);
            //numberstowords(n);
            // Longestcommonprefix(arr1);
            // printPascal(10);
            int[] nums = { 3, 4, -1, 1 ,3};
            List<int> firstlist = new List<int>();
            firstlist.Add(2);
            firstlist.Add(1);
            firstlist.Add(4);
            firstlist.Add(47);
            firstlist.Add(2);
            firstlist.Add(1);
            firstlist.Add(4);
           // Console.WriteLine(largestNumber(firstlist));
           firstMissingPositive(nums);

        }

        public void firstMissingPositive(int[] arr)
        {

            int val = int.MaxValue;
            
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < val)
                {
                    val = arr[i];
                }
               
            }
           
            for(int i = val; i < arr.Length; i++)
            {
                if (!arr.Contains(i) && i!=0)
                {
                    Console.WriteLine(i + "Missing number");
                    break;
                }
            }
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    if (arr[Math.Abs(arr[i])] >= 0)
            //        arr[Math.Abs(arr[i])] =
            //            -arr[Math.Abs(arr[i])];
            //    else
            //        Console.Write(Math.Abs(arr[i]) + "Repeating number");
            //}
        


    }

        private static int MyComparision(string A, string B)
        {
           return A.CompareTo(B);
        }

        public string largestNumber(List<int> A)
        {
            var strA = new List<string>();
            foreach (int elem in A)
            {
                strA.Add(elem.ToString());
            }
          
            strA.Sort(MyComparision);
            strA.Reverse();
            var maxStr = string.Join("", strA.ToArray());
            maxStr = maxStr.TrimStart('0');
            if (string.IsNullOrEmpty(maxStr))
            {
                maxStr = "0";
            }
            return maxStr;
        }

        public static void printPascal(int n)
        {
            for (int line = 1;
                    line <= n; line++)
            {

                int C = 1;// used to represent C(line, i)  
                for (int i = 1; i <= line; i++)
                {
                    // The first value in a 
                    // line is always 1  
                    Console.Write(C + " ");
                    C = C * (line - i) / i;
                }

                Console.Write("\n");
            }
        }
        public void numberstowords(int n)
        {
            string output = "";

            if(n== 0)
            {
                output += "zero";
                return;
            }

            else
            {
                output += numtoword((n / 10000000), "crore ");
                output += numtoword(((n / 100000) % 100), "Lakh ");
                output += numtoword(((n / 1000) % 100), "Thousand ");
                output += numtoword(((n / 100) % 10), "Hundred ");

                if(n%100 > 0 && n > 100)
                {
                    output += "and ";
                }

                output += numtoword(n % 100, "");
                Console.WriteLine(output); 
            }
        }
        public string numtoword(int n,string s)
        {
           
            string str = "";
            if (n > 19)
            {
                str += ten[n / 10] + one[n % 10];
            }
            else
            {
                str += one[n];
            }

            if (n != 0)
            {
                str += s;
            }
            return str;
        }
        public void firstnonrepeatingchar(string str)
        {
            //  repeating naive method
            int[] nums = new int[128];

            for (int i = 0; i < str.Length; i++)
            {

                if (nums[str[i]] != 0)
                {
                    Console.WriteLine("The first repeated character is: " + str[i]);
                    break;
                }
                nums[str[i]]++;
            }



            //non-repeating naive method

            int[] count = new int[128];
            
           for (int i = 0; i < str.Length; i++)
            {
                if (count[str[i]] == 1)
                {
                    Console.WriteLine("The first non-repeating character is: " + str[i]);
                    break;
                }
                count[str[i]]++;
            }
           
          

            //hashing
            Dictionary<char, int> hs = new Dictionary<char, int>();

            char[] charArray = str.ToCharArray();

            for (int i = 0; i < charArray.Length; i++)
            {
                if (!hs.ContainsKey(charArray[i]))
                {
                    hs[charArray[i]] = 1;
                }
                else
                {
                    hs[charArray[i]] = hs[charArray[i]] + 1;
                    //firstrepeatingchar
                    //Console.WriteLine("The first repeating character is: " + charArray[i]);
                    //break;
                }
            }

            foreach (KeyValuePair<char, int> item in hs)
            {
                if (item.Value == 1)
                {
                    Console.WriteLine("The first non-repeating character is: " + item.Key);
                    break;
                }
            }
        }

        public void equilibriumindex(int[] arr)
        {

            //o(n square solution)
            //int i, j;
            //int leftsum, rightsum;

            ///* Check for indexes one by  
            // one until an equilibrium 
            //index is found */
            //for (i = 0; i < n; ++i)
            //{

            //    // initialize left sum 
            //    // for current index i 
            //    leftsum = 0;

            //    // initialize right sum 
            //    // for current index i 
            //    rightsum = 0;

            //    /* get left sum */
            //    for (j = 0; j < i; j++)
            //        leftsum += arr[j];

            //    /* get right sum */
            //    for (j = i + 1; j < n; j++)
            //        rightsum += arr[j];

            //    /* if leftsum and rightsum are 
            //     same, then we are done */
            //    if (leftsum == rightsum)
            //        return i;
            //}

            ///* return -1 if no equilibrium  
            // index is found */
            //return -1;

            //efficient solution

            int sum = 0;
            int leftsum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            for (int i = 0; i < arr.Length; i++)
            {
                sum = sum - arr[i];
                if (sum == leftsum)
                {
                    Console.WriteLine(i);
                    break;

                }
                else
                {
                    leftsum += arr[i];
                }
            }

        }

        public void romanNumerals(string str1)
        {
            int lastdecm = 0;
            int lastNumber = 0;
            String romanNumeral = str1.ToUpper();
            /* operation to be performed on upper cases even if user 
               enters roman values in lower case chars */
            for (int x = romanNumeral.Length - 1; x >= 0; x--)
            {
              
                switch (romanNumeral[x])
                {
                    case 'M':
                        lastdecm = processdecm(1000, lastNumber, lastdecm);
                        lastNumber = 1000;
                        break;

                    case 'D':
                        lastdecm = processdecm(500, lastNumber, lastdecm);
                        lastNumber = 500;
                        break;

                    case 'C':
                        lastdecm = processdecm(100, lastNumber, lastdecm);
                        lastNumber = 100;
                        break;

                    case 'L':
                        lastdecm = processdecm(50, lastNumber, lastdecm);
                        lastNumber = 50;
                        break;

                    case 'X':
                        lastdecm = processdecm(10, lastNumber, lastdecm);
                        lastNumber = 10;
                        break;

                    case 'V':
                        lastdecm = processdecm(5, lastNumber, lastdecm);
                        lastNumber = 5;
                        break;

                    case 'I':
                        lastdecm = processdecm(1, lastNumber, lastdecm);
                        lastNumber = 1;
                        break;
                }
            }
            Console.WriteLine(lastdecm);

        }

        public static int processdecm(int decm, int lastNumber, int lastdecm)
        {
            if (lastNumber > decm)
            {
                return lastdecm - decm;
            }
            else
            {
                return lastdecm + decm;
            }
        }
        public void inttoroman(int num)
        {
            // storing roman values of digits from 0-9  
            // when placed at different places 
            String[] m = { "", "M", "MM", "MMM","MMMM","MMMMM","MMMMMM","MMMMMMM", "MMMMMMMM","MMMMMMMMM" };
            String[] c = {"", "C", "CC", "CCC", "CD", "D",
                            "DC", "DCC", "DCCC", "CM"};
            String[] x = {"", "X", "XX", "XXX", "XL", "L",
                            "LX", "LXX", "LXXX", "XC"};
            String[] i = {"", "I", "II", "III", "IV", "V",
                            "VI", "VII", "VIII", "IX"};

            // Converting to roman 
            String thousands = m[num / 1000];
            String hundereds = c[(num % 1000) / 100];
            String tens = x[(num % 100) / 10];
            String ones = i[num % 10];

            String ans = thousands + hundereds + tens + ones;

            Console.WriteLine(ans);
        }

        public void xlessthanyPairs(int[] a)
        {
            int n = a.Length;
            int count = (n * (n - 1)) / 2;
            Console.WriteLine(count);
        }

        public void Longestcommonprefix(string[] arr1)
        {

            

            // naive approach


            //String prefix = arr1[0];

            //for (int i = 1; i < arr1.Length; i++)
            //{
            //    prefix = commonPrefixUtil(prefix, arr1[i]);
            //}

            //Console.WriteLine(prefix);

            //efficient method
            Array.Sort(arr1);

                // prints the common prefix of the first  
            // and the last String of the set of strings  
            Console.Write(commonPrefixUtil(arr1[0],
                                           arr1[arr1.Length - 1]));

        }
        static String commonPrefixUtil(String str1,
                               String str2)
        {
            string result = "";
            int n1 = str1.Length, n2 = str2.Length;

            // Compare str1 and str2  
            for (int i = 0, j = 0;
                     i <n1 && j < n2; i++, j++)
            {
                if (str1[i] != str2[j])
                    break;
                result += (str1[i]);
            }

            return (result);
        }
    }
}
