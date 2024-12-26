namespace CSharpBasic.Number
{
  partial class Number
  {
    void Example5()
    {
      Console.WriteLine("Example 5: Work with decimal types");

      decimal min2 = decimal.MinValue;
      decimal max2 = decimal.MaxValue;

      Console.WriteLine("\nExample 5.1");
      Console.WriteLine($"The range of the decimal type is {min2} to {max2}");

      double a1 = 1.0;
      double b1 = 3.0;

      Console.WriteLine("\nExample 5.2");
      Console.WriteLine(a1 / b1);

      decimal c1 = 1.0M;
      decimal d1 = 3.0M;

      Console.WriteLine("\nExample 5.3");
      Console.WriteLine(c1 / d1);
    }
  }
}
