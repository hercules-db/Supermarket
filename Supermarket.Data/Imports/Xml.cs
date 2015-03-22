namespace Supermarket.Data.Imports
{
    using System;
    using System.Linq;
    using System.Xml;

    using Context;
    using Models;

    public class Xml
    {
        public static void Import(string fileName, ISupermarketContext context)
        {
            var document = new XmlDocument();

            document.Load(fileName);

            XmlNode rootNode = document.DocumentElement;

            foreach (XmlNode node in rootNode.ChildNodes)
            {

                var vendor = node.Attributes["name"].Value;

                foreach (XmlNode n in node.ChildNodes)
                {
                    var month = n.Attributes["month"].Value;
                    var expense = n.InnerText;

                    context.Expenses.Add(new Expense()
                    {
                        VendorId = context.Vendors.First(x => x.VendorName == vendor).VendorId,
                        ExpenseDate = DateTime.Parse(month),
                        ExpenseAmount = decimal.Parse(expense)
                    });
                }
            }

            context.SaveChanges();
        }
    }
}