namespace CSharpBasic.Exercise
{
  partial class Exercise
  {
    void Example3()
    {
      string inputUser, inputPass;
      string confirmUser = "admin", confirmPass = "123456";
      int count = 1;

      Console.WriteLine("# Practice 3");

      do
      {
        Console.Write("\nEnter username: ");
        inputUser = Console.ReadLine();

        Console.Write("Enter password: ");
        inputPass = Console.ReadLine();

        if (inputUser == confirmUser && inputPass == confirmPass)
        {
          Console.Write("\nMessage: {0} logged in", inputUser);
          break;
        }

        count++;
      } while (count <= 3);
      {
        if (inputUser != confirmUser && inputPass != confirmPass)
        {
          Console.Write("\nMessage: Login attempt fail!");
        }
      }
    }
  }
}
