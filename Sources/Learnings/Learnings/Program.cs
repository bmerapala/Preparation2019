using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learnings
{
    class Program
    {
        static void Main(string[] args)
        {
             IGradeTracker book =new ThrowAwayGradeBook();

            book.AddGrade(21);
            book.AddGrade(21.5f);
            book.AddGrade(75);

            GradeStatistics stats = book.ComputeStatistics();
            Console.WriteLine("Average "+ stats.AverageGrade);
            Console.WriteLine("Lowest "+stats.LowestGrade);
            Console.WriteLine("Highest "+stats.HighestGrade);
        }
    }
}
