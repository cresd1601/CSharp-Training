namespace CSharpBasic.Strings
{
  partial class Strings
  {
    void Example4()
    {
      Console.WriteLine("Example 4: Do more with strings");

      string greeting = "      Hello World!       ";
      Console.WriteLine($"\n[{greeting}]");

      string trimmedGreeting = greeting.TrimStart();
      Console.WriteLine($"[{trimmedGreeting}]");

      trimmedGreeting = greeting.TrimEnd();
      Console.WriteLine($"[{trimmedGreeting}]");

      trimmedGreeting = greeting.Trim();
      Console.WriteLine($"[{trimmedGreeting}]");

      string sayHello = "Hello World!";
      Console.WriteLine("\n{0}", sayHello);

      sayHello = sayHello.Replace("Hello", "Greetings");
      Console.WriteLine(sayHello);
      Console.WriteLine(sayHello.ToUpper());
      Console.WriteLine(sayHello.ToLower());

      Console.ReadKey(true);
    }
  }
}
