using System;
using System.Collections.Generic;

namespace OOPfundamentals.Models
{
    [Serializable]
    public class Book : DocumentAuthors
    {
        public string ISBN { get; set; }
        public int NumberOfPages { get; set; }

        public string Publisher { get; set; }

        public Book()
        {

        }

        public Book(string isbn, string title, DateTime datePublished, IEnumerable<Author> authors, int numberOfPage, string publisher)
            : base(title, datePublished, authors)
        {
            ISBN = isbn;
            Publisher = publisher;
            NumberOfPages = numberOfPage;
        }
    }
}
