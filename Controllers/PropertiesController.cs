using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Webapp.Data;
using Webapp.Models;

namespace Webapp.Controllers
{
    public class PropertiesController : Controller
    {
        private readonly PropertyDbContext _context;

        public PropertiesController(PropertyDbContext context)
        {
            _context = context;
        }


        // GET: Properties
        public async Task<IActionResult> Index()
        {
            return View(await _context.AgentTable.ToListAsync());
        }

        // GET: Properties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @property = await _context.AgentTable
                .FirstOrDefaultAsync(m => m.PropertyId == id);
            if (@property == null)
            {
                return NotFound();
            }

            return View(@property);
        }

    public async Task<IActionResult> Dashboard()
{
    var properties = await _context.AgentTable
        .ToListAsync();

    if (properties == null || !properties.Any())
    {
        return NotFound();
    }

    return View(properties);
}


        // GET: Properties/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Properties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PropertyId,Description,NumberOfBathrooms,NumberOfBedrooms,PropertyName,SquareFootage,ImageFile")] Property @property)
        {
             if (ModelState.IsValid)
            {
                if(@property.ImageFile != null && @property.ImageFile.Length > 0)
                {
                    using(var memoryStream = new MemoryStream())
                    {
                        await @property.ImageFile.CopyToAsync(memoryStream);
                        @property.ImageData = memoryStream.ToArray();
                    }
                }
                
                _context.Add(@property);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(@property);
        }

        // GET: Properties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @property = await _context.AgentTable.FindAsync(id);
            if (@property == null)
            {
                return NotFound();
            }
            return View(@property);
        }

        // POST: Properties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
       public async Task<IActionResult> Edit(int id, [Bind("PropertyId,Description,NumberOfBathrooms,NumberOfBedrooms,PropertyName,SquareFootage,ImageFile")] Property @property)
{
    if (id != @property.PropertyId)
    {
        return NotFound();
    }

    if (ModelState.IsValid)
    {
        try
        {
            // Check if a new image is provided
            if (@property.ImageFile != null && @property.ImageFile.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await @property.ImageFile.CopyToAsync(memoryStream);
                    @property.ImageData = memoryStream.ToArray();
                }
            }

            _context.Update(@property);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PropertyExists(@property.PropertyId))
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
    return View(@property);
}
        // GET: Properties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @property = await _context.AgentTable
                .FirstOrDefaultAsync(m => m.PropertyId == id);
            if (@property == null)
            {
                return NotFound();
            }

            return View(@property);
        }

        // POST: Properties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @property = await _context.AgentTable.FindAsync(id);
            if (@property != null)
            {
                _context.AgentTable.Remove(@property);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PropertyExists(int id)
        {
            return _context.AgentTable.Any(e => e.PropertyId == id);
        }
    }
}
