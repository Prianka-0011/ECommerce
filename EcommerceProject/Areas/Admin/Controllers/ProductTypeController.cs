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
    public class ProductTypeController : Controller
    {
        private ApplicationDbContext _context;
        public ProductTypeController( ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            //var productList = _context.ProductTypes.ToList();
            return View(_context.ProductTypes.ToList());
        }
        //for create product type
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Create(ProductTypes productTypes)
        {
            if(ModelState.IsValid)
            {
                var searchType = _context.ProductTypes.FirstOrDefault(p => p.Type == productTypes.Type && p.Id!=productTypes.Id);
                if (searchType!=null)
                {
                    TempData["msg"]= "This Type Already Exist";
                    return View(productTypes);
                }
                _context.ProductTypes.Add(productTypes);
                await _context.SaveChangesAsync();
                TempData["create"] = "Product has been successfully created";
                return RedirectToAction(nameof(Index));
            }
            return View(productTypes);
        }
        //HttpGet* Edit Action
        [HttpGet]
        public IActionResult Edit(int?id)
        {
            if(id==null)
            {

                return NotFound();
            }
            var productType = _context.ProductTypes.Find(id);
            if (productType==null)
            {
                return NotFound();
            }
            return View(productType);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //HttpPost post Action
        public async Task<IActionResult>Edit(int id,ProductTypes productTypes)
        {
            if (id!=productTypes.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.ProductTypes.Update(productTypes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(productTypes);
        }
        ///HttpGet for Details
        [HttpGet]
        public async Task<IActionResult>Details(int?id)
        {
            if (id==null)
            {
                return NotFound();
            }
            var productType = await _context.ProductTypes.FindAsync(id);
            if(productType==null)
            {
                return NotFound();
            }
            return View(productType);
        }
        //HttpGet for Delete mathod
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }
            var productType = _context.ProductTypes.Find(id);
            if (productType==null)
            {
                return NotFound();
            }
            return View(productType);
        }
        //HttpPost Method for delete
        [HttpPost ,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>DeleteConfirmed(int id)
        {
            var productType = await _context.ProductTypes.FindAsync(id);
            _context.ProductTypes.Remove(productType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        

    }
}