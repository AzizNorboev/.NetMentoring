using Microsoft.EntityFrameworkCore;
using OOPfundamentals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web
{
    public class DocumentDbContext : DbContext
    {
        public DocumentDbContext(DbContextOptions<DocumentDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<LocalizedBook> LocalizedBooks { get; set; }
        public virtual DbSet<Magazine> Magazines { get; set; }
        public virtual DbSet<Patent> Patents { get; set; }
        public virtual DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(
                 new Author
                 {
                     Id = 1,
                     Name = "Douglas Adams",
                     DocumentAuthorsId = 1
                 },
                 new Author
                 {
                     Id = 2,
                     Name = "Eoin Colfer",
                     DocumentAuthorsId = 1
                 },
                 new Author
                 {
                     Id = 3,
                     Name = "Thomas Tidholm",
                     DocumentAuthorsId = 1
                 },
                 new Author
                 {
                     Id = 4,
                     Name = "Douglas Adams",
                     DocumentAuthorsId = 2
                 },
                 new Author
                 {
                     Id = 5,
                     Name = "Author Patent",
                     DocumentAuthorsId = 3
                 }
                );

            modelBuilder.Entity<Book>().HasData(new Book()
            {
                Id = 1,
                ISBN = "12-34-56-78-90",
                Title = "Hitchhiker's guide to the galaxy",
                DatePublished = DateTime.Now,
                NumberOfPages = 450,
                Publisher = "Publisher",
            });
            modelBuilder.Entity<Document>().HasData(new Document
            {
                Id = 5,
                DatePublished = DateTime.Now,
                Title = "Document Title"
            });
            modelBuilder.Entity<LocalizedBook>().HasData(new LocalizedBook
            {
                Id = 2,
                ISBN = "09-87-65-43-21",
                DatePublished = DateTime.Now,
                Title = "The silence of the Lambs",
                NumberOfPages = 464,
                Publisher = "Localize Publisher",
                CountryOfLocalization = "Uzbekistan",
                LocalPublisher = "localPublisher"
            });
            modelBuilder.Entity<Magazine>().HasData(new Magazine
            {
                Id = 4,
                DatePublished = DateTime.Now,
                Publisher = "Mazagine Publisher",
                Title = "Magazine Title",
            });
            modelBuilder.Entity<Patent>().HasData(new Patent
            {
                Id = 3,
                Title = "Patent",
                DatePublished = DateTime.Now,
                ExpirationDate = DateTime.Now.AddYears(3),
            });
        }
    }
}
