namespace CSharpBasic.Strings
{
  partial class Strings
  {
    void Example3()
    {
      Console.WriteLine("Example 3: Work with strings");

      string firstFriend = "Maria";
      string secondFriend = "Sage";

      Console.WriteLine("\nstring firstFriend = \"Maria\";");
      Console.WriteLine("string secondFriend = \"Sage\";");

      Console.WriteLine($"\nMy friends are {firstFriend} and {secondFriend}");

      Console.WriteLine($"\nThe name {firstFriend} has {firstFriend.Length} letters.");
      Console.WriteLine($"The name {secondFriend} has {secondFriend.Length} letters.");

      Console.ReadKey(true);
    }
  }
}
