using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceProject.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public decimal Quentity { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
