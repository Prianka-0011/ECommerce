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
using EcommerceProject.ViewModels;

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
        //Http get for cart
        [HttpGet]
        public IActionResult Cart()
        {
            List<CartItem> cart = new List<CartItem>();
            List<CartVm> cartVm = new List<CartVm>();
            cart = HttpContext.Session.Get<List<CartItem>>("products");
            if (cart==null)
            {
                return RedirectToAction("Index");
            }
            foreach (var item in cart)
            {
                var product = _context.Products.Include(p => p.ProductTypes).FirstOrDefault(c => c.Id == item.ProductId);
                var newCartVm = new CartVm();
                newCartVm.ProductId = item.ProductId;
                newCartVm.Name = product.Name;
                newCartVm.Price = product.Price; ;
                newCartVm.ProductColor = product.ProductColor;
                newCartVm.Type = product.ProductTypes.Type;
                newCartVm.Quantity = item.Quentity;
                newCartVm.Image = product.Image;
                cartVm.Add(newCartVm);
            }

            return View(cartVm);
        }
        //HttpGet For Remove
        public IActionResult Remove(int?id)
        {
            if (id==null)
            {
                return NotFound();
            }
            List<CartItem> oldCart = HttpContext.Session.Get<List<CartItem>>("products");
            if (oldCart!=null)
            {
                var product = oldCart.FirstOrDefault(c => c.ProductId == id);
                if (product!=null)
                {
                    oldCart.Remove(product);
                    HttpContext.Session.Set("products", oldCart);
                    return RedirectToAction("cart");
                }
            }
            return RedirectToAction("cart");
        }
        //Http GetFor Details
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var product = _context.Products.Include(p => p.ProductTypes).FirstOrDefault(c => c.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        //httpPost for add to card
        // return RedirectToAction("Details", product);
        [HttpPost]
        [ActionName("Details")]
        public IActionResult AddToCard(int? id)
        {
            bool itemFound=false;
           List<CartItem> oldCart =new List<CartItem>();
            List<CartItem> oldCart1 =new List<CartItem>();
            List<CartItem> nullSession =new List<CartItem>();
            if (id == null)
            {
                return NotFound();

            }
            var product = _context.Products.Include(p => p.ProductTypes).FirstOrDefault(c => c.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            oldCart = HttpContext.Session.Get<List<CartItem>>("incproducts");
            oldCart1 = HttpContext.Session.Get<List<CartItem>>("products");
            int count = 0;
            int count1 = 0;
            if ( oldCart1!=null)
            {
               //Can not set null in session if i initialize
                count1= oldCart1.Count();
            }
            if (oldCart!=null)
            {
                count = oldCart.Count();
            }
            if(count ==0 && count1>0)
            {
                // bool itemFound = false;
                List<CartItem> newcart = new List<CartItem>();

                foreach (var item in oldCart1)
                {
                    if (item.ProductId == product.Id)
                    {
                        itemFound = true;
                        item.Quentity++;
                    }
                    newcart.Add(item);
                }
                if (itemFound == false)
                {
                    var item1 = new CartItem();
                    item1.Quentity = 1;
                    item1.ProductId = product.Id;
                    newcart.Add(item1);


                }

                HttpContext.Session.Set("products", newcart);
               // HttpContext.Session.Set("incproducts",null );
               //HttpContext.Session.Set("incproducts", null);
                return RedirectToAction("Cart");

            }
         else if (count> 0 && count1 > 0)
            {
                List<CartItem> newcart = new List<CartItem>();
                foreach (var item in oldCart)
                {
                    foreach (var item1 in oldCart1)
                    {
                        if (item.ProductId==item1.ProductId)
                        {
                            item1.Quentity++;
                            itemFound = true;
                        }
                        newcart.Add(item1);
                    }
                    if (itemFound == false)
                    {
                        newcart.Add(item);
                    }
                }
                
                HttpContext.Session.Set("products",newcart);
                
                HttpContext.Session.Set("incproducts", new List<CartItem>());


                return RedirectToAction("Cart");

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
                return RedirectToAction("Cart");
            }
            ///Here I make a sily mistake but that give me too much pain I do not send session object
        
        }
        //increase Quentity
        public IActionResult IncreaseQuentity(int? id)
        {
            bool itemFound = false;
            List<CartItem> oldCart1 = new List<CartItem>();
            if (id == null)
            {
                return NotFound();
            }
            var product = _context.Products.Include(p => p.ProductTypes).FirstOrDefault(c => c.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            //oldCart = HttpContext.Session.Get<List<CartItem>>("incproducts");
            oldCart1 = HttpContext.Session.Get<List<CartItem>>("incproducts");
            if (oldCart1 != null)
            {
                List<CartItem> newcart = new List<CartItem>();

                foreach (var item in oldCart1)
                {
                    if (item.Id == product.Id)
                    {
                        itemFound = true;
                        item.Quentity++;
                    }
                    newcart.Add(item);
                }
                if (itemFound == false)
                {
                    var item1 = new CartItem();
                    item1.Quentity = 1;
                    item1.ProductId = product.Id;
                    newcart.Add(item1);
                }
                HttpContext.Session.Set<List<CartItem>>("incproducts", newcart);
                return RedirectToAction("Details", product);
            }
            else
            {
                List<CartItem> newcart = new List<CartItem>();
                newcart.Add(new CartItem
                {
                    Quentity = 1,
                    ProductId = product.Id
                });
                HttpContext.Session.Set("incproducts", newcart);
                return RedirectToAction("Details", product);
            }

        }
      
        public IActionResult DecreaseQuentity(int?id)
        {
            List<CartItem> oldCart = new List<CartItem>();
            if (id==null)
            {
                return NotFound();
            }
            var product = _context.Products.Include(p => p.ProductTypes).FirstOrDefault(c => c.Id == id);
            if (product==null)
            {
                return NotFound();
            }
            oldCart = HttpContext.Session.Get<List<CartItem>>("products");
            if (oldCart==null)
            {
                return RedirectToAction("Details", product);
            }
            if (oldCart != null)
            {
                bool flag = false;
                List<CartItem> newcart = new List<CartItem>();
                foreach (var item in oldCart)
                {
                    if (item.ProductId == product.Id && item.Quentity>1)
                    {
                        // itemFound = true;
                        item.Quentity--;
                    }
                    //else
                    //{
                    //    flag = true;
                        
                    //}
                    newcart.Add(item);
                }
                ViewBag.flag = flag;
                HttpContext.Session.Set("products", newcart);
                return RedirectToAction("Details", product);
            }
            return RedirectToAction("Details", product);
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
