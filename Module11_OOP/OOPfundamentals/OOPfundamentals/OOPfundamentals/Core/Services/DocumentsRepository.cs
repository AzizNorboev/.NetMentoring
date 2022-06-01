using Microsoft.EntityFrameworkCore;
using OOPfundamentals.Core.Services.Interfaces;
using OOPfundamentals.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPfundamentals.Core.Services
{
    public class DocumentsRepository : IRepository
    {
        public Book GetBookByIsbn(string isbn)
        {
            Book book = new Book();
            using (var db = new DocumentDbContext())
            {
                book = db.Books.Where(b => b.ISBN == isbn).FirstOrDefault();         
            }
            return book;
        }
        public Document GetDocumentById(int id)
        {
            Document document = new Document();
            using (var db = new DocumentDbContext())
            {
                document = db.Documents.Where(d => d.Id == id).FirstOrDefault();
            }
            return document;
        }
        public IEnumerable GetBooks()
        {
            List<Book> books = new List<Book>();
            using(var db = new DocumentDbContext())
            {
                books = db.Books.Include(a => a.Authors).ToList();
            }
            return books;
        }

        public IEnumerable GetDocuments()
        {
            List<Document> documents = new List<Document>();
            using (var db = new DocumentDbContext())
            {
                documents = db.Documents.ToList();
            }
            return documents;
        }
    }
}
