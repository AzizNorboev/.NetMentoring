using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OOPfundamentals;
using OOPfundamentals.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class BooksController : Controller
    {
        private IRepository Repo;
        public BooksController(IRepository repo)
        {
            Repo = repo;
        }
        public IActionResult Index()
        {
            var books = Repo.GetBooks();
            return View(books);
        }
        public IActionResult Details(int id)
        {
            return View();
        }
    }
}
