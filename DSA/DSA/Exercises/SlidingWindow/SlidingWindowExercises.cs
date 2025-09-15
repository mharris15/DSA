using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Exercises.SlidingWindow
{
    public class SlidingWindowExcercises
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
    }
}
