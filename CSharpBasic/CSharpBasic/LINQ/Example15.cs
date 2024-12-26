using System.Xml.Linq;

namespace CSharpBasic.LINQ
{
  partial class LINQ 
  {
    void Example15()
    {
      XElement lastName = new XElement("lastname", "Bloggs");

      lastName.Add(new XComment("nice name"));

      XElement customer = new XElement("customer");

      customer.Add(new XAttribute("id", 123));

      customer.Add(new XElement("firstname", "Joe"));

      customer.Add(lastName);

      Console.WriteLine(customer.ToString());
    }
  }
}
