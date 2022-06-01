using Microsoft.Extensions.DependencyInjection;
using OOPfundamentals.Core.Services;
using OOPfundamentals.Core.Services.Interfaces;
using OOPfundamentals.Models;
using SerializerJson.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace OOPfundamentals
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Please input 1 to display from File System\nPlease input 2 to display from the Database");
            Console.Write("Input: ");
            string input = Console.ReadLine();

            if(input == "1")
            {
                //solId -> DocumentsRepository implements 2 interfaces whereas DocumentsProvider 1 - I
                IDocumentsProvider cachedDocument = new DocumentsProvider();
                LibraryStorage libraryStorage = new LibraryStorageFS(cachedDocument); // soLid - L

                var availableDocuments = libraryStorage.GetDocuments();
                var availableBooks = libraryStorage.GetBooks();

                SerializeDocuments((IList<Document>)availableDocuments);
                SerializeBooks((IList<Book>)availableBooks);

                Console.WriteLine("Files are saved in \\OOPfundamentals\\bin\\Debug\\net5.0"); Console.WriteLine();
            }
            else if (input == "2")
            {
                //solId -> DocumentsRepository implements 2 interfaces whereas DocumentsProvider 1 - I
                IRepository repo = new DocumentsRepository();
                LibraryStorage libraryStorageDb = new LibraryStorageDb(repo); // soLid - L
                DisplayBooks(repo.GetBooks());
                DisplayDocuments(repo.GetDocuments());
                libraryStorageDb.GetBookByISBN("12-34-56-78-90");
                libraryStorageDb.GetDocumentById(1);
            }
            Console.WriteLine("-1");
           
        }
        public static void DisplayBooks(IEnumerable books)
        {
            Console.WriteLine("Books:");
            foreach(var item in (List<Book>)books)
            {
                Console.WriteLine($"Id: { item.Id} ISBN: {item.ISBN}, Publisher: {item.Publisher}, " +
                    $"Author: {item.Authors.FirstOrDefault().Name}, Num of Pages: {item.NumberOfPages}");
            }
            Console.WriteLine();
        }
        public static void DisplayDocuments(IEnumerable documents)
        {
            Console.WriteLine("Documents:");
            foreach (var item in (List<Document>)documents)
            {
                Console.WriteLine($"Id: { item.Id} Title: {item.Title}, Published Date: {item.DatePublished}");
            }
            Console.WriteLine();
        }
        public static void SerializeDocuments(IList<Document> availableDocuments)
        {
            var serializer = new SerializerJson<Document>();
            foreach (var item in availableDocuments)
            {
                var types = item.GetType();
                var jsonObjects = $"{types.Name}_#{item.Id}";

                serializer.Serialize(item, jsonObjects);

                var deserializer = serializer.Deserialize(jsonObjects);

                Console.WriteLine($"{deserializer.Id}, {deserializer.Title}, {deserializer.DatePublished}");
            }
        }
        public static void SerializeBooks(IList<Book> availableBooks)
        {
            var serializer = new SerializerJson<Document>();
            foreach (var item in availableBooks)
            {
                var types = item.GetType();
                var jsonObjects = $"{types.Name}_#{item.ISBN}";

                serializer.Serialize(item, jsonObjects);

                var deserializer = serializer.Deserialize(jsonObjects);

                Console.WriteLine($"{deserializer.Id}, {deserializer.Title}, {deserializer.DatePublished}");
            }
        }
    }
}
