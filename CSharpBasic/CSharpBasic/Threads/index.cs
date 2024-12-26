using CSharpBasic.Common;

namespace CSharpBasic.Threads
{
  partial class Threads
  {
    public void Menu()
    {
      MainMenu.Option[] options =
      {
        new("1", "Example 1: ", Example1),
        new("2", "Example 2: ", Example2),
        new("3", "Example 3: ", Example3),
        new("4", "Example 4: ", Example4),
        new("5", "Example 5: ", Example5),
        new("6", "Example 6: ", Example6),
        new("7", "Example 7: ", Example7),
        new("8", "Example 8: ", Example8),
        new("9", "Example 9: ", Example9),
        new("10", "Example 10: ", Example10),
        new("11", "Example 11: ", Example11),
        new("12", "Example 12: ", Example12),
      };

      MainMenu.Menu(options);
    }
  }
}
