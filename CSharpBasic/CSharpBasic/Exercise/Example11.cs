namespace CSharpBasic.Exercise
{
  partial class Exercise
  {
    void Example11()
    {
      int number;

      Console.WriteLine("\n# Practice 11");

      Console.WriteLine("\nNumber to convert (or \"end\"):");
      number = Convert.ToInt16(Console.ReadLine());

      Console.WriteLine("\nExpected Output:");
      Console.WriteLine("Binary: {0}", Convert.ToString(number, 2));
    }
  }
}
