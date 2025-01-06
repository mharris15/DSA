namespace Algorithms
{
    public static partial class Sorter
    {
        public static void BubbleSort<T>(IList<T> collection, Comparison<T> comparison)
        {
            for (int i = 0; i < collection.Count - 1; i++)
            {
                for (int j = collection.Count - 1; j > i; j--)
                {
                    if (comparison(collection[j], collection[j - 1]) < 0)
                    {
                        T temp = collection[j];
                        collection[j] = collection[j - 1];
                        collection[j - 1] = temp;
                    }
                }
            }
        }
    }
}

