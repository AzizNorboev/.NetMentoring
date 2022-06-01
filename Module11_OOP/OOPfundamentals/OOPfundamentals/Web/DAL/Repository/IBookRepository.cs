using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.DAL.Repository
{
    public interface IBookRepository<T>
    {
        Task<T> GetAll();
        Task<T> GetByIsbn(string isbn);
    }
}
