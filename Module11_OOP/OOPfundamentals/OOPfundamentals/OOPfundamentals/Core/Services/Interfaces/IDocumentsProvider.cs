using System.Collections;

namespace OOPfundamentals.Core.Services.Interfaces
{
    public interface IDocumentsProvider
    {
        public IEnumerable GetDocuments();
        public IEnumerable GetBooks();
    }
}