namespace CSharpBasic.Collections
{
  partial class Collections
  {
    void Example2()
    {
      Console.WriteLine("Example 2: Lists of other types");

      var fibonacciNumbers = new List<int> { 1, 1 };

      var previous = fibonacciNumbers[fibonacciNumbers.Count - 1];
      var previous2 = fibonacciNumbers[fibonacciNumbers.Count - 2];

      fibonacciNumbers.Add(previous + previous2);

      Console.WriteLine("\nExample 2.1");

      foreach (var item in fibonacciNumbers)
      {
        Console.WriteLine(item);
      }

      // 5. Complete challenge
      var fibonacciNumbers1 = new List<int> { 1, 1 };

      Console.WriteLine("\nExample 2.2");

      while (fibonacciNumbers1.Count < 20)
      {
        var previous3 = fibonacciNumbers1[fibonacciNumbers1.Count - 1];
        var previous4 = fibonacciNumbers1[fibonacciNumbers1.Count - 2];

        fibonacciNumbers1.Add(previous3 + previous4);
      }
      foreach (var item in fibonacciNumbers1)
      {
        Console.WriteLine(item);
      }

      Console.ReadKey(true);
    }
  }
}
