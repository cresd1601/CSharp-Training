namespace CSharpBasic.Common
{
  class MainMenu
  {
    public static void Menu(Option[] options)
    {
      Console.Clear();

      // Draw Logo
      DrawLogo();
      DrawMenuDescription("\nPlease choose your options:\n");

      for (var index = 0; index < options.Length; index++)
      {
        DrawMenuItem(options[index].Id, options[index].Title);
      }

      Console.Write("\nAnswer: ");

      string answer = Console.ReadLine();

      Console.Clear();

      Option answerOption = Array.Find(options, element => element.Id == answer);

      answerOption.Callback();
    }

    public static void DrawMenuDescription(string message)
    {
      Console.WriteLine(message);
    }

    public static void DrawMenuItem(string prefix, string message)
    {
      Console.Write("[");
      Console.Write(prefix);
      Console.WriteLine("] " + message);
    }

    public static void DrawLogo()
    {
      string logo = @"___________                           .__               
\_   _____/__  ___ ___________   ____ |__| ______ ____  
 |    __)_\  \/  // __ \_  __ \_/ ___\|  |/  ___// __ \ 
 |        \>    <\  ___/|  | \/\  \___|  |\___ \\  ___/ 
/_______  /__/\_ \\___  >__|    \___  >__/____  >\___  >
        \/      \/    \/            \/        \/     \/ ";
      
      Console.WriteLine(logo);
    }

    public class Option
    {
      public string Id { get; set; }
      public string Title { get; set; }

      public Action Callback { get; set; }

      public Option(string id, string title, Action callback)
      {
        Id = id;
        Title = title;
        Callback = callback;
      }
    }
  }
}
