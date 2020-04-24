using System;

namespace DP
{
    public class EditDistance
    {
        /// <summary>
        /// https://leetcode.com/problems/edit-distance/
        /// levenshtein distance
        /// </summary>
        /// <param name="word1"></param>
        /// <param name="word2"></param>
        /// <returns></returns>
        public int MinDistance(string word1, string word2)
        {
            int m = word1.Length;
            int n = word2.Length;

            int[][] cost = new int[m + 1][];

            // initialize grid
            for (int i = 0; i <= m; i++)
            {
                cost[i] = new int[n + 1];
            }
            // initialize rows
            for (int i = 0; i <= m; i++)
            {
                cost[i][0] = i;
            }
            // initialize columns
            for (int i = 0; i <= n; i++)
            {
                cost[0][i] = i;
            }

            // fill the table
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (word1[i] == word2[j])
                    {
                        cost[i + 1][j + 1] = cost[i][j];
                    }
                    else
                    {
                        // possible operations
                        int replace = cost[i][j];
                        int insert = cost[i][j + 1];
                        int delete = cost[i + 1][j];

                        // now calculate the minimum cost of the operations
                        // and cost 1 for doing the operation
                        cost[i + 1][j + 1] = 1 + Math.Min(Math.Min(insert, delete), replace);
                    }
                }
            }
            return cost[m][n];
        }
    }
}
