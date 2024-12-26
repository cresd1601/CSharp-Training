using CSharpBasic.Common;

namespace CSharpBasic.Number
{
  partial class Number
  {
    public void Menu()
    {
      MainMenu.Option[] options =
      {
        new("1", "Example 1: Explore integer math", Example1),
        new("2", "Example 2: Explore order of operations", Example2),
        new("3", "Example 3: Explore integer precision and limits", Example3),
        new("4", "Example 4: Work with the double type", Example4),
        new("5", "Example 5: Work with decimal types", Example5),
        new("6", "Example 6: Work with double types", Example6)
      };

      MainMenu.Menu(options);
    }
  }
}

