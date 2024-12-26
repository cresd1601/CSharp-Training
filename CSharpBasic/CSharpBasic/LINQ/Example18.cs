using System.Xml.Linq;

namespace CSharpBasic.LINQ
{
  partial class LINQ 
  {
    void Example18()
    {
      XElement settings = new XElement("settings",
        new XElement("timeout", 30)
      );

      settings.SetValue("blah");

      Console.WriteLine(settings.ToString()); // <settings>blah</settings>
    }
  }
}
