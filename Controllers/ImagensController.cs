using Microsoft.AspNetCore.Mvc;

namespace StudioSintoniaPreview.Controllers
{
    public class ImagensController : Controller
    {
        private string caminhoServidor;

        public ImagensController(IWebHostEnvironment Sistema)
        {
            caminhoServidor = Sistema.WebRootPath;
        }

        public IActionResult UploadImagem()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UploadImagem(IFormFile arquivo)
        {
            string caminhoParaSalvarArquivo = caminhoServidor + "\\arquivos\\";
            string novoNomeParaArquivo = Guid.NewGuid().ToString() + "_" +  arquivo.FileName;
            if ( ! Directory.Exists(caminhoParaSalvarArquivo))
            {
                Directory.CreateDirectory(caminhoParaSalvarArquivo);
            }
            using (var stream = System.IO.File.Create(caminhoParaSalvarArquivo + novoNomeParaArquivo)) 
            {
                arquivo.CopyToAsync(stream);
            }
            return RedirectToAction("UploadImagem");
        }
    }
}
