using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03
{
    abstract class Document : IPrintable
    {

        #region Method overload

        public void SetContent(string newContent)
        {
            Content = newContent;
        }

        public void SetContent(string header, string body, string footer)
        {
            Content = string.Format("{0}\n{1}\n{2}", header, body, footer);
        }

        #endregion

        #region Operator overload

        #region Operator overloads

        public static Boolean operator ==(Document a, Document b)
        {
            if ((object)a == null || (object)b == null) return false;

            return a.Title == b.Title && a.Author == b.Author;
        }

        public static Boolean operator !=(Document a, Document b)
        {
            return !(a == b);
        }

        #endregion

        #region Advised for == operator overload

        public override bool Equals(object obj)
        {
            Document other = obj as Document;
            if (other == null) return false;
            return other == this;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion

        #endregion

        public string Title { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }

        public Document(string title, string author, string content)
        {
            Title = title;
            Author = author;
            Content = content;
        }

        #region Polimorphism

        public string Description()
        {
            return string.Format("{0, 8} ({1})", Title, Author);
        }

        public virtual string Description_override()
        {
            return Description();
        }

        public virtual string Description_new()
        {
            return Description();
        }

        #endregion

        #region Abstract behaviour

        public abstract string Validator();

        #endregion

        #region IPrintable interface implementation

        public virtual string Print()
        {
            return Description();
        }

        #endregion
    }
}
