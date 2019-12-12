using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
namespace Trianz.DataUtlis
{
    class XmlUtils
    {
        public static List<Dictionary<string, string>> ReadXML(string xmlLocation)
        {
            XmlDocument document = new XmlDocument();
            // document.Load(@"D:\Mine\Company\Trianz\DataDrivenFramework\DataDrivenFramework\TestData\validdata.xml");
            document.Load(xmlLocation);

            List<Dictionary<string, string>> ls = new List<Dictionary<string, string>>();

            foreach (XmlNode node in document.DocumentElement.ChildNodes)
            {
                Dictionary<string, string> dic = new Dictionary<string, string>();
                foreach (XmlNode node1 in node.ChildNodes)
                {
                    string name = node1.Name;
                    string text = node1.InnerText;
                    dic.Add(name, text);
                }
                ls.Add(dic);
            }
            return ls;
        }
    }
}
