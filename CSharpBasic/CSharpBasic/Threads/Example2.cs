namespace CSharpBasic.Threads
{
  partial class Threads
  {
    void Example2()
    {
      Thread t = new Thread(Go);
      t.Start();
      t.Join();

      Console.WriteLine("\nThread t has ended!");
      void Go() { for (int i = 0; i < 1000; i++) Console.Write("y"); }
    }
  }
}
