using System;
using System.Collections.Generic;
using System.Text;

namespace DP
{
    public class DecodeWays
    {
        public int NumDecodings(string s)
        {
            if (string.IsNullOrEmpty(s) || s[0] == '0')
            {
                return 0;
            }
            int n = s.Length;
            int[] dp = new int[n + 1];
            // dp[i]: represents possible decode ways to the ith char(including i), whose index in string is i-1
            // Base case: dp[0] = 1 is just for creating base; 
            // dp[1], when there's one character, if it is not zero, it can be decoded in only 1 way. 
            // If it is 0, there will be no decode ways.
            dp[0] = 1;
            dp[1] = 1;
            for (int i = 2; i <= n; i++)
            {
                if (int.TryParse(s.Substring(i - 1, 1), out int first))
                {
                    if (first >= 1 && first <= 9)
                    {
                        // sum because the problem is asking total number of ways
                        dp[i] = dp[i] + dp[i - 1];
                    }
                }
                if (int.TryParse(s.Substring(i - 2, 2), out int second))
                {
                    if (second >= 10 && second <= 26)
                    {
                        dp[i] = dp[i] + dp[i - 2];
                    }
                }
            }
            return dp[n];
        }
    }
}
