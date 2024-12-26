namespace CSharpBasic.Exercise
{
  partial class Exercise
  {
    void Example5()
    {
      double number, result;

      Console.WriteLine("\n# Practice 5");

      Console.WriteLine("\nInput the radius of the circle:");
      number = Convert.ToInt16(Console.ReadLine());
      result = (number * 2) * Math.PI;

      Console.WriteLine("Expected Output:");
      Console.WriteLine("Perimeter of Circle: {0}", result);
    }
  }
}
