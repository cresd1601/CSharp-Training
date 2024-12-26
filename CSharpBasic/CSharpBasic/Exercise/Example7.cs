namespace CSharpBasic.Exercise
{
  partial class Exercise
  {
    void Example7()
    {
      int meters, hours, minutes, seconds;
      double totalHours, totalMinutes, totalSeconds;
      double totalKilometers, totalMiles;

      Console.WriteLine("\n# Practice 7");

      Console.WriteLine("\nInput distance(meters):");
      meters = Convert.ToInt32(Console.ReadLine());

      Console.WriteLine("Input timeSec(hours):");
      hours = Convert.ToInt16(Console.ReadLine());

      Console.WriteLine("Input timeSec(minutes):");
      minutes = Convert.ToInt16(Console.ReadLine());

      Console.WriteLine("Input timeSec(seconds):");
      seconds = Convert.ToInt16(Console.ReadLine());

      totalKilometers = meters / 1000;
      totalMiles = totalKilometers * 0.62137;

      totalSeconds = seconds + (minutes * 60) + (hours * 60 * 60);
      totalMinutes = totalSeconds / 60;
      totalHours = totalMinutes / 60;

      Console.WriteLine("\nExpected Output:");
      Console.WriteLine("Your speed in meters/sec is {0}", meters / totalSeconds);
      Console.WriteLine("Your speed in km/h is {0}", totalKilometers / totalHours);
      Console.WriteLine("Your speed in miles/h is {0}", totalMiles / totalHours);

    }
  }
}
