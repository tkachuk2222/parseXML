using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;

namespace workWithXML
{
    class Program
    {
        private const string filename = "..//..//..//currency-cash.xml";
        static private int cnt = 0;
        static void Main(string[] args)
        {
            XPathDocument doc = new XPathDocument(filename);
            XPathNavigator nav = doc.CreateNavigator();

            XPathNodeIterator it =  nav.Select("/source/organizations/organization");
            //
            //iterators for exchange
            XPathNodeIterator valuta = nav.Select("/source/organizations/organization/currencies");

            while (it.MoveNext())
            {
                //
                //creating iterators for valutes, banks, and adress
                valuta.MoveNext();
                XPathNodeIterator itID = valuta.Current.Select("c/@id");
                XPathNodeIterator itBR = valuta.Current.Select("c/@br");
                XPathNodeIterator itAR = valuta.Current.Select("c/@ar");

                XPathNodeIterator itName =  it.Current.Select("title/@value");
                XPathNodeIterator itAdress = it.Current.Select("address/@value");

                //
                //reading name of all banks and they adress
                itName.MoveNext();
                itAdress.MoveNext();
                Console.WriteLine($"{itName.Current.Value}\t\t{itAdress.Current.Value}");
                //
                //reading exchange rate
                while (itID.MoveNext())
                {
                    itBR.MoveNext();
                    itAR.MoveNext();
                    Console.WriteLine($"{itID.Current.Value}\t{itBR.Current.Value}\t{itAR.Current.Value}");
                }
                Console.WriteLine($"\t\t");
            }



            Console.WriteLine("\n\n\t\tExchange offices\n");
            it = nav.Select("/source/organizations/organization[@org_type=2]");
            valuta = nav.Select("/source/organizations/organization/currencies");
            while (it.MoveNext())
            {
                //
                //creating iterators for valutes, banks, and adress
                //
                //creating iterators for valutes, banks, and adress
                valuta.MoveNext();
                XPathNodeIterator itID = valuta.Current.Select("c/@id");
                XPathNodeIterator itBR = valuta.Current.Select("c/@br");
                XPathNodeIterator itAR = valuta.Current.Select("c/@ar");

                XPathNodeIterator itName = it.Current.Select("title/@value");
                XPathNodeIterator itAdress = it.Current.Select("address/@value");
                //
                //reading name of all banks and they adress
                
                itName.MoveNext();
                itAdress.MoveNext();
                Console.WriteLine($"{itName.Current.Value}\t\t{itAdress.Current.Value}");
                //
                //reading exchange rate
                while (itID.MoveNext())
                {
                    itBR.MoveNext();
                    itAR.MoveNext();
                    Console.WriteLine($"{itID.Current.Value}\t{itBR.Current.Value}\t{itAR.Current.Value}");
                }
                Console.WriteLine($"\t\t");
            }
        }
            
        //    XmlTextReader read = null;
        //    try
        //    {
        //        // Load the reader with the data file and ignore all white space nodes.       
        //        read = new XmlTextReader(filename);
        //        read.WhitespaceHandling = WhitespaceHandling.None;
        //        while (read.Read())
        //        {
        //            // Parse the file and display each of the nodes.
        //            if (read.NodeType == XmlNodeType.Element &&
        //        read.Name == "title" )
        //            {
        //    //            Console.WriteLine($"Bank:  {read.} ");
        //            }
        //        }
        //    }

        //    finally
        //    {
        //        if (read != null)
        //            read.Close();
        //    }



        //    XmlDocument doc = new XmlDocument();
        //    doc.Load(filename);
        //    OutputNode(doc.DocumentElement);
        //}
        //static void OutputNode(XmlNode node)
        //{
        ////    Console.WriteLine($"NodeType\t{node.NodeType}\nnode Value\t{node.Value}\nnode Name\t{node.Name}");
        //    if(node.Attributes != null)
        //    {
        //        foreach(XmlAttribute attr in node.Attributes)
        //        {
        //            Console.WriteLine($"NodeType\t{node.NodeType}\nnode Value\t{node.Value}\nnode Name\t{node.Name}");
        //        }
        //    }
        //    if (node.HasChildNodes)
        //        foreach(XmlNode el in node.ChildNodes)
        //        {
        //            OutputNode(el);
        //        }
        //}


    }

}
