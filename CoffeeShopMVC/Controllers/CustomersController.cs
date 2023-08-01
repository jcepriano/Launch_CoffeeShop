using Microsoft.AspNetCore.Mvc;
using CoffeeShopMVC.DataAccess;
using CoffeeShopMVC.Models;


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

            var customers = _context.Customers.ToList();
            return View(customers);

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
