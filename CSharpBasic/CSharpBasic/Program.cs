using CSharpBasic.Common;
using CSharpBasic.Tuples;
using CSharpBasic.Strings;
using CSharpBasic.Number;
using CSharpBasic.Collections;
using CSharpBasic.BranchAndLoop;
using CSharpBasic.Delegates;
using CSharpBasic.Exercise;
using CSharpBasic.LINQ;
using CSharpBasic.Threads;

namespace CSharpTrainingSpace
{
  class Program
  {
    static void Main()
    {
      MainMenu.DrawLogo();
      MainMenu.DrawMenuDescription("\nWelcome Back Batman!\n");

      Console.ReadKey(true);

      MainMenu.Option[] options = {
        new ("1", "String", () =>
        {
          Strings stringsEx = new Strings();
          stringsEx.Menu();
        }),
        new ("2", "Number", () =>
        {
          Number numberEx = new Number();
          numberEx.Menu();
        }),
        new ("3", "Tuple", () =>
        {
          Tuples tuplesEx = new Tuples();
          tuplesEx.Menu();
        }),
        new ("4", "Collections", () =>
        {
          Collections collectionsEx = new Collections();
          collectionsEx.Menu();
        }),
        new ("5", "Branch And Loop", () =>
        {
          BranchAndLoop branchAndLoopEx = new BranchAndLoop();
          branchAndLoopEx.Menu();
        }),
        new ("6", "Delegates", () =>
        {
          Delegates delegates = new Delegates();
          delegates.Menu();
        }),
        new ("7", "LINQ", () =>
        {
          LINQ LINQex = new LINQ();
          LINQex.Menu();
        }),
        new ("8", "Threads", () =>
        {
          Threads ThreadsEx = new Threads();
          ThreadsEx.Menu();
        }),
        new ("9", "Exercise #1", () =>
        {
          Exercise exercise = new Exercise();
          exercise.Menu();
        }),
        new ("10", "Quit", () =>
        {
          Environment.Exit(0);
        })
      };

      MainMenu.Menu(options);
    }
  }
}
