using CoffeeShopMVC.DataAccess;
using Microsoft.AspNetCore.Mvc;
using CoffeeShopMVC.Models;

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

        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
            var itemId = item.Id;

            return RedirectToAction("show", new {id = itemId});

        }

    }
}
