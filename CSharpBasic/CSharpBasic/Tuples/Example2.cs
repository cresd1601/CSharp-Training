namespace CSharpBasic.Tuples
{
  partial class Tuples
  {
    void Example2()
    {
      Console.WriteLine(
        "Example 2: Declare some types explicitly and other types implicitly (with var) inside the parentheses");

      var t = ("post office", 3.6);
      (var destination, double distance) = t;

      Console.WriteLine("\nvar t = (\"post office\", 3.6);");
      Console.WriteLine("(var destination, double distance) = t;");

      Console.WriteLine($"\nResults: Distance to {destination} is {distance} kilometers.");

      Console.ReadKey(true);
    }
  }
}
