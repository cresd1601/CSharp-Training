using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace CSharpBasic.LINQ
{
  partial class LINQ 
  {
    void Example24()
    {
      var doc = new XDocument(
        new XDeclaration("1.0", "utf-8", "yes"),
        new XElement("test", "data")
      );

      var output = new StringBuilder();

      var settings = new XmlWriterSettings { Indent = true };

      using (XmlWriter xw = XmlWriter.Create(output, settings))
        doc.Save(xw);

      Console.WriteLine(output.ToString());
    }
  }
}
