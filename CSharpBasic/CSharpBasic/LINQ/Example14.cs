using System.Xml.Linq;

namespace CSharpBasic.LINQ
{
  partial class LINQ 
  {
    void Example14()
    {
      XDocument fromWeb = XDocument.Load("http://albahari.com/sample.xml");

      // XElement fromFile = XElement.Load(@"e:\media\somefile.xml");

      XElement config = XElement.Parse(
        @"<configuration>  
                      <client enabled='true'>
                           <timeout>30</timeout>
                      </client>
                  </configuration>");

      foreach (XElement child in config.Elements())
        Console.WriteLine(child.Name);

      XElement client = config.Element("client");

      bool enabled = (bool)client.Attribute("enabled");

      Console.WriteLine(enabled);

      client.Attribute("enabled").SetValue(!enabled);

      int timeout = (int)client.Element("timeout");

      Console.WriteLine(timeout);

      client.Element("timeout").SetValue(timeout * 2);

      client.Add(new XElement("retries", 3));

      Console.WriteLine(config);
    }
  }
}
