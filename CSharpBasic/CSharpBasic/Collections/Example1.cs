using Microsoft.VisualBasic;

namespace CSharpBasic.Collections
{
  partial class Collections
  {
    void Example1()
    {
      Console.WriteLine("Example 1: Create, Update, Search and Sort");

      var names = new List<string> { "<name>", "Ana", "Felipe" };

      Console.WriteLine("\nExample 1.1");

      foreach (var name in names)
      {
        Console.WriteLine($"Hello {name.ToUpper()}!");
      }

      // 2. Modify list contents
      names.Add("Maria");
      names.Add("Bill");
      names.Remove("Ana");

      Console.WriteLine("\nExample 1.2");

      foreach (var name in names)
      {
        Console.WriteLine($"Hello {name.ToUpper()}!");
      }

      Console.WriteLine("\nExample 1.3");
      Console.WriteLine($"My name is {names[0]}.");
      Console.WriteLine($"I've added {names[2]} and {names[3]} to the list.");

      Console.WriteLine("\nExample 1.4");
      Console.WriteLine($"The list has {names.Count} people in it");

      // 3. Search and sort lists
      Console.WriteLine("\nExample 1.5");
      var index = names.IndexOf("Felipe");

      if (index != -1)
      {
        Console.WriteLine($"The name {names[index]} is at index {index}");
      }

      var notFound = names.IndexOf("Not Found");

      Console.WriteLine($"When an item is not found, IndexOf returns {notFound}");

      Console.WriteLine("\nExample 1.6");
      names.Sort();

      foreach (var name in names)
      {
        Console.WriteLine($"Hello {name.ToUpper()}!");
      }

      Console.ReadKey(true);
    }
  }
}
