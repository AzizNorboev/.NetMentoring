using OOPfundamentals.Core.Services.Interfaces;
using OOPfundamentals.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPfundamentals
{
    public class LibraryStorageDb : LibraryStorage
    {
        //soliD
        private IRepository Repo;
        public LibraryStorageDb(IRepository repo)
        {
            Repo = repo;
        }

        public override Book GetBookByISBN(string isbn)
        {
            var book = Repo.GetBookByIsbn(isbn);
            return book;
        }

        public override IEnumerable GetBooks()
        {
            var books = Repo.GetBooks();
            return books;
        }

        public override Document GetDocumentById(int id)
        {
            var document = Repo.GetDocumentById(id);
            return document;
        }

        public override IEnumerable GetDocuments()
        {
            var documents = Repo.GetDocuments();
            return documents;
        }
    }
}
