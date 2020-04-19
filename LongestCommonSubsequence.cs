using System;
using System.Collections.Generic;
using System.Text;

namespace DP
{
    public class LongestCommonSubsequence
    {
        public int LCS(string text1, string text2)
        {
            if (text1.Length == 0 || text2.Length == 0)
            {
                return 0;
            }
            int[,] dp = new int[text1.Length+1, text2.Length+1];
            for (int i = 1; i <= text1.Length; i++)
            {
                for (int j = 1; j <= text2.Length; j++)
                {
                    if (text1[i-1] == text2[j-1])
                    {
                        dp[i, j] = 1 + dp[i - 1, j - 1]; // 1 is for the cost of the operation
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i-1,j],dp[i,j-1]);
                    }
                }
            }
            return dp[text1.Length, text2.Length];
        }
    }
}
