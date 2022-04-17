using Microsoft.AspNetCore.Mvc;

namespace StoreYx.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
