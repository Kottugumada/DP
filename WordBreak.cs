using System.Collections.Generic;

namespace DP
{
    public class WordBreakDP
    {
        /*
         WordBreak("code", ["c","o","d","e"])


                                WordBreak("code")

    c && WordBreak("ode")       co && WordBreak("de")        cod && WordBreak("e")

             
             
             */

        /// <summary>
        /// https://leetcode.com/problems/word-break/
        /// Runtime error, out of bounds need to fix
        /// https://www.youtube.com/watch?v=hLQYQ4zj0qg
        /// </summary>
        /// <param name="s"></param>
        /// <param name="wordDict"></param>
        /// <returns></returns>
        public bool WordBreak_Recursive(string s, IList<string> wordDict)
        {
            return DFS(s, new HashSet<string>(wordDict), 0);
        }

        private bool DFS(string s,HashSet<string> hs,int start)
        {
            if (start == s.Length)
            {
                return true;
            }
            for (int end = start + 1; end <= s.Length; end++)
            {
                if (hs.Contains(s.Substring(start,end)) && DFS(s,hs,end))
                {
                    return true;
                }
            }
            return false;
        }
        public bool WordBreak_Recursive_Memo(string s, IList<string> wordDict)
        {
            return DFS_Memo(s, new HashSet<string>(wordDict), 0, new Dictionary<string,bool>());
        }

        private bool DFS_Memo(string s, HashSet<string> hs, int start, Dictionary<string,bool> map)
        {
            if (start == s.Length)
            {
                return true;
            }
            if (map.ContainsKey(s))
            {
                return map[s];
            }
            for (int end = start + 1; end <= s.Length; end++)
            {
                if (hs.Contains(s.Substring(start, end)) && DFS_Memo(s, hs, end, map))
                {
                    return true;
                }
            }
            return false;
        }
        public bool WordBreak_DP(string s, IList<string> wordDict)
        {
            HashSet<string> hs = new HashSet<string>(wordDict);
            bool[] dp = new bool[s.Length + 1];
            dp[0] = true;

            for (int i = 1; i < s.Length+1; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (dp[i] && hs.Contains(s.Substring(j,i-j)))
                    {
                        dp[i] = true;
                        break;
                    }
                }
            }
            return dp[s.Length];
        }
    }
}
