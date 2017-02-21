using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03
{
    class Invoice : Document, IComparable
    {
        public int Value { get; set; }
        public Boolean IsPayed { get; set; }

        public Invoice(string author, int value, string content, Boolean isPayed) : base("Invoice", author, content)
        {
            Value = value;
            IsPayed = isPayed;
        }

        public string State()
        {
            return string.Format("{0}{1} [{2}]", IsPayed?" ":"!", Value, Author);
        }

        #region Polimorhpism

        public override string Description_override()
        {
            return State();
        }

        public new string Description_new()
        {
            return State();
        }

        #endregion

        #region Abstract behaviour

        public override string Validator()
        {
            return "Finance";
        }

        #endregion

        #region IPrintable interface implementation override

        public new string Print()
        {
            return State();
        }

        #endregion

        #region IComparable interface implementation

        public int CompareTo(object obj)
        {
            Invoice other = obj as Invoice;

            if(other != null)
            {
                if (Value < other.Value) return -1;
                if (Value > other.Value) return 1;
                return 0;
            }

            return -1;
        }

        #endregion

    }
}
