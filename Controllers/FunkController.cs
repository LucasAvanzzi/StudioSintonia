using Microsoft.AspNetCore.Mvc;

namespace StudioSintoniaPreview.Controllers
{
    public class FunkController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
