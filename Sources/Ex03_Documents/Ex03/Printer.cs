using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03
{
    class Printer
    {
        #region Simple input

        public static void Print(string thing)
        {
            Console.WriteLine(thing);
        }

        #endregion

        #region Coupled

        public static void Print(CV thing)
        {
            Console.WriteLine(thing.Header());
        }

        public static void Print(Invoice thing)
        {
            Console.WriteLine(thing.State());
        }

        #region Upcast

        public static void Print(Document thing)
        {
            Console.WriteLine(string.Format("New: {0}", thing.Description_new()));
        }

        #endregion

        #endregion

        #region Decoupled

        public static void Print(IPrintable thing)
        {
            Console.WriteLine(thing.Print());
        }

        #endregion
    }
}
