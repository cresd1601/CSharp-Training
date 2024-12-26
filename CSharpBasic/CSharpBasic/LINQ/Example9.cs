namespace CSharpBasic.LINQ
{
  partial class LINQ 
  {
    void Example9()
    {
      var numbers = new List<int> { 1 };

      IEnumerable<int> query = numbers.Select(n => n * 10); // Build query

      numbers.Add(2); // Sneak in an extra element

      Console.WriteLine("\nExample 9");

      foreach (int n in query)
        Console.Write(n + "|"); // 10|20|
    }
  }
}
