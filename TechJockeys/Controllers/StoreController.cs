using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TechJockeys.Models;

namespace TechJockeys.Controllers
{
    
    public class StoreController : Controller
    {
        private int categoryMaxNum;
        public IActionResult Index()
        {   
            // fetch category data (mock data today, from db later)
            var categories = new List<Category>();

            // create mock category list
            for (int i = 1; i < 11; i++)
            {
                categories.Add(new Category { CategoryId = i, Name = "Category " + i.ToString() });
                categoryMaxNum ++;
            }
            // error handle for ids that are higher then our max category id (10 in this case)
            //categoryMaxNum = categories.Count;

            // load view and pass the category list
            return View(categories);
        }

        public IActionResult ByCategory(int id)
        {
            // error handle if id missing => redirect to Store index so use can choose a category
            //|| id > categoryMaxNum
            if (id == 0 || id > 10)
            {
                return RedirectToAction("Index");
            }
            // use id param to find category
            // use ViewData dictionary to show selected category name in heading
            ViewData["Category"] = "Category " + id.ToString();
            return View();
        }
    }
}
