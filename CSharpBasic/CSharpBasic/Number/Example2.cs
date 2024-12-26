namespace CSharpBasic.Number
{
  partial class Number
  {
    void Example2()
    {
      Console.WriteLine("Example 2: Explore order of operations");

      int a = 5;
      int b = 4;
      int c = 2;
      int d = a + b * c;

      Console.WriteLine("\nExample 2.1");
      Console.WriteLine(d);

      a = 5;
      b = 4;
      c = 2;
      d = (a + b) * c;

      Console.WriteLine("\nExample 2.2");
      Console.WriteLine(d);

      d = (a + b) - 6 * c + (12 * 4) / 3 + 12;

      Console.WriteLine("\nExample 2.3");
      Console.WriteLine(d);

      a = 7;
      b = 4;
      c = 3;
      d = (a + b) / c;

      Console.WriteLine("\nExample 2.4");
      Console.WriteLine(d);
    }
  }
}
