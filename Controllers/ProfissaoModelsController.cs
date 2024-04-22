using System;
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
    public class ProfissaoModelsController : Controller
    {
        private readonly BancoContext _context;

        public ProfissaoModelsController(BancoContext context)
        {
            _context = context;
        }

        // GET: ProfissaoModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProfissaoModels.ToListAsync());
        }

        // GET: ProfissaoModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profissaoModel = await _context.ProfissaoModels
                .FirstOrDefaultAsync(m => m.ProfissaoModelId == id);
            if (profissaoModel == null)
            {
                return NotFound();
            }

            return View(profissaoModel);
        }

        // GET: ProfissaoModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProfissaoModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProfissaoModelId,ProfissaoNome")] ProfissaoModel profissaoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(profissaoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(profissaoModel);
        }

        // GET: ProfissaoModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profissaoModel = await _context.ProfissaoModels.FindAsync(id);
            if (profissaoModel == null)
            {
                return NotFound();
            }
            return View(profissaoModel);
        }

        // POST: ProfissaoModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProfissaoModelId,ProfissaoNome")] ProfissaoModel profissaoModel)
        {
            if (id != profissaoModel.ProfissaoModelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profissaoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfissaoModelExists(profissaoModel.ProfissaoModelId))
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
            return View(profissaoModel);
        }

        // GET: ProfissaoModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profissaoModel = await _context.ProfissaoModels
                .FirstOrDefaultAsync(m => m.ProfissaoModelId == id);
            if (profissaoModel == null)
            {
                return NotFound();
            }

            return View(profissaoModel);
        }

        // POST: ProfissaoModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var profissaoModel = await _context.ProfissaoModels.FindAsync(id);
            if (profissaoModel != null)
            {
                _context.ProfissaoModels.Remove(profissaoModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfissaoModelExists(int id)
        {
            return _context.ProfissaoModels.Any(e => e.ProfissaoModelId == id);
        }
    }
}
