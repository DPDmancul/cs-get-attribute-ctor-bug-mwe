using MyLib;
using MyPackage;
using System.Reflection;
using TestApp;

Test(
    $"Manually call {nameof(MyAttributeAttribute)} new constructor",
    () => new MyAttributeAttribute(12)
);

Test(
    $"Manually call {nameof(MyAttributeAttribute)} old constructor",
    () => new MyAttributeAttribute()
);

Test(
    $"GetAttribute from {nameof(TestAppClass)}",
    () => typeof(TestAppClass).GetCustomAttribute<MyAttributeAttribute>()
);

Test(
    $"GetAttribute from {nameof(MyLibClass)}",
    () => typeof(MyLibClass).GetCustomAttribute<MyAttributeAttribute>()
);

static void Test(string name, Action action)
{
    Console.Write($"Test {name}: ");
    try
    {
        action();
        Console.WriteLine("OK");
    }
    catch (Exception e)
    {
        Console.WriteLine("KO");
        Console.Error.WriteLine(e);
    }
}