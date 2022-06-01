using OOPfundamentals.Core.Services;
using OOPfundamentals.Core.Services.Interfaces;
using OOPfundamentals.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace OOPfundamentals
{
    public class LibraryStorageFS : LibraryStorage
    {
        //readonly InitializeData initializeData = new ();
        readonly IList<Document> documents;
        readonly IList<Book> books;
        //soliD - injecting cachedDocument through constructor and making it dependent on Interface - D
        IDocumentsProvider CachedDocument;

        public LibraryStorageFS(IDocumentsProvider cachedDocument)
        {
            documents = (List<Document>)InitializeData.Initialize();
            books = (List<Book>)InitializeData.BookInitializer();
            CachedDocument = cachedDocument;
        }

        public override Document GetDocumentById(int id)
        {
            return documents.FirstOrDefault(item => item.Id.Equals(id));
        }

        public override Book GetBookByISBN(string isbn)
        {
            return books.FirstOrDefault(item => item.ISBN.Equals(isbn));
        }

        public override IEnumerable GetDocuments()
        {
            var cachedDocuments = CachedDocument.GetDocuments();
            return cachedDocuments;
        }
        public override IEnumerable GetBooks()
        {
            var cachedDocuments = CachedDocument.GetBooks();
            return cachedDocuments;
        }
    }
}
