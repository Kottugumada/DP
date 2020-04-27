using System;

namespace DP
{
    public class ClimbingStairs
    {
        /// <summary>
        /// https://leetcode.com/problems/min-cost-climbing-stairs
        /// the final cost f[i] to climb the staircase from some step i is f[i] = cost[i] + min(f[i+1], f[i+2]). 
        /// This motivates dynamic programming.
        /// </summary>
        /// <param name="cost"></param>
        /// <returns></returns>
        public int MinCostClimbingStairs(int[] cost)
        {
            int n = cost.Length;
            if (n == 0)
            {
                return 0;
            }
            if (n == 1)
            {
                return cost[1];
            }
            int[] dp = new int[n];
            dp[0] = cost[0];
            dp[1] = cost[1];
            for (int i = 2; i < n; i++)
            {
                dp[i] = Math.Min(dp[i - 1], dp[i - 2]) + cost[i];
            }
            return Math.Min(dp[n - 1], dp[n - 2]);
        }
    }
}
