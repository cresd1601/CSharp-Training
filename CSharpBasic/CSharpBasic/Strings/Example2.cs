namespace CSharpBasic.Strings
{
  partial class Strings
  {
    void Example2()
    {
      Console.WriteLine("Example 2: Declare and use variables");

      string aFriend = "Bill";
      Console.WriteLine("\nstring aFriend = \"Bill\"");
      Console.WriteLine("Console.WriteLine(\"Result: \" + aFriend);");
      Console.WriteLine("Result: " + aFriend);

      aFriend = "Maira";
      Console.WriteLine("\naFriend = \"Maira\"");
      Console.WriteLine("Console.WriteLine(\"Result: {0}\", aFriend);");
      Console.WriteLine("Result: {0}", aFriend);

      aFriend = "Quy";
      Console.WriteLine("\naFriend = \"Quy\"");
      Console.WriteLine("Console.WriteLine($\"Result: Hello {aFriend}\");");
      Console.WriteLine($"Result: Hello {aFriend}");

      Console.ReadKey(true);
    }
  }
}
