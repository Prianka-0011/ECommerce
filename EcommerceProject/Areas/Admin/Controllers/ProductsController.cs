﻿using System;
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
        public async Task< IActionResult> Index(int? searchTypeId,int page)
        {
            IQueryable<Product> product= _context.Products.Include(p => p.ProductTypes).Include(s => s.SpecialTag);
            ViewBag.count = product.Count();
            ViewData["ProductTypeId"] = new SelectList(_context.ProductTypes.ToList(), "Id", "Type");
            ViewBag.searchTypeId = searchTypeId;
            if (searchTypeId != null)
            {
                product = _context.Products.Include(p => p.ProductTypes).Include(s => s.SpecialTag).Where(c => c.ProductTypes.Id == searchTypeId);
                ViewData["ProductTypeId"] = new SelectList(_context.ProductTypes.ToList(), "Id", "Type");
               
            }
            ViewBag.count = product.Count();
            if (page<=0)
            {
                page = 1;
            }
                
            
            int pageSize = 3;
            return View(await PaginatedList<Product>.CreateAsync(product,page,pageSize));
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
                var searchProduct = await _context.Products.FirstOrDefaultAsync(p => p.Name == product.Name);
                if (searchProduct!=null)
                {
                    TempData["msg"] = "This Product All Ready Exit";
                    ViewData["ProductTypeId"] = new SelectList(_context.ProductTypes.ToList(), "Id", "Type"); //("For value","For Display")
                    ViewData["SpecialTagId"] = new SelectList(_context.SpecialTag.ToList(), "Id", "TagName"); //("For value","For Display")
                    return View(product);
                }
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
                TempData["create"] = "This Product successfuly create";
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }
        //HttpGet For Edit 
        [HttpGet]
        public IActionResult Edit(int?id)
        {
            ViewData["ProductTypeId"] = new SelectList(_context.ProductTypes.ToList(), "Id", "Type"); //("For value","For Display")
            ViewData["SpecialTagId"] = new SelectList(_context.SpecialTag.ToList(), "Id", "TagName"); //("For value","For Display")
            if (id==null)
            {
                return NotFound();
            }
            var product = _context.Products.Include(p => p.ProductTypes).Include(s => s.SpecialTag).FirstOrDefault(f => f.Id == id);
          
            if (product==null)
            {
                return NotFound();
            }
            return View(product);
        }
        //HttpPost for Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Edit(int id, Product productVm,IFormFile image)
        {
            if (id!= productVm.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var searchProduct = await _context.Products.FirstOrDefaultAsync(p => p.Name == productVm.Name && p.Id!=productVm.Id);
                if (searchProduct != null)
                {
                    TempData["msg"] = "This Product All Ready Exit";
                    ViewData["ProductTypeId"] = new SelectList(_context.ProductTypes.ToList(), "Id", "Type"); //("For value","For Display")
                    ViewData["SpecialTagId"] = new SelectList(_context.SpecialTag.ToList(), "Id", "TagName"); //("For value","For Display")
                    if (image==null)
                    {
                        var img = await _context.Products.FirstOrDefaultAsync(c => c.Id == productVm.Id);
                        productVm.Image = img.Image;
                    }
                    return View(productVm);
                }
                if (image != null)
                {
                    var imgnName = Path.Combine(_hosting.WebRootPath + "/Images", Path.GetFileName(image.FileName));
                    await image.CopyToAsync(new FileStream(imgnName, FileMode.Create));
                    productVm.Image = "Images/" + image.FileName;
                }
                if (image == null)
                {
                    var products = _context.Products.Find(productVm.Id);

                    products.Name = productVm.Name;
                    products.Price = productVm.Price;
                    products.ProductColor = productVm.ProductColor;
                    products.IsAviable = productVm.IsAviable;
                    products.ProductTypes = productVm.ProductTypes;
                    products.SpecialTag = productVm.SpecialTag;
                    _context.Products.Update(products);
                    await _context.SaveChangesAsync();
                    TempData["update"] = "This Product successfuly update";
                    return RedirectToAction(nameof(Index));

                }
                _context.Products.Update(productVm);
                await _context.SaveChangesAsync();
                TempData["update"] = "This Product successfuly update";
                return RedirectToAction(nameof(Index));
            }
            return View(productVm);
           
        }
        //HttpGet For Details
        [HttpGet]
        public IActionResult Details(int?id)
        {
           
            if (id==null)
            {
                return NotFound();
            }

            var product = _context.Products.Include(p=>p.ProductTypes).Include(s=>s.SpecialTag).FirstOrDefault(c=>c.Id==id);
            if (product==null)
            {
                return NotFound();
            }
            
            return View(product);
        }
        //HttpGet For Delete
        [HttpGet]
        public IActionResult Delete(int?id)
        {
            if (id==null)
            {
                return NotFound();
            }
            var product = _context.Products.Include(p => p.ProductTypes).Include(s => s.SpecialTag).FirstOrDefault(f=>f.Id==id);
            if (product==null)
            {
                return NotFound();
            }
            return View(product);
        }
        //HttpPost For Delete
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>ConfirmDelete(int id)
        {
            var product =await  _context.Products.FindAsync(id);
                 _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            TempData["delete"] = "This Product successfuly delete";
            return RedirectToAction(nameof(Index));
        }

    }
}