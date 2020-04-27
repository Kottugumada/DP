using System;

namespace DP
{
    public class CoinChangeDP
    {
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
            Array.Fill(dp, amount + 1);
            dp[0] = 0; // there are zero wasy to make zeo amount
            for (int i = 0; i <= amount; i++)
            {
                for (int j = 0; j < coins.Length; j++)
                {
                    if (coins[j] <= i)
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
