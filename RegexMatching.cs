using System;
using System.Collections.Generic;
using System.Text;

namespace DP
{
    public class RegexMatching
    {
        public bool IsMatch(string s, string p)
        {
            //dp[i][j] means matching status between s.Substring(0, j) and p.Substring(0, i)
            if (string.IsNullOrEmpty(p))
                return string.IsNullOrEmpty(s);

            // initialize dp matrix
            bool[][] dp = new bool[s.Length + 1][];
            for (int i = 0; i < s.Length + 1; i++)
                dp[i] = new bool[p.Length + 1];

            dp[0][0] = true; // since s "" and p "" match

            for (int j = 1; j < p.Length; j++)
            {   
                //                   a        b
                //              0    j-1      j
                //      0   true    true    false     
                // a    i-1 false   true       
                // *    i    
                
                // ab
                // a*
                if (p[j] == '*' && dp[0][j - 1])
                    dp[0][j + 1] = true;
            }

            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j < p.Length; j++)
                {
                    // ab
                    // a.
                    if (s[i] == p[j] || p[j] == '.')
                    {
                        dp[i + 1][j + 1] = dp[i][j];
                    }
                    else if (p[j] == '*')
                    {
                        // s    abb
                        // p    ab*
                        // or
                        // s    ab
                        // p    .*
                        dp[i + 1][j + 1] = dp[i + 1][j - 1] 
                                            || (s[i] == p[j - 1] || p[j - 1] == '.') 
                                            && dp[i][j + 1];
                    }
                }
            }

            return dp[s.Length][p.Length];
        }
    }
}
