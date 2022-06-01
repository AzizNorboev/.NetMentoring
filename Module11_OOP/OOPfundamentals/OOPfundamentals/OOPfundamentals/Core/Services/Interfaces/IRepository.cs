using OOPfundamentals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPfundamentals.Core.Services.Interfaces
{
    //Interface segregation 
    public interface IRepository : IDocumentsProvider
    {
        Book GetBookByIsbn(string isbn);
        Document GetDocumentById(int id);
        //LocalizedBook GetLocalizedBookById();
        //Magazine GetMagazineById();
        //Patent GetPatentById();
        //public List<LocalizedBook> GetLocalizedBooks();
        //public List<Magazine> GetMagazines();
        //public List<Patent> GetPatents();
    }
}
