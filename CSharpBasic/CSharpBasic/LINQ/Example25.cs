using System.Xml.Linq;

namespace CSharpBasic.LINQ
{
  partial class LINQ 
  {
    void Example25()
    {
      XNamespace ns = "http://domain.com/xmlspace";

      var data = new XElement(ns + "data",
        new XElement(ns + "customer", "Bloggs"),
        new XElement(ns + "purchase", "Bicycle")
      );

      Console.WriteLine(data.ToString());
    }
  }
}
