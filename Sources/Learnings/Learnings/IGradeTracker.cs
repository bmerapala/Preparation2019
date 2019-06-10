namespace Learnings
{
    internal interface IGradeTracker
    {
      void AddGrade(float grade);
      GradeStatistics ComputeStatistics();
    }
}