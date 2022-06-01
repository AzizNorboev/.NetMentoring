using System;
using System.Collections.Generic;

namespace OOPfundamentals.Models
{
    public class DocumentAuthors : Document
    {
        public IEnumerable<Author> Authors { get; set; }

        public DocumentAuthors()
        {

        }

        public DocumentAuthors(string title, DateTime datePublished, IEnumerable<Author> authors) 
            : base(title, datePublished)
        {
            Authors= authors;
        }
    }
}
