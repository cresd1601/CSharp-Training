using System.Xml.Linq;

namespace CSharpBasic.LINQ
{
  partial class LINQ 
  {
    void Example21()
    {
      XElement items = XElement.Parse("<items><one/><two/><three/></items>");

      items.FirstNode.ReplaceWith(new XComment("One was here"));

      Console.WriteLine(items.ToString());
    }
  }
}
