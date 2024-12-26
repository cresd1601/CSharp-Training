namespace CSharpBasic.LINQ
{
  partial class LINQ 
  {
    void Example13()
    {
      string[] musos =
        { "David Gilmour", "Roger Waters", "Rick Wright", "Nick Mason" };

      IEnumerable<string> query = musos.OrderBy(m => m.Split().Last());

      Console.WriteLine("\n\nExample 13");

      foreach (string name in query)
        Console.WriteLine(name);
    }
  }
}
