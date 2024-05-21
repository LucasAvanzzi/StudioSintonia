using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudioSintoniaPreview.Data;
using StudioSintoniaPreview.Entities;

namespace StudioSintoniaPreview.Controllers
{
    [Authorize]
    public class UsuarioLoginsController : Controller
    {
        private readonly BancoContext _context;

        public UsuarioLoginsController(BancoContext context)
        {
            _context = context;
        }

        // GET: UsuarioLogins
        public async Task<IActionResult> Index()
        {
            return View(await _context.UsuarioLogins.ToListAsync());
        }

        // GET: UsuarioLogins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioLogin = await _context.UsuarioLogins
                .FirstOrDefaultAsync(m => m.UsuarioLoginId == id);
            if (usuarioLogin == null)
            {
                return NotFound();
            }

            return View(usuarioLogin);
        }

        // GET: UsuarioLogins/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UsuarioLogins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UsuarioLoginId,UsuarioNome,UsuarioEmail,Celular")] UsuarioLogin usuarioLogin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuarioLogin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuarioLogin);
        }

        // GET: UsuarioLogins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioLogin = await _context.UsuarioLogins.FindAsync(id);
            if (usuarioLogin == null)
            {
                return NotFound();
            }
            return View(usuarioLogin);
        }

        // POST: UsuarioLogins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UsuarioLoginId,UsuarioNome,UsuarioEmail,Celular")] UsuarioLogin usuarioLogin)
        {
            if (id != usuarioLogin.UsuarioLoginId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuarioLogin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioLoginExists(usuarioLogin.UsuarioLoginId))
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
            return View(usuarioLogin);
        }

        // GET: UsuarioLogins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioLogin = await _context.UsuarioLogins
                .FirstOrDefaultAsync(m => m.UsuarioLoginId == id);
            if (usuarioLogin == null)
            {
                return NotFound();
            }

            return View(usuarioLogin);
        }

        // POST: UsuarioLogins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuarioLogin = await _context.UsuarioLogins.FindAsync(id);
            if (usuarioLogin != null)
            {
                _context.UsuarioLogins.Remove(usuarioLogin);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioLoginExists(int id)
        {
            return _context.UsuarioLogins.Any(e => e.UsuarioLoginId == id);
        }
    }
}
