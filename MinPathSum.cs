using System;
using System.Collections.Generic;

namespace DP
{
    public class MinPathSum
    {
        public class Solution
        {
            /// <summary>
            /// https://leetcode.com/problems/minimum-path-sum/
            /// find a path from top left to bottom right which 
            /// MINIMIZES the sum of all numbers along its path.
            /// </summary>
            /// <param name="grid"></param>
            /// <returns></returns>
            public int MinPathSum(int[][] grid)
            {
                if (grid == null || grid.Length == 0)
                {
                    return 0;
                }
                // dp grid to mirror the input
                int[,] dp = new int[grid.Length, grid[0].Length];
                for (int i = 0; i < grid.Length; i++)
                {
                    for (int j = 0; j < grid[0].Length; j++)
                    {
                        // begining node
                        if (i == 0 && j == 0)
                        {
                            dp[i, j] = grid[i][j];
                        }
                        // first column
                        else if (j == 0)
                        {
                            dp[i, j] = grid[i][j] + dp[i - 1, j];
                        }
                        // first row
                        else if (i == 0)
                        {
                            dp[i, j] = grid[i][j] + dp[i, j - 1];
                        }
                        else
                        {
                            dp[i, j] = grid[i][j] + Math.Min(dp[i - 1, j], dp[i, j - 1]);
                        }
                    }
                }
                return dp[grid.Length - 1, grid[0].Length - 1];
            }
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
                if (n==0)
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
                    dp[i] = Math.Min(dp[i-1], dp[i-2]) + cost[i];
                }
                return Math.Min(dp[n - 1],dp[n-2]);
            }
            /// <summary>
            /// https://leetcode.com/problems/coin-change/
            /// Write a function to compute the FEWEST number of coins that you need to make up that amount.
            /// </summary>
            /// <param name="coins"></param>
            /// <param name="amount"></param>
            /// <returns></returns>
            public int CoinChange(int[] coins, int amount)
            {
                int[] dp = new int[amount + 1]; // initialize to a value which has all possibilities including 0 amount
                Array.Sort(coins);
                Array.Fill(dp, amount+1);
                dp[0] = 0; // there are zero wasy to make zeo amount
                for (int i = 0; i <= amount; i++)
                {
                    for (int j = 0; j < coins.Length; j++)
                    {
                        if (coins[j]<=i)
                        {
                            dp[i] = Math.Min(dp[i], dp[i - coins[j]]);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                return dp[amount] > amount ? -1 : dp[amount]; // for cases dp of amount never got updated
            }
        }
    }
}
