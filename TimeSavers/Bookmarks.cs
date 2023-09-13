using System;
using System.Diagnostics;

namespace TimeSavers
{
    public delegate double KnowYourCodeTimeComplexity();

    internal class Bookmarks
    {
        private static double GetTimeComplexity()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < 100000000; i++)
            {
                // Simulate some time-consuming task
            }
            stopwatch.Stop();
            double elapsedTimeMs = stopwatch.ElapsedMilliseconds; // refactor to method

            return elapsedTimeMs;
        }

        public void GetRunTime(KnowYourCodeTimeComplexity codeComplexityDelegate)
        {
            double getElapsedTime = codeComplexityDelegate.Invoke();
            Console.WriteLine($"Elapsed Time of the function: {getElapsedTime} ms");
        }

        public static void Main(string[] args)
        {
            Bookmarks bookmarks = new Bookmarks();

            // Create an instance of the delegate and assign it the GetTimeComplexity method
            KnowYourCodeTimeComplexity codeComplexityDelegate = GetTimeComplexity;

            // Pass the delegate to GetRunTime
            bookmarks.GetRunTime(codeComplexityDelegate);
        }
    }
}
