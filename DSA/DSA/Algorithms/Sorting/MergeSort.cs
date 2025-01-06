namespace Algorithms
{
    public static partial class Sorter
    {
        public static void MergeSort<T>(IList<T> collection, int l, int r, Comparison<T> comparison)
        {
            if (l < r)
            {
                // Correct midpoint calculation
                int m = l + (r - l) / 2;

                // Recursively sort left half
                MergeSort(collection, l, m, comparison);

                // Recursively sort right half
                MergeSort(collection, m + 1, r, comparison);

                // Merge sorted halves
                Merge(collection, l, m, r, comparison);
            }
        }

        private static void Merge<T>(IList<T> collection, int l, int m, int r, Comparison<T> comparison)
        {
            int n1 = m - l + 1;
            int n2 = r - m;

            // Create temporary arrays for left and right
            IList<T> left = new List<T>(n1);
            IList<T> right = new List<T>(n2);

            // Copy data to temporary arrays
            for (int i = 0; i < n1; i++)
                left.Add(collection[l + i]);

            for (int j = 0; j < n2; j++)
                right.Add(collection[m + 1 + j]);

            // Merge the arrays back into the collection
            int iIndex = 0, jIndex = 0, kIndex = l;

            while (iIndex < n1 && jIndex < n2)
            {
                if (comparison(left[iIndex], right[jIndex]) <= 0)
                {
                    collection[kIndex] = left[iIndex];
                    iIndex++;
                }
                else
                {
                    collection[kIndex] = right[jIndex];
                    jIndex++;
                }
                kIndex++;
            }

            // Copy remaining elements of left array, if any
            while (iIndex < n1)
            {
                collection[kIndex] = left[iIndex];
                iIndex++;
                kIndex++;
            }

            // Copy remaining elements of right array, if any
            while (jIndex < n2)
            {
                collection[kIndex] = right[jIndex];
                jIndex++;
                kIndex++;
            }
        }
    }
}
