namespace CSharpBasic.LINQ
{
  partial class LINQ 
  {
    void Example3()
    {
      // The Three Parts of a LINQ Query:
      // 1. Data source.
      string[] names = { "Tom", "Dick", "Harry" };

      // 2. Query creation.
      // numQuery is an IEnumerable<int>
      IEnumerable<string> filteredNames = System.Linq.Enumerable.Where
        (names, n => n.Length >= 4);

      // 3. Query execution.
      Console.WriteLine("\nExample 3");
      foreach (string n in filteredNames)
        Console.WriteLine(n);
    }
  }
}
