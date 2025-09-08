using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Exercises.ProjectEuler
{
    public class Level1
    {
        /// <summary>
        /// Calculates the sum of all natural numbers less than the given upper bound 
        /// that are divisible by 3 or 5.
        /// Uses a formula approach for O(1) performance.
        /// </summary>
        public static long MultiplesOf3or5(int n)
        {
            long SumDivisibleBy(int k)
            {
                long m = (n - 1) / k;
                return k * m * (m + 1) / 2;
            }

            return SumDivisibleBy(3) + SumDivisibleBy(5) - SumDivisibleBy(15);

        }
    }
}
