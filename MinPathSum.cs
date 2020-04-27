using System;

namespace DP
{
        public class MinimumPathSum
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
        }
    }
