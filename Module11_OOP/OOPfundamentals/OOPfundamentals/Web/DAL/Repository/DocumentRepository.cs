using OOPfundamentals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace Web.DAL.Repository
{
    public class DocumentRepository : IDocumentRepository<Document>
    {
        public DocumentRepository(DocumentDbContext con)
        {

        }
        public Task<Document> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Document> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
