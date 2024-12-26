namespace CSharpBasic.Number
{
  partial class Number
  {
    void Example4()
    {
      Console.WriteLine("Example 4: Work with the double type");

      double f = 5;
      double g = 4;
      double h = 2;
      double i = (f + g) / h;

      Console.WriteLine("\nExample 4.1");
      Console.WriteLine(i);

      f = 19;
      g = 8;
      h = (f + g) / g;
      Console.WriteLine("\nExample 4.2");
      Console.WriteLine(h);

      double max1 = double.MaxValue;
      double min1 = double.MinValue;
      Console.WriteLine("\nExample 4.3");
      Console.WriteLine($"The range of double is {max1} to {min1}");

      double third = 1.0 / 3.0;
      Console.WriteLine("\nExample 4.4");
      Console.WriteLine(third);
    }
  }
}
