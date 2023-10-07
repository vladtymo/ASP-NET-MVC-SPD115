using AspNet_MVC_SPD115.Helpers;
using DataAccess.Data;
using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AspNet_MVC_SPD115.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly Shop115DbContext ctx;
        private string CurrentUserId => User.FindFirstValue(ClaimTypes.NameIdentifier);

        public OrdersController(Shop115DbContext ctx)
        {
            this.ctx = ctx;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            var ids = HttpContext.Session.Get<List<int>>(Constants.cartItemsKey) ?? new();
            var products = ctx.Products.Where(x => ids.Contains(x.Id)).ToList();

            var order = new Order()
            {
                Date = DateTime.Now,
                UserId = CurrentUserId,
                Products = products,
            };

            ctx.Orders.Add(order);
            ctx.SaveChanges();

            // clear cart items
            HttpContext.Session.Remove(Constants.cartItemsKey);

            return RedirectToAction("Index");
        }
    }
}
