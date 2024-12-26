using CSharpBasic.Common;

namespace CSharpBasic.Delegates
{
  partial class Delegates
  {
    delegate int Transformer(int x); // Delegate type declaration

    public void Menu()
    {
      MainMenu.Option[] options =
      {
        new("1", "Example 1: Create and invoke delegates", Example1),
        new("2", "Example 2: Pass delegate to function", Example2),
      };

      MainMenu.Menu(options);
    }
  }
}
