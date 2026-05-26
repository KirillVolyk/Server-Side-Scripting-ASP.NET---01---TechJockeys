using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;
using TechJockeys.Data;
using TechJockeys.Data.Migrations;
using TechJockeys.Models;

namespace TechJockeys.Controllers
{
    public class CategoriesController : Controller
    {
        // Shared db conn available to all controller methods
        private readonly ApplicationDbContext _context;

        public CategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // create empty Category list so view doesnt crash OLD
            // Fetch Category list from db using DbSet object
            var categories = _context.Category.ToList();

            return View(categories);
        }

        // GET: /Categories/Create => show empty Category form
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Categories/Create => process form submission to create new Category
        [HttpPost]
        public IActionResult Create([Bind("Name")] Category category)
        {
            // Validate the intput
            if (!ModelState.IsValid)
            {
                return View();
            }

            // Create new category & save to db
            _context.Category.Add(category);
            _context.SaveChanges();

            // Redirect to index page to see updated list of Categories
            return RedirectToAction("Index");
        }

        // GET: /Categories/Edit/5 => fetch & display selected category
        public IActionResult Edit(int id)
        {
            // fetch category by id
            var category = _context.Category.Find(id);

            if (category == null)
            {
                //return RedirectToAction("Index");
                return NotFound();
            }

            // pass selected category to view for display in the form
            return View(category);
        }

        // POST: /Categories/Edit/5 => update selected categpry frpm form submission
        [HttpPost]
        public IActionResult Edit([Bind("CategoryId, Name")] Category category)
        {
            // Validate form input
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            // Update the db
            _context.Category.Update(category);
            // Save the changes
            _context.SaveChanges();

            // Redirect to list
            return RedirectToAction("Index");
        }

        // GET: /Categories/Delete/5 => delete selected category
        public IActionResult Delete(int id)
        {
            // Find Category to delete
            var category = _context.Category.Find(id);
            
            if (category == null)
            {
                //return RedirectToAction("Index");
                return NotFound();
            }

            // IF found, delete it from db
            _context.Category.Remove(category);
            // Save the changes
            _context.SaveChanges();

            // Refresh list
            return RedirectToAction("Index");
        }
    }
}
