namespace CSharpBasic.Number
{
  partial class Number
  {
    void Example3()
    {
      Console.WriteLine("Example 3: Explore integer precision and limits");

      int a = 7;
      int b = 4;
      int c = 3;
      int d = (a + b) / c;
      int e = (a + b) % c;

      Console.WriteLine("\nExample 3.1");
      Console.WriteLine($"quotient: {d}");
      Console.WriteLine($"remainder: {e}");

      int max = int.MaxValue;
      int min = int.MinValue;

      Console.WriteLine("\nExample 3.2");
      Console.WriteLine($"The range of integers is {min} to {max}");

      int what = max + 3;

      Console.WriteLine("\nExample 3.3");
      Console.WriteLine($"An example of overflow: {what}");
    }
  }
}
