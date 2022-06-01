using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.DAL.Repository
{
    public interface IDocumentRepository<T>
    {
        Task<T> GetAll();
        Task<T> GetById(int id);
    }
}
