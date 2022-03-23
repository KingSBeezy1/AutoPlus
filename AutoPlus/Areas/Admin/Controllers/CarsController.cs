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
    public class CarsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Cars
        public async Task<IActionResult> Index(int IdbrandModel)
        {
            List<Car> list = await (from catItem in _context.Category
                                            where
       catItem.IdBrandModel == IdbrandModel
                                            select new Car
                                            {
                                                Id = catItem.Id,
                                                IdBrandModel = IdbrandModel,
                                                Description = catItem.Description,
                                                Color = catItem.Color,
                                                YearProduction = catItem.YearProduction,
                                                Condition = catItem.Condition,
                                                Injection = catItem.Injection,
                                                HorsePowers = catItem.HorsePowers,
                                                ThumbnailImagePath = catItem.ThumbnailImagePath,
                                                Price = catItem.Price
                                            }
                                            ).ToListAsync();


            ViewBag.IdBrandModel = IdbrandModel;
            return View(list);
        }

        // GET: Admin/Cars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Category
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // GET: Admin/Cars/Create
        public IActionResult Create(int IdbrandModel)
        {
            Car car = new Car
            {
                 IdBrandModel = IdbrandModel
            };
            return View(car);
            
        }

        // POST: Admin/Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,IdBrandModel,YearProduction,Color,Price,Condition,Injection,HorsePowers,ThumbnailImagePath")] Car car)
        {
            if (ModelState.IsValid)
            {
                _context.Add(car);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { IdbrandModel = car.IdBrandModel });
            }
            return View(car);
        }

        // GET: Admin/Cars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Category.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        // POST: Admin/Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,IdBrandModel,YearProduction,Color,Price,Condition,Injection,HorsePowers,ThumbnailImagePath")] Car car)
        {
            if (id != car.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(car);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(car.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { IdbrandModel = car.IdBrandModel });
            }
            return View(car);
        }

        // GET: Admin/Cars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Category
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: Admin/Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var car = await _context.Category.FindAsync(id);
            _context.Category.Remove(car);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { IdbrandModel = car.IdBrandModel });
        }

        private bool CarExists(int id)
        {
            return _context.Category.Any(e => e.Id == id);
        }
    }
}
