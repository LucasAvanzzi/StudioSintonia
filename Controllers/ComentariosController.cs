﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudioSintoniaPreview.Data;
using StudioSintoniaPreview.Models;

namespace StudioSintoniaPreview.Controllers
{
    public class ComentariosController : Controller
    {
        private readonly BancoContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ComentariosController(BancoContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Comentarios
        public async Task<IActionResult> Index()
        {
            var usuario = await _userManager.GetUserAsync(User);
            var bancoContext = _context.Comentarios.Include(c => c.PostModel).Where(c => c.UsuarioModelId == usuario!.Id);
            return View(await bancoContext.ToListAsync());
        }

        // GET: Comentarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _userManager.GetUserAsync(User);
            var comentario = await _context.Comentarios
                .Include(c => c.PostModel)
                .Where(c => c.UsuarioModelId == usuario!.Id)
                .FirstOrDefaultAsync(m => m.ComentarioId == id);
            if (comentario == null)
            {
                return NotFound();
            }

            return View(comentario);
        }

        // GET: Comentarios/Create
        public IActionResult Create()
        {
           // ViewData["PostModelId"] = new SelectList(_context.Posts, "PostModelId", "PostModelId");
         // ViewData["UsuarioModelId"] = new SelectList(_context.Usuarios, "UsuarioModelId", "UsuarioModelId");
            return View();
        }

        // POST: Comentarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ComentarioId,UsuarioModelId,PostModelId,UsuarioNome")] Comentario comentario)
        {
            if (ModelState.IsValid)
            {
                var usuario = await _userManager.GetUserAsync(User);
                comentario.UsuarioModelId = usuario!.Id;
                _context.Add(comentario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
           // ViewData["PostModelId"] = new SelectList(_context.Posts, "PostModelId", "PostModelId", comentario.PostModelId);
           // ViewData["UsuarioModelId"] = new SelectList(_userManager, "UsuarioModelId", "UsuarioModelId", comentario.UsuarioModelId);
            return View(comentario);
        }

        // GET: Comentarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comentario = await _context.Comentarios.FindAsync(id);
            if (comentario == null)
            {
                return NotFound();
            }
           // ViewData["PostModelId"] = new SelectList(_context.Posts, "PostModelId", "PostModelId", comentario.PostModelId);
           // ViewData["UsuarioModelId"] = new SelectList(_context.Usuarios, "UsuarioModelId", "UsuarioModelId", comentario.UsuarioModelId);
            return View(comentario);
        }

        // POST: Comentarios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ComentarioId,UsuarioModelId,PostModelId,UsuarioNome")] Comentario comentario)
        {
            if (id != comentario.ComentarioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comentario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComentarioExists(comentario.ComentarioId))
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
            //ViewData["PostModelId"] = new SelectList(_context.Posts, "PostModelId", "PostModelId", comentario.PostModelId);
          //  ViewData["UsuarioModelId"] = new SelectList(_context.Usuarios, "UsuarioModelId", "UsuarioModelId", comentario.UsuarioModelId);
            return View(comentario);
        }

        // GET: Comentarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _userManager.GetUserAsync(User);
            var comentario = await _context.Comentarios
                .Include(c => c.PostModel)
                .Where(c => c.UsuarioModelId == usuario.Id)
                .FirstOrDefaultAsync(m => m.ComentarioId == id);
            if (comentario == null)
            {
                return NotFound();
            }

            return View(comentario);
        }

        // POST: Comentarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comentario = await _context.Comentarios.FindAsync(id);
            if (comentario != null)
            {
                _context.Comentarios.Remove(comentario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComentarioExists(int id)
        {
            return _context.Comentarios.Any(e => e.ComentarioId == id);
        }
    }
}
