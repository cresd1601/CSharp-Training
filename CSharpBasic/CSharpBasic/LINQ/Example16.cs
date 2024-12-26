using System.Xml.Linq;

namespace CSharpBasic.LINQ
{
  partial class LINQ 
  {
    void Example16()
    {
      var address = new XElement("address",
        new XElement("street", "Lawley St"),
        new XElement("town", "North Beach")
      );
      var customer1 = new XElement("customer1", address);
      var customer2 = new XElement("customer2", address);

      customer1.Element("address").Element("street").Value = "Another St";

      Console.WriteLine(
        customer1.Element("address").Element("street").Value); // Another St
      Console.WriteLine(
        customer2.Element("address").Element("street").Value); // Lawley St
    }
  }
}
