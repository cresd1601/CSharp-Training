namespace CSharpBasic.LINQ
{
  partial class LINQ 
  {
    void Example11()
    {
      int[] numbers = { 1, 2 };
      int factor = 10;

      IEnumerable<int> query = numbers.Select(n => n * factor);

      factor = 20;

      Console.WriteLine("\nExample 11");

      foreach (int n in query) Console.Write(n + "|"); // 20|40|
    }
  }
}
