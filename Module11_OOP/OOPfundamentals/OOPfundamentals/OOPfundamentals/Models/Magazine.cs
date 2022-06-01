using System;

namespace OOPfundamentals.Models
{
    public class Magazine : Document
    {
        public string Publisher { get; set; }

        public Magazine()
        {

        }

        public Magazine(string title, DateTime datePublished, string publisher)
            : base(title, datePublished)
        {
            Publisher = publisher;
        }
    }
}
