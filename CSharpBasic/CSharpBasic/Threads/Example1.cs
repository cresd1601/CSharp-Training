namespace CSharpBasic.Threads
{
  partial class Threads
  {
    void Example1()
    {
      Thread t = new Thread(WriteY); // Kick off a new thread
      t.Start(); // running WriteY()

      // Simultaneously, do something on the main thread.
      for (int i = 0; i < 1000; i++) Console.Write("x");

      void WriteY()
      {
        for (int i = 0; i < 1000; i++) Console.Write("y");
      }
    }
  }
}
