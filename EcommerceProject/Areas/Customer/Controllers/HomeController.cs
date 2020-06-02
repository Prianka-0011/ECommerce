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
        //increase Quentity
        public IActionResult IncreaseQuentity(int? id)
        {
            List<CartItem> oldCart = new List<CartItem>();
            if (id == null)
            {
                return NotFound();

            }
            var product = _context.Products.Include(p => p.ProductTypes).FirstOrDefault(c => c.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            oldCart = HttpContext.Session.Get<List<CartItem>>("products");
            if (oldCart == null)
            {
                //oldCart = new List<CartItem>();
                List<CartItem> newcart = new List<CartItem>();
                var item = new CartItem();
                item.Quentity = 1;
                item.ProductId = product.Id;
                newcart.Add(item);
                HttpContext.Session.Set("products", newcart);
            }
            if (oldCart != null)
            {
                List<CartItem> newcart = new List<CartItem>();
                foreach (var item in oldCart)
                {
                    if (item.ProductId == product.Id)
                    {
                        // itemFound = true;
                        item.Quentity++;
                    }
                    newcart.Add(item);
                }
                HttpContext.Session.Set("products", newcart);
                return RedirectToAction("Details", product);
            }
            return RedirectToAction("Details", product);
        }
        //httpPost for add to card

        [HttpPost]
        [ActionName("Details")]
        public IActionResult AddToCard(int? id)
        {
            //bool itemFound=false;
            List<CartItem> oldCart =new List<CartItem>();
            if (id == null)
            {
                return NotFound();

            }
            var product = _context.Products.Include(p => p.ProductTypes).FirstOrDefault(c => c.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            oldCart = HttpContext.Session.Get<List<CartItem>>("products");
            if (oldCart==null)
            {
                //oldCart = new List<CartItem>();
                List<CartItem> newcart = new List<CartItem>();
                var item = new CartItem();
                item.Quentity = 1;
                item.ProductId = product.Id;
                newcart.Add(item);

            }
            if (oldCart != null)
            {
                List<CartItem> newcart = new List<CartItem>();
                foreach (var item in oldCart)
                {
                    newcart.Add(item);
                }
               
                HttpContext.Session.Set("products", newcart);
                return RedirectToAction(nameof(Index));

            }
            else
            {
                List<CartItem> newcart = new List<CartItem>();
                newcart.Add(new CartItem
                {
                    Quentity = 1,
                    ProductId = product.Id
                }); 
                HttpContext.Session.Set("products", newcart);
                return RedirectToAction(nameof(Index));
            }
            ///Here I make a sily mistake but that give me too much pain I do not send session object
        
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
