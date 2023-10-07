using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspNet_MVC_SPD115.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
