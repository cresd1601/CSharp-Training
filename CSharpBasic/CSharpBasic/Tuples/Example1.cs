namespace CSharpBasic.Tuples
{
  partial class Tuples
  {
    void Example1()
    {
      Console.WriteLine("Example 1: Changing value of 2nd element");

      var rollNum = (5, 7, 8, 3);

      // original tuple
      Console.WriteLine("\nOriginal Tuple: " + rollNum);

      // replacing the value 7 with 6
      rollNum.Item2 = 6;
      Console.WriteLine("Changing value of 2nd element to " + rollNum.Item2);

      Console.WriteLine("\nModified Tuple: " + rollNum);

      Console.ReadKey(true);
    }
  }
}
