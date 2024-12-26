namespace CSharpBasic.BranchAndLoop
{
  partial class BranchAndLoop
  {
    void Example1()
    {
      Console.WriteLine("Example 1: Make if and else work together");

      int a = 5;
      int b = 3;
      int c = 4;

      if ((a + b + c > 10) && (a == b))
      {
        Console.WriteLine("\nThe answer is greater than 10");
        Console.WriteLine("And the first number is equal to the second");
      }
      else
      {
        Console.WriteLine("\nThe answer is not greater than 10");
        Console.WriteLine("Or the first number is not equal to the second");
      }

      a = 5;
      b = 3;
      c = 4;

      if ((a + b + c > 10) || (a == b))
      {
        Console.WriteLine("\nThe answer is greater than 10");
        Console.WriteLine("Or the first number is equal to the second");
      }
      else
      {
        Console.WriteLine("\nThe answer is not greater than 10");
        Console.WriteLine("And the first number is not equal to the second");
      }

      Console.ReadKey(true);
    }
  }
}
