using System;
using System.Collections.Generic;
using System.Text;

namespace DP
{
    public class Knapsack
    {
        /// <summary>
        /// 0/1 Knapsack Problem
        /// </summary>
        /// <param name="W">Capacity</param>
        /// <param name="weights"></param>
        /// <param name="values"></param>
        /// <param name="n">number of items</param>
        /// <returns></returns>
        public int Knapsack01(int W,int[] weights,int[] values,int n)
        {
            int[,] knap = new int[n + 1, W + 1];

            // build table
            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= W; j++)
                {
                    if (i==0 || j==0)
                    {
                        knap[i, j] = 0;
                    }
                    else if (weights[i-1]<= j)
                    {
                        knap[i, j] = Math.Max(values[i-1] + knap[i-1,j-weights[i-1]], knap[i-1,j]);
                    }
                    else
                    {
                        knap[i,j] = knap[i - 1,j];
                    }
                }
            }
            return knap[n,W];
        }
    }
}
