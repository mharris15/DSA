class Program
{
    static void Main()
    {
        var strings = new List<string> { "banana", "apple", "grape", "orange" };
        Algorithms.Sorter.InsertionSort(strings, StringComparer.Ordinal.Compare);
        Console.WriteLine("After sorting: " + string.Join(", ", strings));

        var numbers = new List<int> { 5, 2, 4, 6, 1, 3 };
        Algorithms.Sorter.InsertionSort(numbers, (x, y) => x.CompareTo(y));
        Console.WriteLine("Sorted Integers: " + string.Join(", ", numbers));
    }
}