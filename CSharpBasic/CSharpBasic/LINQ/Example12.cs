namespace CSharpBasic.LINQ
{
  partial class LINQ 
  {
    void Example12()
    {
      IEnumerable<char> query = "Not what you might expect";

      query = query.Where(c => c != 'a');
      query = query.Where(c => c != 'e');
      query = query.Where(c => c != 'i');
      query = query.Where(c => c != 'o');
      query = query.Where(c => c != 'u');

      Console.WriteLine("\n\nExample 12");

      foreach (char c in query) Console.Write(c); // Nt wht y mght xpct
    }
  }
}
