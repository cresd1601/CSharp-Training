namespace CSharpBasic.Tuples
{
  partial class Tuples
  {
    void Example4()
    {
      Console.WriteLine(
        "Example 4: Tuple equality\n");

      (int a, byte b) left = (5, 10);
      (long a, int b) right = (5, 10);

      Console.WriteLine("(int a, byte b) left = (5, 10);");
      Console.WriteLine("(long a, int b) right = (5, 10);");

      Console.WriteLine($"\nleft == right: {left == right}");
      Console.WriteLine($"left != right: {left != right}");

      var t1 = (A: 5, B: 10);
      var t2 = (B: 5, A: 10);

      Console.WriteLine("\nvar t1 = (A: 5, B: 10);");
      Console.WriteLine("var t2 = (B: 5, A: 10);");

      Console.WriteLine($"\nt1 == t2: {t1 == t2}");
      Console.WriteLine($"t1 != t2: {t1 != t2}");

      Console.ReadKey(true);
    }
  }
}
