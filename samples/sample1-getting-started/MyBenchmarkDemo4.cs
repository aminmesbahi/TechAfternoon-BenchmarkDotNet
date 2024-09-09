using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using System.Reflection;

[DryJob]
[CategoriesColumn]
[CustomCategoryDiscoverer]
public class MyBenchmarkDemo4
{
    private class CustomCategoryDiscoverer : DefaultCategoryDiscoverer
    {
        // The category discovery strategy can be overridden using an instance of ICategoryDiscoverer
        public override string[] GetCategories(MethodInfo method)
        {
            var categories = new List<string>();
            categories.AddRange(base.GetCategories(method));
            categories.Add("All");
            categories.Add(method.Name.Substring(0, 1));
            return categories.ToArray();
        }
    }

    [AttributeUsage(AttributeTargets.Class)]
    private class CustomCategoryDiscovererAttribute : Attribute, IConfigSource
    {
        public CustomCategoryDiscovererAttribute()
        {
            Config = ManualConfig.CreateEmpty()
                .WithCategoryDiscoverer(new CustomCategoryDiscoverer());
        }

        public IConfig Config { get; }
    }


    [Benchmark]
    public void Foo() { }

    [Benchmark]
    public void Bar() { }
}