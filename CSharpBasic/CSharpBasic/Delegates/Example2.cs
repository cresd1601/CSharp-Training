namespace CSharpBasic.Delegates
{
  partial class Delegates
  { 
    void Transform(int[] values, Transformer t)
    {
      for (int i = 0; i < values.Length; i++)
        values[i] = t(values[i]);
    }

    void Example2()
    {
      Console.WriteLine("Example 2: \n");

      int[] values = { 1, 2, 3 };
      int Square(int x) => x * x;

      Transform(values, Square); // Hook in the Square method

      foreach (int i in values)
        Console.Write(i + " "); // 1 4 9

      Console.ReadKey(true);
    }
  }
}
