using System.Xml.Linq;

namespace CSharpBasic.LINQ
{
  partial class LINQ 
  {
    void Example23()
    {
      var styleInstruction = new XProcessingInstruction(
        "xml-stylesheet", "href='styles.css' type='text/css'");

      var docType = new XDocumentType("html",
        "-//W3C//DTD XHTML 1.0 Strict//EN",
        "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd", null);

      XNamespace ns = "http://www.w3.org/1999/xhtml";

      var root =
        new XElement(ns + "html",
          new XElement(ns + "head",
            new XElement(ns + "title", "An XHTML page")),
          new XElement(ns + "body",
            new XElement(ns + "p", "This is the content"))
        );

      var doc =
        new XDocument(
          new XDeclaration("1.0", "utf-8", "no"),
          new XComment("Reference a stylesheet"),
          styleInstruction,
          docType,
          root);

      Console.WriteLine(doc.ToString());

      doc.Save("test.html");
    }
  }
}
