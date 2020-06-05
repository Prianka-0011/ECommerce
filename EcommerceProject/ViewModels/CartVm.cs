using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceProject.ViewModels
{
    public class CartVm
    {
        public int ID { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
       
        public decimal Price { get; set; }
        public string Image { get; set; }
        public string ProductColor { get; set; }
        public string Type { get; set; }
        public decimal Quantity { get; set; }
        
    }
}
