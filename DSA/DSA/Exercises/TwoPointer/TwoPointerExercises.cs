using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Exercises.TwoPointer
{
    public class TwoPointerExercises
    {
        /// <summary>
        /// Reverses the given character array in-place.
        /// </summary>
        /// <param name="s">An array of characters representing a string.</param>
        /// <remarks>
        /// - The input array is modified directly.
        /// - The algorithm runs in O(n) time and uses O(1) extra memory.
        /// </remarks>
        public void ReverseString(char[] s)
        {
            var p1 = 0;
            var p2 = s.Length - 1;
            while (p1 < p2)
            {
                var temp = s[p1];
                s[p1] = s[p2];
                s[p2] = temp;
                p1++;
                p2--;
            }
        }

        /// <summary>
        /// Determines whether the given string is a palindrome.
        /// </summary>
        /// <param name="s">The input string to check.</param>
        /// <returns>
        /// True if the string is a palindrome; otherwise, false.
        /// </returns>
        public bool IsPalindrome(string s)
        {
            s = new string(s.Where(char.IsLetterOrDigit).ToArray()).ToLower();
            var p1 = 0;
            var p2 = s.Length - 1;
            var isPalindrome = true;
            while (p1 < p2)
            {
                if (s[p1] != s[p2])
                {
                    isPalindrome = false;
                    break;
                }
                p1++;
                p2--;
            }

            return isPalindrome;
        }

        /// <summary>
        /// Determines whether the given string is a palindrome 
        /// return true if the s can be palindrome after deleting at most one character from it.
        /// </summary>
        /// <param name="s">The input string to check.</param>
        /// <returns>
        /// True if the string is a palindrome; otherwise, false.
        /// </returns>
        public bool IsPalindromeII(string s)
        {
            s = new string(s.Where(char.IsLetterOrDigit).ToArray()).ToLower();

            int p1 = 0;
            int p2 = s.Length - 1;

            while (p1 < p2)
            {
                if (s[p1] != s[p2])
                {
                    return IsPalindromeRange(s, p1 + 1, p2) || IsPalindromeRange(s, p1, p2 - 1);
                }
                p1++;
                p2--;
            }

            return true;
        }

        private bool IsPalindromeRange(string s, int left, int right)
        {
            while (left < right)
            {
                if (s[left] != s[right])
                    return false;
                left++;
                right--;
            }
            return true;
        }

        /// <summary>
        /// Merges two strings by adding letters in alternating order, starting with <paramref name="word1"/>.
        /// If one string is longer than the other, appends the remaining letters of the longer string
        /// to the end of the merged result.
        /// </summary>
        /// <param name="word1">The first string.</param>
        /// <param name="word2">The second string.</param>
        /// <returns>The merged string in alternating order.</returns>
        public string MergeAlternately(string word1, string word2)
        {
            var p1 = 0;
            var p2 = 0;
            var output = string.Empty;

            while (p1 < word1.Length && p2 < word2.Length)
            {
                output += word1[p1];
                output += word2[p2];
                p1++;
                p2++;
            }
            if (p1 < word1.Length)
            {
                output += word1[p1..];
            }
            if (p2 < word2.Length)
            {
                output += word2[p2..];
            }

            return output;
        }

        /// <summary>
        /// Merges two sorted integer arrays <paramref name="nums1"/> and <paramref name="nums2"/> 
        /// into <paramref name="nums1"/> as one sorted array in non-decreasing order.
        /// <para>
        /// This implementation works in-place from the end of both arrays to avoid extra shifting. 
        /// It starts from the largest elements and fills <paramref name="nums1"/> backwards.
        /// </para>
        /// <para>
        /// Time Complexity: O(m+n), Space Complexity: O(1).
        /// </para>
        /// </summary>
        /// <param name="nums1">
        /// The first sorted array with a total length of m + n, where the first m elements 
        /// contain valid numbers and the last n elements are empty placeholders.
        /// </param>
        /// <param name="m">The number of valid elements in <paramref name="nums1"/>.</param>
        /// <param name="nums2">The second sorted array of length n.</param>
        /// <param name="n">The number of elements in <paramref name="nums2"/>.</param >
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int p1 = m - 1;
            int p2 = n - 1;
            int p = m + n - 1;

            while (p1 >= 0 && p2 >= 0)
            {
                if (nums1[p1] > nums2[p2])
                {
                    nums1[p] = nums1[p1];
                    p1--;
                }
                else
                {
                    nums1[p] = nums2[p2];
                    p2--;
                }
                p--;
            }

            // Copy remaining nums2 elements (handles the m == 0 case)
            while (p2 >= 0)
            {
                nums1[p] = nums2[p2];
                p2--;
                p--;
            }
        }
    }
}
