class Program
{
    static void Main()
    {
        RunBubbleSort();
    }

    private static void RunInsertion()
    {
        var strings = new List<string> { "banana", "apple", "grape", "orange" };
        Algorithms.Sorter.InsertionSort(strings, StringComparer.Ordinal.Compare);
        Console.WriteLine("After sorting: " + string.Join(", ", strings));

        var numbers = new List<int> { 5, 2, 4, 6, 1, 3 };
        Algorithms.Sorter.InsertionSort(numbers, (x, y) => x.CompareTo(y));
        Console.WriteLine("Sorted Integers: " + string.Join(", ", numbers));
    }

    private static void RunMerge()
    {
        var numbers = new List<int> { 12, 11, 13, 5, 6, 7 };
        Algorithms.Sorter.MergeSort(numbers, 0, numbers.Count - 1, Comparer<int>.Default.Compare);

        Console.WriteLine("After Sorting: " + string.Join(", ", numbers));
    }

    public static void RunBubbleSort()
    {
        var list = new List<int> { 64, 34, 25, 12, 22, 11, 90 };
        Algorithms.Sorter.BubbleSort(list, Comparer<int>.Default.Compare);

        Console.WriteLine(string.Join(", ", list));
    }
}