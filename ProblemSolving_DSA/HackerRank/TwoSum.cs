using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
  public class TwoSum
  {
    public static List<int> CheckForTwoSum(int[] nums, int targetSum)
    {
      var indexPairs = new List<int>();

      //Brute force algorithm
      for(int i=0; i < nums.Length; i++)
      {
        for(int j= i + 1;j < nums.Length; j++)
        {
          if(nums[i] + nums[j] == targetSum)
          {
            indexPairs.Add(i);
            indexPairs.Add(j);
          }
            
        }
      }
      return indexPairs;
    }
  }
}
