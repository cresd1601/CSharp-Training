namespace CSharpBasic.Tuples
{
  partial class Tuples
  {
    void Example3()
    {
      Console.WriteLine(
        "Example 3: Use existing variables\n");

      var destination = string.Empty;
      var distance = 0.0;

      Console.WriteLine("var destination = string.Empty;");
      Console.WriteLine("var distance = 0.0;");

      var t = ("post office", 3.6);
      (destination, distance) = t;

      Console.WriteLine("\nvar t = (\"post office\", 3.6);");
      Console.WriteLine("(destination, distance) = t;");

      Console.WriteLine($"\nResults: Distance to {destination} is {distance} kilometers.");

      Console.ReadKey(true);
    }
  }
}
