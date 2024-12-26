using System.Xml.Linq;

namespace CSharpBasic.LINQ
{
  partial class LINQ 
  {
    void Example22()
    {
      XElement contacts = XElement.Parse(
        @"<contacts>
                      <customer name='Mary'/>
                      <customer name='Chris' archived='true'/>
                      <supplier name='Susan'>
                      <phone archived='true'>012345678<!--confidential--></phone>
                      </supplier>
                      </contacts>");

      contacts.Elements("customer").Remove();

      contacts.Elements().Where(e => (bool?)e.Attribute("archived") == true)
        .Remove();

      contacts.Elements().Where(e => e.DescendantNodes()
        .OfType<XComment>()
        .Any(c => c.Value == "confidential")
      ).Remove();

      contacts.DescendantNodes().OfType<XComment>().Remove();

      Console.WriteLine(contacts.ToString());
    }
  }
}
