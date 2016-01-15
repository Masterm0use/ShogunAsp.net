using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shogun_WebApplicatie.Csharp
{
    public class BlogReactie : Reactie
    {
        private int blogReactieID;

        public int BlogReactieID
        {
            get { return blogReactieID; }
        }

        public BlogReactie(int reactieID, Klant schijverKlant, string reactieuit, DateTime datepost, int blogReactieID )
            : base(reactieID, schijverKlant, reactieuit, datepost)
        {
            this.blogReactieID = blogReactieID;
        }
    }
}
    