using CSharpBasic.Common;

namespace CSharpBasic.Strings
{
  partial class Strings
  {
    public void Menu()
    {
      MainMenu.Option[] options =
      {
        new("1", "Example 1: Run your first C# program", Example1),
        new("2", "Example 2: Declare and use variables", Example2),
        new("3", "Example 3: Work with strings", Example3),
        new("4", "Example 4: Do more with strings", Example4),
        new("5", "Example 5: Search strings", Example5)
      };

      MainMenu.Menu(options);
    }
  }
}
