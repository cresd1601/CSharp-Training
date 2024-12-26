namespace CSharpBasic.Exercise
{
  partial class Exercise
  {
    void Example2()
    {
      int width, number;

      Console.WriteLine("\n# Practice 2");

      Console.WriteLine("\nEnter a number: ");
      number = Convert.ToInt16(Console.ReadLine());

      Console.WriteLine("Enter the desired width: ");
      width = Convert.ToInt16(Console.ReadLine());

      Console.WriteLine("\nResult:");
      for (int index = width; index >= 0; index--)
      {
        string repeatedString = new string((char)(number + '0'), index);
        Console.WriteLine(repeatedString);
      }
    }
  }
}
