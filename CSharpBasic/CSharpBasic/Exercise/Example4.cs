namespace CSharpBasic.Exercise
{
  partial class Exercise
  {
    void Example4()
    {
      int firstNumber, secondNumber, result;
      string operation;

      Console.WriteLine("\n# Practice 4");

      Console.WriteLine("\nInput first number: ");
      firstNumber = Convert.ToInt16(Console.ReadLine());

      Console.WriteLine("Input operation: ");
      operation = Console.ReadLine();

      Console.WriteLine("Input second number: ");
      secondNumber = Convert.ToInt16(Console.ReadLine());

      switch (operation)
      {
        case "+":
          result = firstNumber + secondNumber;
          break;
        case "-":
          result = firstNumber - secondNumber;
          break;
        case "*":
          result = firstNumber * secondNumber;
          break;
        case "/":
          result = firstNumber / secondNumber;
          break;
        default:
          throw new Exception("invalid logic");
      }

      Console.WriteLine("\nExpected Output:");
      Console.WriteLine("{0} {1} {2} = {3}", firstNumber, operation, secondNumber, result);
    }
  }
}
