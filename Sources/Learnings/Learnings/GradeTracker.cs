 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learnings
{
    public abstract class GradeTracker :IGradeTracker  
    {

        public abstract void AddGrade(float grade);
        public abstract GradeStatistics ComputeStatistics();
    }
}
