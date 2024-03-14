using Microsoft.AspNetCore.Mvc;

namespace StudioSintoniaPreview.Controllers
{
    public class MusicasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
