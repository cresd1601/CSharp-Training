namespace CSharpBasic.LINQ
{
  partial class LINQ 
  {
    void Example7()
    {
      int[] numbers = { 10, 9, 8, 7, 6 };

      int firstNumber = numbers.First(); // 10
      int lastNumber = numbers.Last(); // 6
      int secondNumber = numbers.ElementAt(1); // 9
      int secondLowest = numbers.OrderBy(n => n).Skip(1).First(); // 7

      Console.WriteLine("\nExample 7");

      Console.WriteLine(firstNumber);
      Console.WriteLine(lastNumber);
      Console.WriteLine(secondNumber);
      Console.WriteLine(secondLowest);

      Console.Write("\n");

      int count = numbers.Count(); // 5;
      int min = numbers.Min(); // 6;

      bool hasTheNumberNine = numbers.Contains(9); // true
      bool hasMoreThanZeroElements = numbers.Any(); // true
      bool hasAnOddElement = numbers.Any(n => n % 2 != 0); // true

      Console.WriteLine(hasTheNumberNine);
      Console.WriteLine(hasMoreThanZeroElements);
      Console.WriteLine(hasAnOddElement);

      Console.Write("\n");

      int[] seq1 = { 1, 2, 3 };
      int[] seq2 = { 3, 4, 5 };

      IEnumerable<int> concat = seq1.Concat(seq2); // { 1, 2, 3, 3, 4, 5 }
      IEnumerable<int> union = seq1.Union(seq2); // { 1, 2, 3, 4, 5 }

      foreach (int n in concat)
        Console.WriteLine(n);

      Console.Write("\n");

      foreach (int n in union)
        Console.WriteLine(n);
    }
  }
}
