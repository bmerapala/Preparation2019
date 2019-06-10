using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learnings
{
   public class GradeBook : GradeTracker { 
        protected List<float> grades;

        public GradeBook()
        {
           grades = new List<float>();
        }
        public override void AddGrade(float grade)
        {
             
            grades.Add(grade); 

        }

        public override GradeStatistics ComputeStatistics()
        {
            GradeStatistics stats = new GradeStatistics();
            float sum = 0;
            foreach(float grade in grades)
            {
               
                    stats.HighestGrade =Math.Max(stats.HighestGrade, grade);
                    stats.LowestGrade = Math.Min(stats.LowestGrade, grade);

                    sum += grade;
            }
            stats.AverageGrade = sum / grades.Count;

            return stats;
        }


    }
}
