using OOPfundamentals.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace OOPfundamentals
{
    public static class InitializeData
    {
        public static IEnumerable BookInitializer()
        {
            Author author = new Author();
            author.Id = 1;
            author.Name = "Douglas Adams";
            Author author1 = new Author();
            author1.Id = 2;
            author1.Name = "Eoin Colfer";
            Author author2 = new Author();
            author2.Id = 3;
            author2.Name = "Thomas Tidholm";
            Book book = new()
            {
                Id = 1,
                ISBN = "12-34-56-78-90",
                Title = "Hitchhiker's guide to the galaxy",
                Authors = new List<Author>
                {
                    author,
                    author1,
                    author2
                },
                DatePublished = DateTime.Now,
                NumberOfPages = 450,
                Publisher = "Publisher",
            };
            Author author3 = new Author();
            author3.Name = "Thomas Tidholm";
            author3.Id = 4;
            LocalizedBook localizedBook = new()
            {
                Id = 2,
                ISBN = "09-87-65-43-21",
                Authors = new List<Author>
                {
                    author3
                },
                DatePublished = DateTime.Now,
                Title = "The silence of the Lambs",
                NumberOfPages = 464,
                Publisher = "Localize Publisher",
                CountryOfLocalization = "Uzbekistan",
                LocalPublisher = "localPublisher"
            };

            var books = new List<Book>()
            {
                book,
                localizedBook,

            };

            return books;
        }
        public static IEnumerable Initialize()
        {
            Author author = new Author();
            author.Name = "Author Patent";
            Patent patent = new()
            {
                Authors = new List<Author>
                {
                    author
                },
                Id = 3,
                Title = "Patent",
                DatePublished = DateTime.Now,
                ExpirationDate = DateTime.Now.AddYears(3),
            };

            Magazine magazine = new ()
            {
                Id = 4,
                DatePublished = DateTime.Now,
                Publisher = "Mazagine Publisher",
                Title = "Magazine Title",
            };

            Document document = new ()
            {
                Id = 5,
                DatePublished = DateTime.Now,
                Title = "Document Title"
            };

            var documents = new List<Document>()
            {
                patent,
                magazine,
                document
            };

            return documents;
        }
    }
}
