namespace CSharpBasic.Delegates
{
  partial class Delegates
  {
    void Example1()
    {
      Console.WriteLine("Example 1: ");

      int Square(int x) => x * x;

      Transformer t = Square; // Create delegate instance
      int result = t(3); // Invoke delegate

      Console.WriteLine("\n{0}", result); // 9

      Console.ReadKey(true);
    }
  }
}
