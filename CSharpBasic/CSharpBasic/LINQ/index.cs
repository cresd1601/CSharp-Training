using CSharpBasic.Common;

namespace CSharpBasic.LINQ
{
  partial class LINQ
  {
    public void Menu()
    {
      MainMenu.Option[] options =
      {
        new("1", "Practice 1: ", Example1),
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
        new("13", "Example 13: ", Example13),
        new("14", "Example 14: ", Example14),
        new("15", "Example 15: ", Example15),
        new("16", "Example 16: ", Example16),
        new("17", "Example 17: ", Example17),
        new("18", "Example 18: ", Example18),
        new("19", "Example 19: ", Example19),
        new("20", "Example 20: ", Example20),
        new("21", "Example 21: ", Example21),
        new("22", "Example 22: ", Example22),
        new("23", "Example 23: ", Example23),
        new("24", "Example 24: ", Example24),
        new("25", "Example 25: ", Example25),
        new("26", "Example 26: ", Example26),

      };

      MainMenu.Menu(options);
    }
  }
}

