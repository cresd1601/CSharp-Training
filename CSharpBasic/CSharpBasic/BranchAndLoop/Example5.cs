namespace CSharpBasic.BranchAndLoop
{
  partial class BranchAndLoop
  {
    void Example5()
    {
      Console.WriteLine("Example 5: Complete challenge\n");

      int sum = 0;

      for (int number = 1; number < 21; number++)
      {
        if (number % 3 == 0)
        {
          sum = sum + number;
        }
      }

      Console.WriteLine($"The sum is {sum}");

      Console.ReadKey(true);
    }
  }
}
