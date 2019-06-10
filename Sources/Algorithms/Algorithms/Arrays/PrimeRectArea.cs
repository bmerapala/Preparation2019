using Algorithms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Arrays
{
    public class point
    {

        public int x, y;
        public point(int f, int s)
        {

            x = f;
            y = s;
        }
    }
    class PrimeRectArea :IAlgorithm
    {
        int n;

        point l1 = new point( 2, 1 ), r1 = new point(5, 5 );
        point l2 = new point(3, 2 ), r2 = new point(5, 7 );
        public PrimeRectArea(int _input)
        {
            n = _input;
           
        }

        public void Execute()
        {
            int[] hist = {2, 1, 5, 6, 2, 3};
            largestRectanglularAreaInHistogram(hist);
            Console.WriteLine(overlappingArea(l1, r1, l2, r2));

            //prime factors refer notepad++

            string factors = "";

            for (int i = 2; i <= n; i++)
            {
                while ((n % i) == 0)
                {
                    factors += i + " ";
                    n = n / i;
                }
            }
           
                Console.WriteLine("factors" + factors);
            
            //Nth prime
            int num, count;
            for (num = 2, count = 0; count < n; ++num)
            {
                if (isPrime(num))
                {
                    ++count;
                }
            }
            // The candidate has been incremented once after the count reached n
            Console.WriteLine( num - 1 + "res");

        }

        public void largestRectanglularAreaInHistogram(int[] hist)
        {
            int maxArea = 0;

            // Iterate through the histogram.
            for (int i = 0; i < hist.Length; ++i)
            {
                int h = hist[i];


                for (int j = i + 1; j < hist.Length; ++j)
                {
                     int w = (j-i+1);

                    h = Math.Min(h, hist[j]);

                    maxArea = Math.Max(maxArea, h * w);
                }
            }
            Console.WriteLine("maxarea"+maxArea);
        }

        private static bool isPrime(int n)
        {
            for (int i = 2; i < n; ++i)
            {
                if (n % i == 0)
                {
                    // We are naive, but not stupid, if
                    // the number has a divisor other
                    // than 1 or itself, we return immediately.
                    return false;
                }
            }
            return true;
        }
        public int overlappingArea(point l1, point r1,
                   point l2, point r2)
        {
            // Area of 1st Rectangle 
            int area1 = Math.Abs(l1.x - r1.x) *
                        Math.Abs(l1.y - r1.y);

            // Area of 2nd Rectangle 
            int area2 = Math.Abs(l2.x - r2.x) *
                        Math.Abs(l2.y - r2.y);

            int areaI = (Math.Min(r1.x, r2.x) -
                        Math.Max(l1.x, l2.x)) *
                        (Math.Min(r1.y, r2.y) -
                         Math.Max(l1.y, l2.y));
            // Console.WriteLine(areaI);
            return (area1 + area2 - areaI);
        }
    }
}
