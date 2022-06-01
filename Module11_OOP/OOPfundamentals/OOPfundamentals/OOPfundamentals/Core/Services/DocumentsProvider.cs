using OOPfundamentals.Core.Services.Interfaces;
using OOPfundamentals.Models;
using System;
using System.Collections;
using System.Runtime.Caching;

namespace OOPfundamentals.Core.Services
{
    public class DocumentsProvider : IDocumentsProvider
    {
        readonly CachedDocument cachedDocument = new();

        public IEnumerable GetDocuments()
        {
            cachedDocument.Key = "document";

            ObjectCache cache = MemoryCache.Default;

            if (cache.Contains(cachedDocument.Key))
            {
                return (IEnumerable)cache.Get(cachedDocument.Key);
            }
            else
            {
                var documents = InitializeData.Initialize();

                var policy = new CacheItemPolicy
                {
                    AbsoluteExpiration = DateTime.Now.AddHours(15),
                    Priority = CacheItemPriority.Default,
                };

                cache.Add(cachedDocument.Key, documents, policy);

                return documents;
            }
        }
        public IEnumerable GetBooks()
        {
            cachedDocument.Key = "book";

            ObjectCache cache = MemoryCache.Default;

            if (cache.Contains(cachedDocument.Key))
            {
                return (IEnumerable)cache.Get(cachedDocument.Key);
            }
            else
            {
                var books = InitializeData.BookInitializer();

                var policy = new CacheItemPolicy
                {
                    AbsoluteExpiration = DateTime.Now.AddHours(15),
                    Priority = CacheItemPriority.Default,
                };

                cache.Add(cachedDocument.Key, books, policy);

                return books;
            }
        }

    }
}
