using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OOPfundamentals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class LocalizedBooksController : Controller
    {
        private readonly DocumentDbContext _context;
        public LocalizedBooksController(DocumentDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var books = _context.LocalizedBooks.Include(a => a.Authors).ToList();
            return View(books);
        }
        public IActionResult Details(int id)
        {
            var book = _context.LocalizedBooks.Include(a => a.Authors).FirstOrDefault(b => b.Id == id);
            return View(book);
        }
    }
}
