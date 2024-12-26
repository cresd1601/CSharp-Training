using CSharpBasic.Common;

namespace CSharpBasic.Tuples
{
  partial class Tuples
  {
    public void Menu()
    {
      MainMenu.Option[] options =
      {
        new("1", "Example 1: Changing value of 2nd element", Example1),
        new("2", "Example 2: Declare some types explicitly and other types implicitly (with var) inside the parentheses", Example2),
        new("3", "Example 3: Use existing variables", Example3),
        new("4", "Example 4: Tuple equality", Example4),
        new("5", "Example 5: Explicitly specify the name of a field or access a field by its default name", Example5)
      };

      MainMenu.Menu(options);
    }
  }
}
