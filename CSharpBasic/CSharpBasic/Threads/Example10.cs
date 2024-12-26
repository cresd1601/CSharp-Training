namespace CSharpBasic.Threads
{
  partial class Threads
  {
    void Example10()
    {
      // Start a Task that throws a NullReferenceException:
      Task task = Task.Run(() => { throw null; });

      try
      {
        task.Wait();
      }
      catch (AggregateException aex)
      {
        if (aex.InnerException is NullReferenceException)
          Console.WriteLine("Null!");
        else
          throw;
      }
    }
  }
}
