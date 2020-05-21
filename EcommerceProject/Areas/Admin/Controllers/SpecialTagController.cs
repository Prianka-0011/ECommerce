using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceProject.Data;
using EcommerceProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SpecialTagController : Controller
    {
       
        private ApplicationDbContext _context;
        public SpecialTagController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var specialTag = _context.SpecialTag.ToList();
            return View(specialTag);
        }
        //HttpGet for special tag
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        //HttpPos for special tag
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Create(SpecialTag specialTag)
        {
            if (ModelState.IsValid)
            {
                _context.SpecialTag.Add(specialTag);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(specialTag);
        }
        //HttpGet for Edit
        [HttpGet]
        public IActionResult Edit(int?id)
        {
            if (id==null)
            {
                return NotFound();
            }
            var specialTag = _context.SpecialTag.Find(id);
            if (specialTag==null)
            {
                return NotFound();
            }
            return View(specialTag);
        }
        //HttpGet For Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Edit(SpecialTag specialTag)
        {
            if (ModelState.IsValid)
            {
                _context.SpecialTag.Update(specialTag);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(specialTag);
        }
        //HttpGet for Details
        public IActionResult Details(int?id)
        {
            if (id==null)
            {
                return NotFound();
            }
            var specialTag = _context.SpecialTag.Find(id);
            if (specialTag==null)
            {
                return NotFound();
            }
            return View(specialTag);
        }
        [HttpGet]
        //HttpGet for Delete
        public IActionResult Delete(int?id)
        {
            if (id==null)
            {
                return NotFound();

            }
            var specialTag = _context.SpecialTag.Find(id);
            if (specialTag==null)
            {
                return NotFound();
            }
            return View(specialTag);
        }
        //HttpPost for Delete
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>ConfirmDelete(int id)
        {
            var specialTag = await _context.SpecialTag.FindAsync(id);
            _context.SpecialTag.Remove(specialTag);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}