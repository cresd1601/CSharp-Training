namespace CSharpBasic
{
  internal class Exercise3
  {
    public void Example1()
    {
      Console.WriteLine("# Practice 1");

      // The Three Parts of a LINQ Query:
      // 1. Data source.
      int[] demoArray = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

      // 2. Query creation.
      // numQuery is an IEnumerable<int>
      var numQuery =
          from num in demoArray
          where (num % 2) == 0
          select num;

      // 3. Query execution.
      Console.WriteLine("\nExpected Output:");
      foreach (int item in numQuery)
      {
        Console.Write("{0,1} ", item);
      }
    }

    public void Example2()
    {
      Console.WriteLine("\n\n# Practice 2");

      int[] demoArray =
      {
                1, 3, -2, -4, -7, -3, -8, 12, 19, 6, 9, 10, 14
            };

      var numQuery =
          from num in demoArray
          where num > 0
          where num < 12
          select num;

      Console.Write("\nExpected Output:");
      Console.Write("\nThe numbers within the range of 1 to 11 are : \n");
      foreach (int item in numQuery)
      {
        Console.Write("{0} ", item);
      }
    }

    public void Example3()
    {
      int[] demoArray = { 9, 8, 6, 5 };

      Console.WriteLine("\n\n# Practice 3");

      var numQuery =
          from Number in demoArray
          let SqrNo = Number * Number
          select new { Number, SqrNo };

      Console.Write("\nExpected Output:\n");
      foreach (var item in numQuery)
      {
        Console.WriteLine("{0}", item);
      }
    }

    public void Example4()
    {
      int[] demoArray = { 5, 9, 1, 2, 3, 7, 5, 6, 7, 3, 7, 6, 8, 5, 4, 9, 6, 2 };

      Console.WriteLine("\n# Practice 4");

      var numQuery =
          from x in demoArray
          group x by x
          into y
          select y;

      Console.Write("\nExpected Output:\n");
      foreach (var item in numQuery)
      {
        Console.WriteLine("Number " + item.Key + " appears " + item.Count() + " times");
      }
    }

    public void Example5()
    {
      string inputString;

      Console.WriteLine("\n# Practice 5");

      Console.Write("\nInput the string: ");
      inputString = Console.ReadLine();

      var stringQuery =
          from x in inputString
          group x by x
          into y
          select y;

      Console.Write("\nExpected Output:\n");
      Console.Write("The frequency of the characters are :\n");
      foreach (var item in stringQuery)
      {
        Console.WriteLine("Character " + item.Key + ": " + item.Count() + " times");
      }
    }

    public void Example6()
    {
      string[] dayWeeks = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

      Console.WriteLine("\n# Practice 6");

      var days =
          from WeekDay in dayWeeks
          select WeekDay;

      Console.Write("\nExpected Output:\n");
      foreach (var item in days)
      {
        Console.WriteLine("{0}", item);
      }
    }

    public void Example7()
    {
      int[] demoArray = { 5, 1, 9, 2, 3, 7, 4, 5, 6, 8, 7, 6, 3, 4, 5, 2 };

      Console.WriteLine("\n# Practice 7");

      var numQuery =
          from x in demoArray
          group x by x
          into y
          select y;

      Console.Write("\nExpected Output:");
      Console.Write("\nNumber | Number * Frequency | Frequency");
      Console.Write("\n---------------------------------------\n");


      foreach (var item in numQuery)
      {
        Console.WriteLine("   {0}  |         {1}         |    {2}", string.Format("{0:D2}", item.Key),
            string.Format("{0:D2}", item.Key * item.Count()), string.Format("{0:D2}", item.Count()));
      }
    }

    public void Example8()
    {
      char startingCharacter, endingCharacter;
      string[] cities =
          { "ROME", "LONDON", "NAIROBI", "CALIFORNIA", "ZURICH", "NEW DELHI", "AMSTERDAM", "ABU DHABI", "PARIS" };

      Console.WriteLine(
          "\nThe cities are: 'ROME','LONDON','NAIROBI','CALIFORNIA','ZURICH','NEW DELHI','AMSTERDAM','ABU DHABI','PARIS'\n");
      Console.Write("Input starting character for the string : ");
      startingCharacter = (char)Console.ReadLine()[0];
      Console.Write("Input ending character for the string : ");
      endingCharacter = (char)Console.ReadLine()[0];


      var results =
          from x in cities
          where x.StartsWith(startingCharacter)
          where x.EndsWith(endingCharacter)
          select x;

      Console.Write("\nExpected Output:");
      foreach (var item in results)
      {
        Console.Write("\nThe city starting with {0} and ending with {1} is : {2}", startingCharacter,
            endingCharacter, item);
      }
    }

    public void Example9()
    {
      int[] demoArray = { 55, 200, 740, 76, 230, 482, 95 };

      Console.WriteLine("\n# Practice 9");

      var resultArray =
          from x in demoArray
          where x > 80
          select x;

      Console.WriteLine("\nThe members of the list are : ");
      foreach (var item in demoArray)
      {
        Console.Write(item + " ");
      }

      Console.WriteLine("\n\nExpected Output:");
      Console.WriteLine("\nThe numbers greater than 80 are : ");
      foreach (var item in resultArray)
      {
        Console.Write(item + " ");
      }

    }

    public void Example10()
    {
      int lengthOfList, inputGreaterThan;
      List<int> inputList = new List<int>();


      Console.WriteLine("\n# Practice 10");

      Console.Write("\nInput the number of members on the List : ");
      lengthOfList = Convert.ToInt16(Console.ReadLine());


      for (int index = 0; index < lengthOfList; index++)
      {

        Console.Write("Member {0} : ", index);
        inputList.Add(Convert.ToInt16(Console.ReadLine()));
      }


      Console.Write("Input the value above you want to display the members of the list : ");
      inputGreaterThan = Convert.ToInt16(Console.ReadLine());

      var resultArray =
          from x in inputList
          where x > inputGreaterThan
          select x;

      Console.WriteLine("\nExpected Output:");
      Console.WriteLine("The numbers greater than {0} are : ", inputGreaterThan);
      foreach (var item in resultArray)
      {
        Console.WriteLine(item);
      }
    }

    public void Example11()
    {
      int[] demoArray = { 5, 7, 13, 24, 6, 9, 8, 7 };

      Console.WriteLine("\n# Practice 11");
      Console.Write("\nLINQ : Display top nth records from the list : ");
      Console.Write("\n----------------------------------------------\n");
      Console.WriteLine("\nThe members of the list are : ");

      foreach (var item in demoArray)
      {
        Console.WriteLine(item);
      }

      Console.Write("How many records you want to display ? : ");
      int recordToDisplay = Convert.ToInt32(Console.ReadLine());

      var resultArray =
          from x in demoArray
          orderby x descending
          select x;

      Console.Write("The top {0} records from the list are : \n", recordToDisplay);
      foreach (int topn in resultArray.Take(recordToDisplay))
      {
        Console.WriteLine(topn);
      }
    }

    public void Example12()
    {
      static IEnumerable<string> WordFilter(string mystr)
      {
        // Split string and get uppercase word
        IEnumerable<string> upWord = mystr.Split(' ')
            .Where(x => string.Equals(x, x.ToUpper(),
                StringComparison.Ordinal));

        return upWord;

      }

      Console.WriteLine("\n# Practice 12");
      Console.Write("\nInput the string : ");
      string inputString = Console.ReadLine();

      IEnumerable<string> uppercaseList = WordFilter(inputString);

      Console.WriteLine(" \nThe UPPER CASE words are:");
      foreach (var item in uppercaseList)
      {
        Console.WriteLine(item);
      }

    }

    public void Example13()
    {
      int lengthOfList;
      List<string> inputList = new List<string>();

      Console.WriteLine("\n# Practice 13");

      Console.Write("\nInput number of strings to store in the array : ");
      lengthOfList = Convert.ToInt16(Console.ReadLine());

      Console.Write("Input {0} strings for the array : \n", lengthOfList);
      for (int index = 0; index < lengthOfList; index++)
      {

        Console.Write("Element[{0}] : ", index);
        inputList.Add(Console.ReadLine());
      }

      Console.Write("\nHere is the string below created with elements of the above array : \n");
      foreach (var item in inputList)
      {
        Console.Write("{0} ", item);
      }
    }

    public void Example14()
    {
      Console.WriteLine("\n# Practice 14");
    }

    public void Example15()
    {
      Console.WriteLine("\n# Practice 15");
      string[] files = { "aaa.frx", "bbb.TXT", "xyz.dbf", "abc.pdf", "aaaa.PDF", "xyz.frt", "abc.xml", "ccc.txt", "zzz.txt" };

      Console.Write("\nLINQ : Count file extensions and group it : ");
      Console.Write("\n------------------------------------------\n");

      Console.Write("\nThe files are : aaa.frx, bbb.TXT, xyz.dbf,abc.pdf");
      Console.Write("\n                aaaa.PDF,xyz.frt, abc.xml, ccc.txt, zzz.txt\n");

      Console.Write("\nHere is the group of extension of the files : \n\n");

      var resultArray =
          from x in files.Select(item => Path.GetExtension(item).TrimStart('.').ToLower())
          group x by x into y
          select y;

      foreach (var item in resultArray)
      {
        Console.WriteLine("{0} File(s) with .{1} Extension", item.Count(), item.Key);
      }
    }

    public void Example16()
    {
      Console.WriteLine("\n# Practice 16");
    }

    public void Example17()
    {
      Console.WriteLine("\n# Practice 17");

      List<string> listChars = new List<string>();
      listChars.Add("m");
      listChars.Add("n");
      listChars.Add("o");
      listChars.Add("p");
      listChars.Add("q");

      Console.Write("\nLINQ : Remove items from list using remove function : ");
      Console.Write("\n----------------------------------------------------\n");

      Console.Write("Here is the list of items : \n");
      foreach (string item in listChars)
      {
        Console.WriteLine("Char: {0} ", item);
      }

      listChars.Remove("o");

      Console.Write("\nHere is the list after removing the item 'o' from the list : \n");
      foreach (var item in listChars)
      {
        Console.WriteLine("Char: {0} ", item);
      }
    }

    public void Example18()
    {
      Console.WriteLine("\n# Practice 18");

      string[] listChars = { "m", "n", "o", "p", "q" };

      Console.Write("\nLINQ : Remove items from list using remove function : ");
      Console.Write("\n----------------------------------------------------\n");

      Console.Write("Here is the list of items : \n");
      foreach (string item in listChars)
      {
        Console.WriteLine("Char: {0} ", item);
      }

      var resultArray =
          from x in listChars
          where x != "o"
          select x;

      Console.Write("\nHere is the list after removing the item 'o' from the list : \n");
      foreach (var item in resultArray)
      {
        Console.WriteLine("Char: {0} ", item);
      }
    }
  }
}
