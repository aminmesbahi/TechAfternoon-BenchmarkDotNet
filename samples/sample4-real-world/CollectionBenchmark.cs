using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[CategoriesColumn]
public class CollectionBenchmark
{
    private const int NumberOfItemsToAdd = 1000;
    private const int NumberOfItemsToSearch = 100;
    private const int NumberOfItemsToDelete = 50;
    private List<int> list = null!;
    private HashSet<int> hashSet = null!;
    private Dictionary<int, int> dictionary = null!;
    private SortedList<int, int> sortedList = null!;
    private LinkedList<int> linkedList = null!;
    private Random random = null!;
    private int[] searchItems = null!;
    private int[] deleteItems = null!;

    [GlobalSetup]
    public void Setup()
    {
        random = new Random();
        searchItems = Enumerable.Range(1, NumberOfItemsToSearch).Select(_ => random.Next(NumberOfItemsToAdd)).ToArray();
        deleteItems = Enumerable.Range(1, NumberOfItemsToDelete).Select(_ => random.Next(NumberOfItemsToAdd)).ToArray();
        ResetCollections();
    }

    // Resets all collections to a consistent pre-populated state before each iteration,
    // so Add/Search/Delete benchmarks always operate on the same data.
    [IterationSetup]
    public void ResetCollections()
    {
        list = new List<int>(NumberOfItemsToAdd);
        hashSet = new HashSet<int>(NumberOfItemsToAdd);
        dictionary = new Dictionary<int, int>(NumberOfItemsToAdd);
        sortedList = new SortedList<int, int>(NumberOfItemsToAdd);
        linkedList = new LinkedList<int>();
        for (int i = 0; i < NumberOfItemsToAdd; i++)
        {
            list.Add(i);
            hashSet.Add(i);
            dictionary.Add(i, i);
            sortedList.Add(i, i);
            linkedList.AddLast(i);
        }
    }

    [Benchmark(Baseline = true), BenchmarkCategory("Add")]
    public void List_Add()
    {
        for (int i = 0; i < NumberOfItemsToAdd; i++)
            list.Add(i);
    }

    [Benchmark, BenchmarkCategory("Add")]
    public void HashSet_Add()
    {
        for (int i = 0; i < NumberOfItemsToAdd; i++)
            hashSet.Add(i);
    }

    [Benchmark, BenchmarkCategory("Add")]
    public void Dictionary_Add()
    {
        for (int i = 0; i < NumberOfItemsToAdd; i++)
            dictionary.Add(i, i);
    }

    [Benchmark, BenchmarkCategory("Add")]
    public void SortedList_Add()
    {
        for (int i = 0; i < NumberOfItemsToAdd; i++)
            sortedList.Add(i, i);
    }

    [Benchmark, BenchmarkCategory("Add")]
    public void LinkedList_Add()
    {
        for (int i = 0; i < NumberOfItemsToAdd; i++)
            linkedList.AddLast(i);
    }

    [Benchmark, BenchmarkCategory("Search")]
    public void List_Search()
    {
        foreach (var item in searchItems)
            list.Contains(item);
    }

    [Benchmark, BenchmarkCategory("Search")]
    public void HashSet_Search()
    {
        foreach (var item in searchItems)
            hashSet.Contains(item);
    }

    [Benchmark, BenchmarkCategory("Search")]
    public void Dictionary_Search()
    {
        foreach (var item in searchItems)
            dictionary.ContainsKey(item);
    }

    [Benchmark, BenchmarkCategory("Search")]
    public void SortedList_Search()
    {
        foreach (var item in searchItems)
            sortedList.ContainsKey(item);
    }

    [Benchmark, BenchmarkCategory("Search")]
    public void LinkedList_Search()
    {
        foreach (var item in searchItems)
            linkedList.Contains(item);
    }

    [Benchmark, BenchmarkCategory("Delete")]
    public void List_Delete()
    {
        foreach (var item in deleteItems)
            list.Remove(item);
    }

    [Benchmark, BenchmarkCategory("Delete")]
    public void HashSet_Delete()
    {
        foreach (var item in deleteItems)
            hashSet.Remove(item);
    }

    [Benchmark, BenchmarkCategory("Delete")]
    public void Dictionary_Delete()
    {
        foreach (var item in deleteItems)
            dictionary.Remove(item);
    }

    [Benchmark, BenchmarkCategory("Delete")]
    public void SortedList_Delete()
    {
        foreach (var item in deleteItems)
            sortedList.Remove(item);
    }

    [Benchmark, BenchmarkCategory("Delete")]
    public void LinkedList_Delete()
    {
        foreach (var item in deleteItems)
            linkedList.Remove(item);
    }


}
