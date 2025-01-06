namespace Algorithms
{
    public static partial class Sorter
    {
        /*
         *  Time Complexity of Insertion Sort
         *
         *  Best case: O(n) , If the list is already sorted, where n is the number of elements in the list.
         *  Average case: O(n^2 ) , If the list is randomly ordered
         *  Worst case: O(n^2 ) , If the list is in reverse order 
         */

        /*
         *  Space Complexity of Insertion Sort
         *
         *  Auxiliary Space: O(1), Insertion sort requires O(1) additional space, making it a space-efficient sorting algorithm. 
         */

        public static void InsertionSort<T>(IList<T> collection, Comparison<T> comparison)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));

            if (comparison == null)
                throw new ArgumentNullException(nameof(comparison));

            for (int j = 0; j < collection.Count; j++)
            {
                T key = collection[j];
                var i = j - 1;
                while (i >= 0 && comparison(collection[i], key) > 0)
                {
                    collection[i + 1] = collection[i];
                    i--;
                }

                collection[i + 1] = key;
            }
        }
    }
}
