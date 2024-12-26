namespace CSharpBasic.LINQ
{
  partial class LINQ 
  {
    void Example2()
    {
      // The Three Parts of a LINQ Query:
      // 1. Data source.
      int[] numbers = new int[7] { 0, 1, 2, 3, 4, 5, 6 };

      // 2. Query creation.
      // numQuery is an IEnumerable<int>
      var numQuery =
        from num in numbers
        where (num % 2) == 0
        select num;

      // 3. Query execution.
      Console.WriteLine("\nExample 2");
      foreach (int num in numQuery)
      {
        Console.WriteLine("{0,1} ", num);
      }
    }
  }
}
