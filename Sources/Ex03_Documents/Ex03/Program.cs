using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03
{
    class Program
    {
        static void Main(string[] args)
        {
            //============================== Inheritance, instantiation

            Console.WriteLine("CV");

            List<CV> cvs = new List<CV>();
            cvs.Add(new CV("Tamás", "általános", "tartalom 1"));
            cvs.Add(new CV("Tamás", "informatikai", "tartalom 2"));
            cvs.Add(new CV("Tamás", "sport", "tartalom 3"));

            foreach (CV cv in cvs)
            {
                string toPrint = string.Format("{0} - {1}", cv.Header(), cv.Validator());
                Printer.Print(toPrint);
            }

            Console.WriteLine();
            Console.WriteLine("Invoices");

            List<Invoice> invoices = new List<Invoice>();
            invoices.Add(new Invoice("Béla", 3333, "tartalom 4", false));
            invoices.Add(new Invoice("Géza", 4444, "tartalom 5", true));
            invoices.Add(new Invoice("Tóni", 2222, "tartalom 6", false));

            foreach (Invoice i in invoices)
            {
                string toPrint = string.Format("{0} - {1}", i.State(), i.Validator());
                Printer.Print(toPrint);
            }

            //============================== Method overload
            cvs[0].SetContent("ez lesz az új tartalom");
            cvs[0].SetContent("Fejléc", "ez lesz az új tartalom", "Lábléc");

            //============================== Method override
            Console.WriteLine();
            Console.WriteLine("Method override");
            Printer.Print(cvs[0].Description_override());
            Printer.Print(invoices[0].Description_override());

            //============================== Operator override
            Console.WriteLine();
            Console.WriteLine("Operator overload ==");
            CV temp = cvs[0];
            CV cv1b = new CV("Tamás", "általános", "tartalom 7");
            Printer.Print(string.Format("newItem == listItem: ", cv1b == cvs[0]));
            Printer.Print(string.Format("tempItem == listItem: ", temp == cvs[0]));

            //============================== Upcast
            Console.WriteLine();
            Console.WriteLine("Upcast");

            Document doc = cvs[0];
            Printer.Print(doc.Description_override());
            doc = invoices[0];
            Printer.Print(doc.Description_override());

            //============================== Method new: Common list based on upcast
            Console.WriteLine();
            Console.WriteLine("Common list");

            List<Document> docs = new List<Document>();
            docs.AddRange(cvs);
            docs.AddRange(invoices);

            foreach (Document d in docs)
            {
                Printer.Print(d);
            }

            //============================== Interface implementation usage I: Sorted list
            Console.WriteLine();
            Console.WriteLine("Sorted list");

            invoices.Sort();
            foreach (Invoice i in invoices)
            {
                Printer.Print(i);
            }

            //============================== Different class
            Console.WriteLine();
            Console.WriteLine("New instance of different class");
            SpaceShuttle ss = new SpaceShuttle("Endeavour", "1992.05.07");
            Printer.Print(ss.Description());

            //============================== Interface implementation usage II: Combined list and usage
            Console.WriteLine();
            Console.WriteLine("Collection of Interface instances");

            List<IPrintable> thingsToPrint = new List<IPrintable>();
            thingsToPrint.AddRange(cvs);
            thingsToPrint.AddRange(invoices);
            thingsToPrint.Add(ss);

            foreach (IPrintable p in thingsToPrint)
            {
                Printer.Print(p.Print());
            }

            Console.WriteLine();
        }
    }
}
