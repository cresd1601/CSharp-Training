namespace CSharpBasic.LINQ
{
  partial class LINQ 
  {
    void Example4()
    {
      string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };

      IEnumerable<string> query = names
        .Where(n => n.Contains("a"))
        .OrderBy(n => n.Length)
        .Select(n => n.ToUpper());

      Console.WriteLine("\nExample 4");

      foreach (string name in query)
        Console.WriteLine(name);
    }
  }
}
