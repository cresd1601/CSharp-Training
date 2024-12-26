using CSharpBasic.Common;

namespace CSharpBasic.BranchAndLoop
{
  partial class BranchAndLoop
  {
    public void Menu()
    {
      MainMenu.Option[] options =
      {
        new("1", "Example 1: Make if and else work together", Example1),
        new("2", "Example 2: Use loops to repeat operations", Example2),
        new("3", "Example 3: Work with the for loop", Example3),
        new("4", "Example 4: Created nested loops", Example4),
        new("5", "Example 5: Complete challenge", Example5)
      };

      MainMenu.Menu(options);
    }
  }
}

