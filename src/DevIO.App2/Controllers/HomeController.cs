using Microsoft.AspNetCore.Mvc;

namespace DevIO.App2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
