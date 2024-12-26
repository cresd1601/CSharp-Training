namespace CSharpBasic.Exercise
{
  partial class Exercise
  {
    void Example1()
    {
      char letter, letter1, letter2;

      Console.WriteLine("Practice 1: Render Inputted");

      Console.Write("\nInput letter: ");
      letter = Convert.ToChar(Console.ReadLine());

      Console.Write("Input letter: ");
      letter1 = Convert.ToChar(Console.ReadLine());

      Console.Write("Input letter: ");
      letter2 = Convert.ToChar(Console.ReadLine());

      Console.WriteLine("\nResult:");
      Console.WriteLine("{0} {1} {2}", letter2, letter1, letter);
    }
  }
}
