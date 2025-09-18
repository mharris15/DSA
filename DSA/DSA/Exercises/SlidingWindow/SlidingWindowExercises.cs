using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Exercises.SlidingWindow
{
    public class SlidingWindowExercises
    {
        /// <summary>
        /// Determines if the array contains duplicate elements within a given distance.
        /// </summary>
        /// <param name="nums">The input array of integers.</param>
        /// <param name="k">The maximum index distance between duplicate elements.</param>
        /// <returns>
        /// True if there are two distinct indices i and j in the array such that nums[i] == nums[j] and abs(i - j) &lt;= k; otherwise, false.
        /// </returns>
        /// <remarks>
        /// - Uses a sliding window approach for efficient duplicate detection.
        /// - Runs in O(n) time and uses O(k) extra space.
        /// </remarks>
        public bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            var window = new HashSet<int>();
            var left = 0;
            for (var right = 0; right < nums.Length; right++)
            {
                if (right - left > k)
                {
                    window.Remove(nums[left]);
                    left++;
                }
                if (!window.Add(nums[right]))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Given an array of stock prices where prices[i] is the price on day i,
        /// this method finds the maximum profit achievable by choosing a single
        /// day to buy and a later day to sell.
        /// </summary>
        /// <param name="prices">Array of stock prices by day</param>
        /// <returns>
        /// Maximum profit from one transaction (buy once, sell once). 
        /// Returns 0 if no profit is possible.
        /// </returns>
        public int MaxProfit(int[] prices)
        {
            var minPrice = int.MaxValue;
            var maxProfit = 0;

            foreach (var price in prices)
            {
                if (price < minPrice)
                {
                    minPrice = price;
                }
                else if (price - minPrice > maxProfit)
                {
                    maxProfit = price - minPrice;
                }
            }
            return maxProfit;
        }
    }
}
