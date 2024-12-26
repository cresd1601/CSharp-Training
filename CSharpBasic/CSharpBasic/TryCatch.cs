namespace CSharpTrainingSpace
{
  public class TryCatch
  {
    public void Example1()
    {
      // C# try and catch
      try
      {
        int y = Calc(0);
        Console.WriteLine(y);
      }
      catch (DivideByZeroException ex)
      {
        Console.WriteLine("Example 1.1");
        Console.WriteLine("x cannot be zero");
      }

      Console.WriteLine("program completed");

      int Calc(int x) => 10 / x;

    }

    public void Example2()
    {
      try
      {
        int[] myNumbers = { 1, 2, 3 };
        Console.WriteLine("\nExample 2.1");
        Console.WriteLine(myNumbers[10]);
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
      }
    }

    public void Example3()
    {
      // Finally
      try
      {
        int[] myNumbers = { 1, 2, 3 };
        Console.WriteLine("\nExample 3.1");
        Console.WriteLine(myNumbers[10]);
      }
      catch (Exception ex)
      {
        Console.WriteLine("Something went wrong.");
      }
      finally
      {
        Console.WriteLine("The 'try catch' is finished.");
      }
    }

    public void Example4(int age)
    {
      if (age < 18)
      {
        Console.WriteLine("\nExample 4.1");
        throw new ArithmeticException("Access denied - You must be at least 18 years old.");
      }
      else
      {
        Console.WriteLine("Access granted - You are old enough!");
      }
    }
  }
}
