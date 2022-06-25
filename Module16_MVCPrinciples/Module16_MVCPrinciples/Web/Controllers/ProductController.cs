using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using Services;

namespace Web.Controllers
{
    public class ProductController : Controller
    {
        private protected IProductService _productService;
        private protected ICategoryService _categoryService;
        private protected IConfiguration _configuration;


        public ProductController(IProductService productService, ICategoryService categoryService, IConfiguration configuration)
        {
            _productService = productService;
            _categoryService = categoryService;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ProductList(int pageIndex)
        {
            int pageSize = Int32.Parse(_configuration.GetSection("PageSize").Value);
            var products = _productService.GetAll(pageSize, pageIndex);
            return View(products);
        }

        [HttpGet]
        public IActionResult AddNewProduct()
        {            
            var categoryNames = _categoryService.GetAllCategoryNames();
            ViewBag.CategoryNames = new SelectList(categoryNames);

            return View();
        }

        [HttpPost]
        public IActionResult AddNewProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                var categoty = _categoryService.GetByName(product.Category.CategoryName);
                product.CategoryID = categoty.CategoryID;
                product.Category = categoty;
                _productService.Create(product);

                return View("ProductList");
            }
            else
            {
                var categoryNames = _categoryService.GetAllCategoryNames();
                ViewBag.CategoryNames = new SelectList(categoryNames);
                return View();
            }
        }

        [HttpGet]
        public IActionResult Update(int productId)
        {
            var product = _productService.GetById(productId);
            var categoryNames= _categoryService.GetAllCategoryNames();            
            ViewBag.CategoryNames = new SelectList(categoryNames);

            return View(product);
        }

        [HttpPost]
        public IActionResult Update(Product product)
        {
            if (ModelState.IsValid)
            {
                var categoty = _categoryService.GetByName(product.Category.CategoryName);
                product.CategoryID = categoty.CategoryID;
                product.Category = categoty;
                _productService.Update(product);
                return View("ProductList");
            }
            return View(product);
        }

        public JsonResult RemoveProduct(int productId)
        {
            return Json(_productService.Delete(productId));
        }
    }
}
