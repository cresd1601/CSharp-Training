namespace CSharpBasic.LINQ
{
  partial class LINQ 
  {
    void Example10()
    {
      var numbers = new List<int>() { 1, 2 };

      List<int> timesTen = numbers
        .Select(n => n * 10)
        .ToList(); // Executes immediately into a List<int>

      numbers.Clear();

      Console.WriteLine("\n\nExample 10");
      Console.WriteLine(timesTen.Count); // Still 2
    }
  }
}
