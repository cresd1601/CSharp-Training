using System.Xml.Linq;

namespace CSharpBasic.LINQ
{
  partial class LINQ 
  {
    void Example19()
    {
      XElement settings = new XElement("settings");

      settings.SetElementValue("timeout", 30); // Adds child node
      settings.SetElementValue("timeout", 60); // Update it to 60

      Console.WriteLine(settings.ToString());
    }
  }
}
