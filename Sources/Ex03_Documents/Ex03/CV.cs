using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03
{
    class CV : Document
    {
        public string Type { get; set; }

        public CV(string author, string type, string content) : base("CV", author, content)
        {
            Type = type;
        }

        public string Header()
        {
            return string.Format("{0} {1} önéletrajza", Author, Type);
        }

        #region Polimorhpism

        public override string Description_override()
        {
            return Header();
        }

        public new string Description_new()
        {
            return Header();
        }

        #endregion

        #region Abstract behaviour

        public override string Validator()
        {
            return "Human resources";
        }

        #endregion

        #region IPrintable interface implementation override

        public new string Print()
        {
            return Header();
        }

        #endregion
    }
}
