using System;
using System.Collections.Generic;

namespace OOPfundamentals.Models
{
    public class LocalizedBook : Book
    {
        public string LocalPublisher { get; set; }

        public string CountryOfLocalization { get; set; }

        public LocalizedBook()
        {

        }

        public LocalizedBook(string isbn, string title, DateTime datePublished, IEnumerable<Author> authors, int numberOfPage, string publisher, string localPublisher, string countryOfLocalization)
            : base(isbn, title, datePublished, authors, numberOfPage, publisher)
        {
            LocalPublisher = localPublisher;
            CountryOfLocalization = countryOfLocalization;
        }
    }
}
