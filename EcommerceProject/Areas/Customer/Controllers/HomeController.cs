using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EcommerceProject.Models;
using EcommerceProject.Data;
using Microsoft.EntityFrameworkCore;
using EcommerceProject.Utility;

namespace EcommerceProject.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
       
        ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var product = _context.Products.Include(p => p.ProductTypes).Include(s => s.SpecialTag).ToList();
            return View(product);
        }
        public IActionResult Details(int?id)
        {
            if (id==null)
            {
                return NotFound();

            }
            var product = _context.Products.Include(p => p.ProductTypes).FirstOrDefault(c => c.Id == id);
            if (product==null)
            {
                return NotFound();
            }
            return View(product);
        }
        //httpPost for add to card
        [HttpPost]
        [ActionName("Details")]
        public IActionResult AddToCard(int? id)
        {
            List<Product> products =new List<Product>();
            if (id == null)
            {
                return NotFound();

            }
            var product = _context.Products.Include(p => p.ProductTypes).FirstOrDefault(c => c.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            products = HttpContext.Session.Get<List<Product>>("products");
            if (products==null)
            {
                products = new List<Product>();
            }
            products.Add(product);
            HttpContext.Session.Set("products", products);///Here I make a sily mistake but that give me too much pain I do not send session object
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
