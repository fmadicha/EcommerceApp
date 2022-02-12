using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EcommerceApp.Models.DBModels;

namespace EcommerceApp.Controllers
{
    public class ProductOptionsController : Controller
    {
        private readonly usersdbContext _context;

        public ProductOptionsController(usersdbContext context)
        {
            _context = context;
        }

        // GET: ProductOptions
        public async Task<IActionResult> Index()
        {
            var usersdbContext = _context.ProductOptions.Include(p => p.Option).Include(p => p.Product);
            return View(await usersdbContext.ToListAsync());
        }

        // GET: ProductOptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productOptions = await _context.ProductOptions
                .Include(p => p.Option)
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productOptions == null)
            {
                return NotFound();
            }

            return View(productOptions);
        }

        // GET: ProductOptions/Create
        public IActionResult Create()
        {
            ViewData["OptionId"] = new SelectList(_context.Options, "Id", "OptionName");
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id");
            return View();
        }

        // POST: ProductOptions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OptionId,ProductId")] ProductOptions productOptions)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productOptions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OptionId"] = new SelectList(_context.Options, "Id", "OptionName", productOptions.OptionId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", productOptions.ProductId);
            return View(productOptions);
        }

        // GET: ProductOptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productOptions = await _context.ProductOptions.FindAsync(id);
            if (productOptions == null)
            {
                return NotFound();
            }
            ViewData["OptionId"] = new SelectList(_context.Options, "Id", "OptionName", productOptions.OptionId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", productOptions.ProductId);
            return View(productOptions);
        }

        // POST: ProductOptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OptionId,ProductId")] ProductOptions productOptions)
        {
            if (id != productOptions.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productOptions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductOptionsExists(productOptions.Id))
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
            ViewData["OptionId"] = new SelectList(_context.Options, "Id", "OptionName", productOptions.OptionId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", productOptions.ProductId);
            return View(productOptions);
        }

        // GET: ProductOptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productOptions = await _context.ProductOptions
                .Include(p => p.Option)
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productOptions == null)
            {
                return NotFound();
            }

            return View(productOptions);
        }

        // POST: ProductOptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productOptions = await _context.ProductOptions.FindAsync(id);
            _context.ProductOptions.Remove(productOptions);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductOptionsExists(int id)
        {
            return _context.ProductOptions.Any(e => e.Id == id);
        }
    }
}
