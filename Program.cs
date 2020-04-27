using System;
using System.Collections.Generic;

namespace DP
{
    class Program
    {
        static void Main(string[] args)
        {
            WordBreakDP wbdp = new WordBreakDP();
            IList<string> wordDict = new List<string>();
            wordDict.Add("leet");
            wordDict.Add("code");
            wbdp.WordBreak_DP("leetcode", wordDict);
            DecodeWays d = new DecodeWays();
            d.NumDecodings("12");
            EditDistance ed = new EditDistance();
            ed.MinDistance("HORSE","ROS");
            Console.ReadKey();
        }
    }
}
