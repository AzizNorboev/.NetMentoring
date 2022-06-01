using Microsoft.AspNetCore.Mvc;
using OOPfundamentals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class MagazinesController : Controller
    {
        private readonly DocumentDbContext _context;
        public MagazinesController(DocumentDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var books = _context.Magazines.ToList();
            return View(books);
        }
        public IActionResult Details(int id)
        {
            var book = _context.Magazines.FirstOrDefault(b => b.Id == id);
            return View(book);
        }
    }
}
