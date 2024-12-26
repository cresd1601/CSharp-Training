namespace CSharpBasic.Threads
{
  partial class Threads
  {
    void Example5()
    {
      try
      {
        new Thread(Go).Start();
      }
      catch (Exception ex)
      {
        // We'll never get here!
        Console.WriteLine("Exception!");
      }
      void Go() { throw null; } // Throws a NullReferenceException
    }
  }
}
