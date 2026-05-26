using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TechJockeys.Data;
using TechJockeys.Models;

namespace TechJockeys.Controllers
{
    public class ProductsController : Controller
    {
        // Shared db obj
        private readonly ApplicationDbContext _context;

        // Construcotr w/db dependency
        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            // Product list to pass for display in view OLD
            // Fetch Product list from db using DbSet object, include Category data for display in view
            var products = _context.Product.ToList();
            return View(products);
        }

        // GET: /Products/Create => show empty Product form including Category list dropdown
        public IActionResult Create()
        {
            // Fetch Categories for dropdown, orderend a-z by Name
            ViewBag.CategoryId = new SelectList(_context.Category.OrderBy(c => c.Name), "CategoryId", "Name");
            return View();
        }

        // POST: /Products/Create => save new product form data
        [HttpPost]
        public IActionResult Create([Bind("Name, Price, Stock, Description, Image, CategoryId")] Product product)
        {
            // Validate
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            // Create & save
            _context.Product.Add(product);
            _context.SaveChanges();

            // Redirect to list
            return RedirectToAction("Index");
        }

        public IActionResult Edit()
        {
            return View();
        }
    }
}
