using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Web.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
