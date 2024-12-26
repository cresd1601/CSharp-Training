namespace CSharpBasic.Exercise
{
  partial class Exercise
  {
    void Example9()
    {
      char symbol;

      Console.WriteLine("\n# Practice 9");

      Console.Write("\nInput a symbol: ");
      symbol = Convert.ToChar(Console.ReadLine());

      Console.WriteLine("\nExpected Output:");

      if ((symbol == 'a') || (symbol == 'e') || (symbol == 'i') ||
          (symbol == 'o') || (symbol == 'u'))
        Console.WriteLine("It's a lowercase vowel.");
      else if ((symbol >= '0') && (symbol <= '9'))
        Console.WriteLine("It's a digit.");
      else
        Console.Write("It's another symbol.");
    }
  }
}
