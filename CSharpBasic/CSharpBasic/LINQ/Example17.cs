using System.Xml.Linq;

namespace CSharpBasic.LINQ
{
  partial class LINQ 
  {
    void Example17()
    {
      var bench = new XElement("bench",
        new XElement("toolbox",
          new XElement("handtool", "Hammer"),
          new XElement("handtool", "Rasp")
        ),
        new XElement("toolbox",
          new XElement("handtool", "Saw"),
          new XElement("powertool", "Nailgun")
        ),
        new XComment("Be careful with the nailgun")
      );

      foreach (XNode node in bench.Nodes())
        Console.WriteLine(node.ToString(SaveOptions.DisableFormatting) + ".");

      foreach (XElement e in bench.Elements())
        Console.WriteLine(e.Name + "=" + e.Value);
    }
  }
}
