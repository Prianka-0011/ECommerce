﻿using System;
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
                _context.ProductTypes.Add(productTypes);
                await _context.SaveChangesAsync();
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
            return View(productType);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //HttpPost post Action
        public async Task<IActionResult>Edit(ProductTypes productTypes)
        {
            if (productTypes!=null)
            {
                _context.ProductTypes.Update(productTypes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(productTypes);
        }

    }
}