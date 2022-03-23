using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AutoPlus.Data;
using AutoPlus.Entities;
using Microsoft.AspNetCore.Authorization;

namespace AutoPlus.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ModelBrandsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ModelBrandsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/ModelBrands
        public async Task<IActionResult> Index(int Idbrand)
        {
            List<ModelBrands> list = await (from catItem in _context.ModelBrands
                                            where
       catItem.IdBrand == Idbrand
                                            select new ModelBrands
                                            {
                                                Id = catItem.Id,
                                                IdBrand = Idbrand,
                                                Model = catItem.Model,
                                                ModelTypes = catItem.ModelTypes
                                            }
                                            ).ToListAsync();


            ViewBag.IdBrand = Idbrand;
            return View(list);
        }

            // GET: Admin/ModelBrands/Details/5
            public async Task<IActionResult> Details(int? id)
            {
            if (id == null)
            {
                return NotFound();
            }

            var modelBrands = await _context.ModelBrands
                .FirstOrDefaultAsync(m => m.Id == id);
            if (modelBrands == null)
            {
                return NotFound();
            }

            return View(modelBrands);
           }

        // GET: Admin/ModelBrands/Create
        public IActionResult Create(int Idbrand)
        {
            ModelBrands modelBrands = new ModelBrands
            {
                IdBrand = Idbrand
            };
            return View(modelBrands);
        }

        // POST: Admin/ModelBrands/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdBrand,Model")] ModelBrands modelBrands)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modelBrands);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index),new {Idbrand = modelBrands.IdBrand});
            }
            return View(modelBrands);
        }

        // GET: Admin/ModelBrands/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modelBrands = await _context.ModelBrands.FindAsync(id);
            if (modelBrands == null)
            {
                return NotFound();
            }
            return View(modelBrands);
        }

        // POST: Admin/ModelBrands/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdBrand,Model")] ModelBrands modelBrands)
        {
            if (id != modelBrands.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modelBrands);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModelBrandsExists(modelBrands.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { Idbrand = modelBrands.IdBrand });
            }
            return View(modelBrands);
        }

        // GET: Admin/ModelBrands/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modelBrands = await _context.ModelBrands
                .FirstOrDefaultAsync(m => m.Id == id);
            if (modelBrands == null)
            {
                return NotFound();
            }

            return View(modelBrands);
        }

        // POST: Admin/ModelBrands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var modelBrands = await _context.ModelBrands.FindAsync(id);
            _context.ModelBrands.Remove(modelBrands);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { Idbrand = modelBrands.IdBrand });
        }

        private bool ModelBrandsExists(int id)
        {
            return _context.ModelBrands.Any(e => e.Id == id);
        }
    }
}
