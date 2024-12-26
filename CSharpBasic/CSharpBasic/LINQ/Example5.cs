namespace CSharpBasic.LINQ
{
  partial class LINQ 
  {
    void Example5()
    {
      string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };

      IEnumerable<int> query = names.Select(n => n.Length);

      Console.WriteLine("\nExample 5");

      foreach (int length in query)
        Console.WriteLine(length + "|"); // 3|4|5|4|3|
    }
  }
}
