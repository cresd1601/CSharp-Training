namespace CSharpBasic.LINQ
{
  partial class LINQ 
  {
    void Example8()
    {
      string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };

      IEnumerable<string> query =
        from n in names
        where n.Contains("a") // Filter elements
        orderby n.Length // Sort elements
        select n.ToUpper(); // Translate each element (project)

      Console.WriteLine("\nExample 8");

      foreach (string name in query) Console.WriteLine(name);
    }
  }
}
