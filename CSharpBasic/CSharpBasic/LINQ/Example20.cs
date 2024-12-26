using System.Xml.Linq;

namespace CSharpBasic.LINQ
{
  partial class LINQ 
  {
    void Example20()
    {
      XElement items = new XElement("items",
        new XElement("one"),
        new XElement("three")
      );

      items.FirstNode.AddAfterSelf(new XElement("two"));

      Console.WriteLine(items.ToString());
    }
  }
}
