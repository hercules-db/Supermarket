namespace Supermarket.Data.Imports
{
    using System.Xml;

    using Context;
    
    public class Xml
    {
        public static void Import(string fileName, ISupermarketContext context)
        {
            var document = new XmlDocument();

            document.Load(fileName);

            XmlNode rootNode = document.DocumentElement;

            foreach (XmlNode node in rootNode.ChildNodes)
            {
                var vendor = node.Value;


                /*var expenseMonth = this.GetValue(node, "information");
                var expenseAmount =decimal.Parse(this.GetValue(node, "price"));*/
            }

            context.SaveChanges();
        }
    }
}