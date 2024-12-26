namespace CSharpBasic.Strings
{
  partial class Strings
  {
    void Example5()
    {
      Console.WriteLine("Example 5: Search strings");

      string songLyrics = "You say goodbye, and I say hello";

      Console.WriteLine("\nstring songLyrics = \"You say goodbye, and I say hello\"");

      Console.WriteLine("\nConsole.WriteLine(songLyrics.Contains(\"goodbye\")): " + songLyrics.Contains("goodbye"));
      Console.WriteLine("Console.WriteLine(songLyrics.Contains(\"greetings\")): " + songLyrics.Contains("greetings"));

      Console.WriteLine("\nConsole.WriteLine(songLyrics.StartsWith(\"You\")): " + songLyrics.StartsWith("You"));
      Console.WriteLine("Console.WriteLine(songLyrics.StartsWith(\"goodbye\")): " + songLyrics.StartsWith("goodbye"));

      Console.WriteLine("\nConsole.WriteLine(songLyrics.EndsWith(\"hello\")): " + songLyrics.EndsWith("hello"));
      Console.WriteLine("Console.WriteLine(songLyrics.EndsWith(\"goodbye\")): " + songLyrics.EndsWith("goodbye"));

      Console.ReadKey(true);
    }
  }
}
