namespace CSharpBasic.BranchAndLoop
{
  partial class BranchAndLoop
  {
    void Example2()
    {
      Console.WriteLine("Example 2: Use loops to repeat operations\n");

      int counter = 0;

      while (counter < 10)
      {
        Console.WriteLine($"Hello World! The counter is {counter}");
        counter++;
      }

      counter = 0;

      Console.WriteLine("\nExample 2.2");

      do
      {
        Console.WriteLine($"Hello World! The counter is {counter}");
        counter++;
      } 
      while (counter < 10);

      Console.ReadKey(true);
    }
  }
}
