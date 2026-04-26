# Sample 4 — Real-world Scenarios

```bash
dotnet run -c Release
```

Two practical benchmarks that go beyond artificial `Thread.Sleep` examples: one measures the performance characteristics of common .NET collection types across Add, Search, and Delete operations, and another puts SQLite through its paces using Dapper and an in-memory database.

## CollectionBenchmark

Compares `List<T>`, `HashSet<T>`, `Dictionary<TKey, TValue>`, `SortedList<TKey, TValue>`, and `LinkedList<T>` across three categories:

- **Add** — inserting 1,000 items
- **Search** — looking up 100 random values
- **Delete** — removing 50 random values

Each iteration starts from the same pre-populated state so the results are consistent and comparable. Memory allocation is tracked via `[MemoryDiagnoser]`.

## SQLiteBenchmark

Uses an in-memory SQLite database (via `Microsoft.Data.Sqlite`) and `Dapper` to measure the cost of batched inserts, bulk updates, conditional deletes, and a range query against a 10,000-row `Users` table. Realistic fake data is generated with `Bogus`.
