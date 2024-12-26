namespace CSharpBasic.LINQ
{
  partial class LINQ
  {
    void Example1()
    {
      // Specify the data source.
      int[] scores = { 97, 92, 81, 60 };

      // Define the query expression.
      IEnumerable<int> scoreQuery =
        from score in scores
        where score > 80
        select score;

      // Execute the query.
      Console.WriteLine("Example 1");
      foreach (int i in scoreQuery)
      {
        Console.WriteLine(i + " ");
      }
      // Output: 97 92 81
    }
  }
}
