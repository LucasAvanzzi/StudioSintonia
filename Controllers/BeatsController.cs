using Microsoft.AspNetCore.Mvc;

namespace StudioSintoniaPreview.Controllers
{
    public class BeatsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
