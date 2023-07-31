using CoffeeShopMVC.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopMVC.Controllers
{
    public class ItemsController : Controller
    {
        public readonly CoffeeShopMVCContext _context;

        public ItemsController(CoffeeShopMVCContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var items = _context.Items.ToList();
            return View(items);
        }

        [Route("items/details/{id:int}")]
        public IActionResult Show(int id)
        {
            var item = _context.Items.Find(id);
            ViewData["PriceInDollars"] = item.PriceInCents / 100;

            return View(item);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var item = _context.Items.Find(id);
            _context.Items.Remove(item);
            _context.SaveChanges();

            return Redirect("/items");
        }
    }
}
