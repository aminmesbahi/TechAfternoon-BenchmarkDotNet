using BenchmarkDotNet.Attributes;
using Bogus;
using Dapper;
using Microsoft.Data.Sqlite;

[MemoryDiagnoser]
public class SQLiteBenchmark
{
    private const string ConnectionString = "Data Source=:memory:";
    private SqliteConnection _connection;
    private readonly Faker _faker = new Faker();

    [GlobalSetup]
    public void GlobalSetup()
    {
        _connection = new SqliteConnection(ConnectionString);
        _connection.Open();
        SetupDatabase();
        PopulateDatabase();
    }

    [GlobalCleanup]
    public void GlobalCleanup()
    {
        _connection?.Dispose();
    }

    [Benchmark]
    public void InsertRows()
    {
        using var transaction = _connection.BeginTransaction();
        for (int i = 0; i < 10000; i++)
        {
            _connection.Execute("INSERT INTO Users (Name, Age, Email) VALUES (@Name, @Age, @Email)",
                new { Name = _faker.Name.FullName(), Age = _faker.Random.Int(18, 80), Email = _faker.Internet.Email() });
        }
        transaction.Commit();
    }

    [Benchmark]
    public void UpdateRows()
    {
        using var transaction = _connection.BeginTransaction();
        _connection.Execute("UPDATE Users SET Age = Age + 1 WHERE Age < 30");
        transaction.Commit();
    }

    [Benchmark]
    public void DeleteRows()
    {
        using var transaction = _connection.BeginTransaction();
        _connection.Execute("DELETE FROM Users WHERE Age > 70");
        transaction.Commit();
    }

    [Benchmark]
    public void SearchRows()
    {
        _connection.Query("SELECT * FROM Users WHERE Age BETWEEN 20 AND 30");
    }

    private void SetupDatabase()
    {
        _connection.Execute(@"
            CREATE TABLE Users (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Name TEXT,
                Age INTEGER,
                Email TEXT
            )");
    }

    private void PopulateDatabase()
    {
        using var transaction = _connection.BeginTransaction();
        for (int i = 0; i < 10000; i++)
        {
            _connection.Execute("INSERT INTO Users (Name, Age, Email) VALUES (@Name, @Age, @Email)",
                new { Name = _faker.Name.FullName(), Age = _faker.Random.Int(18, 80), Email = _faker.Internet.Email() });
        }
        transaction.Commit();
    }

    public static void Main(string[] args)
    {

    }
}
