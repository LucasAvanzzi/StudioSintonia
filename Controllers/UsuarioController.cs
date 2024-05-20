using Microsoft.AspNetCore.Mvc;
using StudioSintoniaPreview.Models;
using StudioSintoniaPreview.Repositorio;

namespace StudioSintoniaPreview.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {
            _usuarioRepositorio.Adicionar(usuario);
            return RedirectToAction("Index", "HomeController");

        }
        public IActionResult CadastrarUsuario() 
        { 
            return View();
        }
    }
}
