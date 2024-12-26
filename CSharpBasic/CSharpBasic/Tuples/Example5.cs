namespace CSharpBasic.Tuples
{
  partial class Tuples
  {
    void Example5()
    {
      Console.WriteLine("Example 5: Explicitly specify the name of a field or access a field by its default name");

      var a = 1;
      var t = (a, b: 2, 3);

      Console.WriteLine("\nvar a = 1;");
      Console.WriteLine("var t = (a, b: 2, 3);");

      Console.WriteLine("\nThe 1st element is {t.Item1} (same as {t.a}).");
      Console.WriteLine("The 2nd element is {t.Item2} (same as {t.b}).");
      Console.WriteLine("The 3rd element is {t.Item3}.");

      Console.WriteLine($"\nThe 1st element is {t.Item1} (same as {t.a}).");
      Console.WriteLine($"The 2nd element is {t.Item2} (same as {t.b}).");
      Console.WriteLine($"The 3rd element is {t.Item3}.");

      Console.ReadKey(true);
    }
  }
}
