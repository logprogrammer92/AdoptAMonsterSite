using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using AdoptAMonsterSite.Data;
using AdoptAMonsterSite.Models;

namespace AdoptAMonsterSite.Controllers
{
    public class MonstersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public MonstersController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: Monsters
        public async Task<IActionResult> Index()
        {
            return View(await _context.Monsters.ToListAsync());
        }

        // GET: Monsters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monster = await _context.Monsters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (monster == null)
            {
                return NotFound();
            }

            return View(monster);
        }

        // GET: Monsters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Monsters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Species,Description,AdoptionFee,ImageFileName")] Monster monster, IFormFile? ImageFile)
        {
            if (ModelState.IsValid)
            {

                if (ImageFile != null && ImageFile.Length > 0)
                {
                    // Ensure images folder exists under wwwroot
                    var imagesFolder = Path.Combine(_env.WebRootPath ?? "wwwroot", "images");
                    Directory.CreateDirectory(imagesFolder);

                    // Build a safe file name that includes a GUID
                    var ext = Path.GetExtension(ImageFile.FileName);
                    var baseName = Path.GetFileNameWithoutExtension(ImageFile.FileName);
                    var guidName = $"{baseName}_{Guid.NewGuid():N}{ext}";

                    var filePath = Path.Combine(imagesFolder, guidName);

                    // Save the file
                    await using (var stream = System.IO.File.Create(filePath))
                    {
                        await ImageFile.CopyToAsync(stream);
                    }

                    // Store the generated file name on the model
                    monster.ImageFileName = guidName;
                }

                _context.Add(monster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(monster);
        }

        // GET: Monsters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monster = await _context.Monsters.FindAsync(id);
            if (monster == null)
            {
                return NotFound();
            }
            return View(monster);
        }

        // POST: Monsters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Species,Description,AdoptionFee")] Monster monster)
        {
            if (id != monster.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(monster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonsterExists(monster.Id))
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
            return View(monster);
        }

        // GET: Monsters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monster = await _context.Monsters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (monster == null)
            {
                return NotFound();
            }

            return View(monster);
        }

        // POST: Monsters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var monster = await _context.Monsters.FindAsync(id);
            if (monster != null)
            {
                _context.Monsters.Remove(monster);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MonsterExists(int id)
        {
            return _context.Monsters.Any(e => e.Id == id);
        }
    }
}
