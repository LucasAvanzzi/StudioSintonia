using Microsoft.AspNetCore.Mvc;

namespace StudioSintoniaPreview.Controllers
{
    public class ArtesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
