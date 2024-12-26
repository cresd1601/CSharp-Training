namespace CSharpBasic.Exercise
{
  partial class Exercise
  {
    void Example8()
    {
      double radius, surface, volume;

      Console.WriteLine("\n# Practice 8");

      Console.WriteLine("\nInput Radius values:");
      radius = Convert.ToDouble(Console.ReadLine());
      surface = 4 * Math.PI * (radius * radius);
      volume = (4 * Math.PI * (radius * radius * radius)) / 3;

      Console.WriteLine("\nExpected Output:");
      Console.WriteLine(surface);
      Console.WriteLine(volume);
    }
  }
}
