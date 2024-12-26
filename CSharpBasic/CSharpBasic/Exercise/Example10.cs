namespace CSharpBasic.Exercise
{
  partial class Exercise
  {
    void Example10()
    {
      int numberX, numberY;

      Console.WriteLine("\n# Practice 10");

      Console.WriteLine("\nInput X values:");
      numberX = Convert.ToInt16(Console.ReadLine());
      Console.WriteLine("Input Y values:");
      numberY = Convert.ToInt16(Console.ReadLine());

      Console.WriteLine("\nExpected Output:");

      if (((numberX + numberY) % 2) == 0)
      {
        Console.WriteLine("Number is even");
      }
      else
      {
        Console.WriteLine("Number is odd");
      }
    }
  }
}
