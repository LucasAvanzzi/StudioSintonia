using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudioSintoniaPreview.Data;
using StudioSintoniaPreview.Models;

namespace StudioSintoniaPreview.Controllers
{
    public class PostModelsController : Controller
    {
        private readonly BancoContext _context;
        private string caminhoServidor;


        public PostModelsController(BancoContext context, IWebHostEnvironment Sistema)
        {
            _context = context;
            caminhoServidor = Sistema.WebRootPath;
        }

        // GET: PostModels
        public async Task<IActionResult> Index()
        {
            var bancoContext = _context.Posts.Include(p => p.UsuarioModel);
            return View(await bancoContext.ToListAsync());
        }

        // GET: PostModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postModel = await _context.Posts
                .Include(p => p.UsuarioModel)
                .FirstOrDefaultAsync(m => m.PostModelId == id);
            if (postModel == null)
            {
                return NotFound();
            }

            return View(postModel);
        }

        // GET: PostModels/Create
        public IActionResult Create()
        {
            ViewData["UsuarioModelId"] = new SelectList(_context.Usuarios, "UsuarioModelId", "UsuarioModelId");
            return View();
        }

        // POST: PostModels/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PostModel postModel)
        {
            if (ModelState.IsValid)
            {
                // Pega ID do usuário logado
                var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
                //postModel.UsuarioModelId = userId; Descomentar assim que alterar userId pra Guid

                // Se o post tiver imagem, salvar na wwwroot e o nome do arquivo na prop "Conteudo"
                if (postModel.MetaDadosImagem is not null)
                {
                    string caminhoParaSalvarArquivo = caminhoServidor + "\\arquivos\\";
                    string novoNomeParaArquivo = Guid.NewGuid().ToString() + "_" + postModel.MetaDadosImagem.FileName;
                    if (!Directory.Exists(caminhoParaSalvarArquivo))
                    {
                        Directory.CreateDirectory(caminhoParaSalvarArquivo);
                    }
                    using (var stream = System.IO.File.Create(caminhoParaSalvarArquivo + novoNomeParaArquivo))
                    {
                       await postModel!.MetaDadosImagem.CopyToAsync(stream);
                    }
                    postModel.Conteudo = postModel.MetaDadosImagem.FileName;
                }

                // Adiciona postagem no banco
                _context.Add(postModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioModelId"] = new SelectList(_context.Usuarios, "UsuarioModelId", "UsuarioModelId", postModel.UsuarioModelId);
            return View(postModel);
        }


        // GET: PostModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postModel = await _context.Posts.FindAsync(id);
            if (postModel == null)
            {
                return NotFound();
            }
            ViewData["UsuarioModelId"] = new SelectList(_context.Usuarios, "UsuarioModelId", "UsuarioModelId", postModel.UsuarioModelId);
            return View(postModel);
        }

        // POST: PostModels/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PostModelId,TagId,UsuarioModelId,Conteudo,Descricao,Curtidas,Valor")] PostModel postModel)
        {
            if (id != postModel.PostModelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(postModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostModelExists(postModel.PostModelId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioModelId"] = new SelectList(_context.Usuarios, "UsuarioModelId", "UsuarioModelId", postModel.UsuarioModelId);
            return View(postModel);
        }

        // GET: PostModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postModel = await _context.Posts
                .Include(p => p.UsuarioModel)
                .FirstOrDefaultAsync(m => m.PostModelId == id);
            if (postModel == null)
            {
                return NotFound();
            }

            return View(postModel);
        }

        // POST: PostModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var postModel = await _context.Posts.FindAsync(id);
            if (postModel != null)
            {
                _context.Posts.Remove(postModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostModelExists(int id)
        {
            return _context.Posts.Any(e => e.PostModelId == id);
        }
    }
}
