namespace CSharpBasic.BranchAndLoop
{
  partial class BranchAndLoop
  {
    void Example4()
    {
      Console.WriteLine("Example 4: Created nested loops\n");

      for (int row = 1; row < 11; row++)
      {
        Console.WriteLine($"The row is {row}");
      }

      Console.WriteLine("\nExample 4.2");

      for (char column = 'a'; column < 'k'; column++)
      {
        Console.WriteLine($"The column is {column}");
      }

      Console.WriteLine("\nExample 4.3");

      for (int row = 1; row < 11; row++)
      {
        for (char column = 'a'; column < 'k'; column++)
        {
          Console.WriteLine($"The cell is ({row}, {column})");
        }
      }

      Console.ReadKey(true);
    }
  }
}
