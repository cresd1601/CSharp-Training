namespace CSharpBasic.Threads
{
  partial class Threads
  {
    void Example7()
    {
      Task task = Task.Run(() =>
      {
        Thread.Sleep(2000);
        Console.WriteLine("Foo");
      });

      Console.WriteLine(task.IsCompleted); // False

      task.Wait(); // Blocks until task is completed }
    }
  }
}
