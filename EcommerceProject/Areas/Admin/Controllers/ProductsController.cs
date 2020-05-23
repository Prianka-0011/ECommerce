using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EcommerceProject.Data;
using EcommerceProject.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EcommerceProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private ApplicationDbContext _context;
        private IHostingEnvironment _hosting;

        public ProductsController(ApplicationDbContext context,IHostingEnvironment hosting)
        {
            _context = context;
            _hosting = hosting;

        }
        public IActionResult Index()
        {
            var product = _context.Products.Include(p=>p.ProductTypes).Include(s=>s.SpecialTag).ToList();
            return View(product);
        }
        //HttpGet for Product
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["ProductTypeId"] = new SelectList(_context.ProductTypes.ToList(), "Id", "Type"); //("For value","For Display")
            ViewData["SpecialTagId"] = new SelectList(_context.SpecialTag.ToList(), "Id", "TagName"); //("For value","For Display")
            return View();
        }

        //HttpPost for Product
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Create(Product product,IFormFile image)
        {
            if (ModelState.IsValid)
            {
                if(image!=null)
                {
                    var imgName = Path.Combine(_hosting.WebRootPath + "/Images", Path.GetFileName(image.FileName));
                    await image.CopyToAsync(new FileStream(imgName, FileMode.Create));
                    product.Image = "Images/" + image.FileName;
                    
                }

                if (image == null)
                {
                    product.Image = "Images/noimage.JPG";
                }


                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }
        //HttpGet For Edit 
        [HttpGet]
        public IActionResult Edit(int?id)
        {
            if(id==null)
            {
                return NotFound();
            }
            return View();
        }

    }
}