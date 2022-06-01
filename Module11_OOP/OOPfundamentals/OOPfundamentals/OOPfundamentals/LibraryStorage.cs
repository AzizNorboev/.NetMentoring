using OOPfundamentals.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPfundamentals
{
    //Liskov substitution
    public abstract class LibraryStorage
    {
        public abstract Document GetDocumentById(int id);
        public abstract Book GetBookByISBN(string isbn);
        public abstract IEnumerable GetBooks();
        public abstract IEnumerable GetDocuments();
    }
}
