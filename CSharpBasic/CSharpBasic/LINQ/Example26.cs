using System.Xml.Linq;

namespace CSharpBasic.LINQ
{
  partial class LINQ 
  {
    void Example26()
    {
      XNamespace ns1 = "http://domain.com/space1";
      XNamespace ns2 = "http://domain.com/space2";

      var mix = new XElement(ns1 + "data",
        new XElement(ns2 + "element", "value"),
        new XElement(ns2 + "element", "value"),
        new XElement(ns2 + "element", "value")
      );

      Console.WriteLine(mix.ToString());
    }
  }
}
