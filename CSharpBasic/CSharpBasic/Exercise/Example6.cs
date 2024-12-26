namespace CSharpBasic.Exercise
{
  partial class Exercise
  {
    void Example6()
    {
      int number, result;

      static bool BetweenRanges(int a, int b, int number)
      {
        return (a <= number && number <= b);
      }

      Console.WriteLine("\n# Practice 6");

      do
      {
        Console.WriteLine("\nInput Y values:");
        number = Convert.ToInt16(Console.ReadLine());
        result = (number * number) + (2 * number) + 1;

        if (BetweenRanges(-5, 5, number))
        {
          Console.WriteLine("\nExpected Output:");
          Console.WriteLine("Values of the function x = y2 + 2y + 1: {0}", result);
        }
      } while (!BetweenRanges(-5, 5, number));
      {
        Console.Write("\nMessage: Invalid input values!");
      }
    }
  }
}
