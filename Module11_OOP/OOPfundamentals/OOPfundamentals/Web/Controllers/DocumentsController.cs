using Microsoft.AspNetCore.Mvc;
using OOPfundamentals;
using OOPfundamentals.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class DocumentsController : Controller
    {
        private IRepository Repo;
        public DocumentsController(IRepository repo)
        {
            Repo = repo;
        }
        public IActionResult Index()
        {
            var books = Repo.GetDocuments();
            return View(books);
        }
        public IActionResult Details(int id)
        {          
            return View();
        }
    }
}
