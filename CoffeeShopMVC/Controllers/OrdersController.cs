using Microsoft.AspNetCore.Mvc;
using CoffeeShopMVC.Models;
using CoffeeShopMVC.DataAccess;
using Microsoft.EntityFrameworkCore;



namespace CoffeeShopMVC.Controllers
{
    public class OrdersController : Controller
    {

        public readonly CoffeeShopMVCContext _context;

        public OrdersController(CoffeeShopMVCContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }
        
        [Route("customers/{customerId:int}/orders/{id:int}")]
        public IActionResult Show(int id)
        {
            var order = _context.Orders.Include(o => o.Customer).FirstOrDefault(o => o.Id == id);
            return View(order);
        }

        [Route("customers/{id:int}/orders/new")]
        public IActionResult New(int id)
        {
            var customerOrders = _context.Customers.Where(c => c.Id == id).Include(c => c.Orders);
            return View(customerOrders);
        }

        [HttpPost]
        [Route("customers/{id:int}/orders")]
        public IActionResult Create(Order order, int id)
        {
            var customerOrders = _context.Customers.Where(c => c.Id == id).Include(c => c.Orders).FirstOrDefault();
            customerOrders.Orders.Add(order);
            _context.SaveChanges();

            return RedirectToAction("show", new { id = customerOrders.Id});
        }
    }
}
