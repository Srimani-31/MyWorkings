using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
  class Program
  {
    static void Main(string[] args)
    {
      //List<List<long>> sides = new List<List<long>>();
      //sides.Add(new List<long> { 2, 1 });
      //sides.Add(new List<long> { 10, 7 });
      //sides.Add(new List<long> { 9, 6 });
      //sides.Add(new List<long> { 6, 9 });
      //sides.Add(new List<long> { 7, 3 });
      //Console.WriteLine(nearlySimilarRectangles(sides));

      List<int> crewId = new List<int>() { 5, 5, 3, 1, 4, 6 };
      List<int> jobId = new List<int>() { 5, 9, 8, 3, 15, 1 };
      //Console.WriteLine(getMinCost(crewId, jobId));
      //string encoded = "ÃËÑÊ PIN äÁè¶Ù¡µéÍ§";
      //byte[] bytes = Encoding.Default.GetBytes(encoded);
      //Console.WriteLine(DecodeText(encoded));

      int[] nums = { 2, 7, 11, 15 };
      int targetSum = 9;
      Console.WriteLine(TwoSum.CheckForTwoSum(nums, targetSum).ToArray().);
      Console.ReadLine();
    }
    static string DecodeText(string input)
    {
      // Assuming the input is in the default encoding
      byte[] bytes = Encoding.Default.GetBytes(input);
      string decodedText = Encoding.Default.GetString(bytes);

      return decodedText;
    }
    public static long nearlySimilarRectangles(List<List<long>> sides)
    {
      long nearlySimilarRectangleCount = 0;

      for (int i = 0; i < sides.Count; i++)
      {
        for (int j = i + 1; j < sides.Count; j++)
        {
          int count = sides.Count;
          double left = ((double)sides[i][0] / (double)sides[j][0]);
          double right = ((double)sides[i][1] / (double)sides[j][1]);
          if (left == right)
            nearlySimilarRectangleCount += 1;

        }
      }
      return nearlySimilarRectangleCount;
    }

    public static long getMinCost(List<int> crew_id, List<int> job_id)
    {
      crew_id = crew_id.OrderBy(x => x).ToList();
      job_id = job_id.OrderBy(x => x).ToList();

      long minCost = 0;

      for(int i=0; i<crew_id.Count; i++)
      {
        minCost += Math.Abs(crew_id[i] - job_id[i]);
      }

      return minCost;
    }



  }
}


