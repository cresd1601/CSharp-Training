using CSharpBasic.Common;

namespace CSharpBasic.Collections
{
  partial class Collections
  {
    public void Menu()
    {
      MainMenu.Option[] options =
      {
        new("1", "Example 1: Create, Update, Search and Sort", Example1),
        new("2", "Example 2: Lists of other types", Example2),
      };

      MainMenu.Menu(options);
    }
  }
}
