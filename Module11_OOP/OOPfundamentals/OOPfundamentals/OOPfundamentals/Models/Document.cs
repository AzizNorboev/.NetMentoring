using System;

namespace OOPfundamentals.Models
{
    public class Document
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime DatePublished { get; set; }

        public Document()
        {

        }

        public Document(string title, DateTime datePublished)
        {
            Title = title;
            DatePublished = datePublished;
        }
    }
}
