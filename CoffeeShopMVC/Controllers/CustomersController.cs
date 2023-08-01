using Microsoft.AspNetCore.Mvc;
using CoffeeShopMVC.DataAccess;
using CoffeeShopMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Razor.Hosting;

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

        [Route("customers/details/{id:int}")]
        public IActionResult Show(int id)
        {
            var customer = _context.Customers.Find(id);
            //list of all items for this customer
            ViewData["TotalOfOrders"] = customer.OrderTotal();
            ViewData["ListOfItems"] = customer.ItemList();
            return View(customer);
        }
    }
}
