using System;
using System.Collections.Generic;

namespace OOPfundamentals.Models
{
    public class Patent : DocumentAuthors
    {
        public DateTime ExpirationDate { get; set; }

        public Patent()
        {

        }

        public Patent(string title, DateTime datePublished, IEnumerable<Author> authors, DateTime expirationDate) 
            : base(title, datePublished, authors)
        {
            ExpirationDate = expirationDate;
        }
    }
}
