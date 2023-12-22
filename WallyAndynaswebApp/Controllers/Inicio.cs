using Microsoft.AspNetCore.Mvc;

namespace WallyAndynaswebApp.Controllers
{
    public class Inicio : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
