namespace CSharpBasic.LINQ
{
  partial class LINQ 
  {
    void Example6()
    {
      int[] numbers = { 10, 9, 8, 7, 6 };

      IEnumerable<int> firstThree = numbers.Take(3); // { 10, 9, 8 }
      IEnumerable<int> lastTwo = numbers.Skip(3); // { 7, 6 }
      IEnumerable<int> reversed = numbers.Reverse(); // { 6, 7, 8, 9, 10 }

      Console.WriteLine("\nExample 6");

      foreach (int n in firstThree)
        Console.WriteLine(n);

      foreach (int n in lastTwo)
        Console.WriteLine(n);

      foreach (int n in reversed)
        Console.WriteLine(n);
    }
  }
}
