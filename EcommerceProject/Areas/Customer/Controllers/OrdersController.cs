using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceProject.Data;
using EcommerceProject.Migrations;
using EcommerceProject.Models;
using EcommerceProject.Utility;
using EcommerceProject.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace EcommerceProject.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class OrdersController : Controller
    {
        private ApplicationDbContext _context;
        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        //HttpGet For CheckOut
        [HttpGet]
        public IActionResult CheckOut()
        {
            List<CartItem> cart = HttpContext.Session.Get<List<CartItem>>("products");
            List<CartVm> cartVms = new List<CartVm>();
            if (cart!=null)
            {
                foreach (var item in cart)
                {
                    CartVm vm = new CartVm();
                    var product = _context.Products.FirstOrDefault(c => c.Id == item.ProductId);
                    vm.Name = product.Name;
                    vm.Price = product.Price;
                    vm.Image = product.Image;
                    vm.Quantity = item.Quentity;
                    cartVms.Add(vm);
                }
                ViewBag.Product = cartVms;
            }
            
            return View();
        }
        //HttpPost For CheckOut
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CheckOut(Order order)
        {
            List<CartItem> cart = HttpContext.Session.Get<List<CartItem>>("products");
            if (cart!=null)
            {
               
                foreach (var item in cart)
                {
                    OrderDetails newOrderDetails = new OrderDetails();
                    newOrderDetails.ProductId = item.ProductId;
                    order.OrderDetails.Add(newOrderDetails);
                    
                }
            }
            order.OrderNo = GetOrderNo();
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            HttpContext.Session.Set("products",new List<CartItem>());
            return RedirectToAction("Index","Home");
        }
        public string GetOrderNo()
        {
            int rowCount = _context.Orders.ToList().Count() + 1;
            return rowCount.ToString("000");
        }
    }
}