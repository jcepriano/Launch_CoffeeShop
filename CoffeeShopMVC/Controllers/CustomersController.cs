using Microsoft.AspNetCore.Mvc;
using CoffeeShopMVC.Models;
using CoffeeShopMVC.DataAccess;

namespace CoffeeShopMVC.Controllers
{
    public class CustomersController : Controller
    {
        private readonly CoffeeShopMVCContext _context;

        public CustomersController(CoffeeShopMVCContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();

            //var customerId = customer.Id;

            return RedirectToAction("index");
        }
    }
}
