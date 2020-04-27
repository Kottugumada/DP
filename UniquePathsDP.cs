namespace DP
{
    public class UniquePathsDP
    {
        /// <summary>
        /// https://leetcode.com/problems/unique-paths
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public int UniquePaths(int m, int n)
        {
            int[][] dp = new int[m][];
            for (int i = 0; i < m; i++)
                dp[i] = new int[n];

            for (int i = 0; i < m; i++)
                dp[i][0] = 1;

            for (int i = 0; i < n; i++)
                dp[0][i] = 1;

            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    dp[i][j] = dp[i - 1][j] + dp[i][j - 1];
                }
            }

            return dp[m - 1][n - 1];
        }
        /// <summary>
        /// https://leetcode.com/problems/unique-paths-ii/
        /// </summary>
        /// <param name="obstacleGrid"></param>
        /// <returns></returns>
        public int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            int rows = obstacleGrid.Length;
            int cols = obstacleGrid[0].Length;

            // If the starting cell has an obstacle, then simply return as there would be
            // no paths to the destination.
            if (obstacleGrid[0][0] == 1)
            {
                return 0;
            }

            // Number of ways of reaching the starting cell = 1.
            obstacleGrid[0][0] = 1;

            // Filling the values for the first column
            // Iterate the first row. If a cell originally contains a 1, this means the current cell has an obstacle and shouldn't contribute to any path. 
            // Hence, set the value of that cell to 0.Otherwise, set it to the value of previous cell i.e.obstacleGrid[i, j] = obstacleGrid[i, j - 1]
            for (int i = 1; i < rows; i++)
            {
                obstacleGrid[i][0] = (obstacleGrid[i][0] == 0 && obstacleGrid[i - 1][0] == 1) ? 1 : 0;
            }

            // Filling the values for the first row
            // Iterate the first column. If a cell originally contains a 1, this means the current cell has an obstacle and shouldn't contribute to any path. 
            // Hence, set the value of that cell to 0. Otherwise, set it to the value of previous cell i.e. obstacleGrid[i,j] = obstacleGrid[i-1,j]
            for (int i = 1; i < cols; i++)
            {
                obstacleGrid[0][i] = (obstacleGrid[0][i] == 0 && obstacleGrid[0][i - 1] == 1) ? 1 : 0;
            }

            // Starting from cell(1,1) fill up the values
            // No. of ways of reaching cell[i][j] = cell[i - 1][j] + cell[i][j - 1]
            // i.e. From above and left.
            /*
                Now, iterate through the array starting from cell obstacleGrid[1,1].
                If a cell originally doesn't contain any obstacle then the number of ways of reaching that cell would be 
                the sum of number of ways of reaching the cell above it and number of ways of reaching the cell to the left of it.
                obstacleGrid[i,j] = obstacleGrid[i-1,j] + obstacleGrid[i,j-1]
             */
            for (int i = 1; i < rows; i++)
            {
                for (int j = 1; j < cols; j++)
                {
                    if (obstacleGrid[i][j] == 0)
                    {
                        obstacleGrid[i][j] = obstacleGrid[i - 1][j] + obstacleGrid[i][j - 1];
                    }
                    else
                    {
                        obstacleGrid[i][j] = 0;
                    }
                }
            }

            // Return value stored in rightmost bottommost cell. That is the destination.
            return obstacleGrid[rows - 1][cols - 1];
        }
    }
}
