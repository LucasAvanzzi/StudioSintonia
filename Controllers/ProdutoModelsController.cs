﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudioSintoniaPreview.Data;
using StudioSintoniaPreview.Models;

namespace StudioSintoniaPreview.Controllers
{
    public class ProdutoModelsController : Controller
    {
        private readonly BancoContext _context;

        public ProdutoModelsController(BancoContext context)
        {
            _context = context;
        }

        // GET: ProdutoModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Produto.ToListAsync());
        }

        // GET: ProdutoModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtoModel = await _context.Produto
                .FirstOrDefaultAsync(m => m.ProdutoModelId == id);
            if (produtoModel == null)
            {
                return NotFound();
            }

            return View(produtoModel);
        }

        // GET: ProdutoModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProdutoModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProdutoModelId,DescricaoId,Valor,Coments,Likes")] ProdutoModel produtoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produtoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produtoModel);
        }

        // GET: ProdutoModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtoModel = await _context.Produto.FindAsync(id);
            if (produtoModel == null)
            {
                return NotFound();
            }
            return View(produtoModel);
        }

        // POST: ProdutoModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProdutoModelId,DescricaoId,Valor,Coments,Likes")] ProdutoModel produtoModel)
        {
            if (id != produtoModel.ProdutoModelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produtoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoModelExists(produtoModel.ProdutoModelId))
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
            return View(produtoModel);
        }

        // GET: ProdutoModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtoModel = await _context.Produto
                .FirstOrDefaultAsync(m => m.ProdutoModelId == id);
            if (produtoModel == null)
            {
                return NotFound();
            }

            return View(produtoModel);
        }

        // POST: ProdutoModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produtoModel = await _context.Produto.FindAsync(id);
            if (produtoModel != null)
            {
                _context.Produto.Remove(produtoModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoModelExists(int id)
        {
            return _context.Produto.Any(e => e.ProdutoModelId == id);
        }
    }
}
