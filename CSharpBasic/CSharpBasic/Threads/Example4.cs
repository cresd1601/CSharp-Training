namespace CSharpBasic.Threads
{
  partial class Threads
  {
    void Example4()
    {
      bool _done = false;

      new Thread(Go).Start();

      Go();
      void Go()
      {
        if (!_done) { _done = true; Console.WriteLine("Done"); }
      }
    }
  }
}
