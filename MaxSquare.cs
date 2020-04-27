using System;

namespace DP
{
    public class MaxSquare
    {
        public int MaximalSquare(char[][] matrix)
        {
            if (matrix == null || matrix.Length == 0 || matrix[0] == null || matrix[0].Length == 0) return 0;
            int row = matrix.Length;
            int col = matrix[0].Length;
            int maxSq = 0;
            var dp = new int[row + 1, col + 1];
            for (int i = 1; i <= row; i++)
                for (int j = 1; j <= col; j++)
                    if (matrix[i - 1][j - 1] == '1')
                    {
                        dp[i, j] = 1 + Math.Min(Math.Min(dp[i, j - 1], dp[i - 1, j]), dp[i - 1, j - 1]);
                        maxSq = Math.Max(maxSq, dp[i, j]);
                    }

            return maxSq * maxSq;
        }
    }
}
