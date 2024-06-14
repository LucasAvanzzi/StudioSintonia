using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudioSintoniaPreview.Data;
using StudioSintoniaPreview.Entities;
using StudioSintoniaPreview.Models;

namespace StudioSintoniaPreview.Controllers
{
    public class PostModelsController : Controller
    {
        private readonly BancoContext _context;
        private string caminhoServidor;
        private readonly UserManager<IdentityUser> _userManager;

        public PostModelsController(BancoContext context, IWebHostEnvironment Sistema, UserManager<IdentityUser> userManager)
        {
            _context = context;
            caminhoServidor = Sistema.WebRootPath;
            _userManager = userManager;
        }

        // GET: PostModels9
        public async Task<IActionResult> Index()
        {
            var usuario = await _userManager.GetUserAsync(User);
            var bancoContext = _context.Posts.Where(p => p.UsuarioModelId == usuario!.Id);
            return View(await bancoContext.ToListAsync());
        }

        [HttpPost]
        public JsonResult CurtiPost(int postId)
        {
            var post = _context.Posts.Find(postId);
            if (post != null)
            {
                
                post.Curtido = !post.Curtido; // Alterna o estado de curtida
                _context.Update(post);
                _context.SaveChanges();
                return Json(new { success = true, isLiked = post.Curtido });
            }
            return Json(new { success = false });
        }

        [HttpGet]
        public async Task<IActionResult> BuscarCurtidas()
        {
            var result =  _context.Posts.Where(p => p.Curtido == true);
            return View(result);
        }

        public async Task<IActionResult> Feed()
        {
            var bancoContext = await _context.Posts.ToListAsync();
            return View(bancoContext);
        }

        // GET: PostModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _userManager.GetUserAsync(User);
            var postModel = await _context.Posts
                .Where(p => p.UsuarioModelId == usuario!.Id)
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
                postModel.UsuarioModelId = userId;

                // Se o post tiver imagem, salvar na wwwroot e o nome do arquivo na prop "Conteudo"
                if (postModel.MetaDadosImagem is not null)
                {
                    string caminhoParaSalvarArquivo = Path.Combine(caminhoServidor, "arquivos");
                    string guid = Guid.NewGuid().ToString();
                    string novoNomeParaArquivo = $"{guid}_{postModel.MetaDadosImagem.FileName}";

                    if (!Directory.Exists(caminhoParaSalvarArquivo))
                    {
                        Directory.CreateDirectory(caminhoParaSalvarArquivo);
                    }

                    string caminhoCompleto = Path.Combine(caminhoParaSalvarArquivo, novoNomeParaArquivo);

                    using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
                    {
                        await postModel.MetaDadosImagem.CopyToAsync(stream);
                    }

                    postModel.Conteudo = novoNomeParaArquivo; // Salva o nome do arquivo com o GUID no banco
                }

                // Adiciona postagem no banco
                _context.Add(postModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // ViewData["UsuarioModelId"] = new SelectList(_context.Usuarios, "UsuarioModelId", "UsuarioModelId", postModel.UsuarioModelId);
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
            //ViewData["UsuarioModelId"] = new SelectList(_context.Usuarios, "UsuarioModelId", "UsuarioModelId", postModel.UsuarioModelId);
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
            // ViewData["UsuarioModelId"] = new SelectList(_context.Usuarios, "UsuarioModelId", "UsuarioModelId", postModel.UsuarioModelId);
            return View(postModel);
        }

        // GET: PostModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _userManager.GetUserAsync(User);
            var postModel = await _context.Posts
                .Where(p => p.UsuarioModelId == usuario.Id)
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
