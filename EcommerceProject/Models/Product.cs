using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceProject.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string Image { get; set; }
        [Display(Name ="Product Color")]
        public string ProductColor { get; set; }
        [Required]
        [Display(Name ="Avaiable")]
        public bool IsAviable { get; set; }
        public int ProductTypeId { get; set; }
        [Required]
        [Display(Name = "Product Type")]
        public ProductTypes ProductTypes { get; set; }
        [Required]
        [Display(Name = "Special Tag")]
        public int SpecialTagId { get; set; }
        public SpecialTag SpecialTags { get; set; }

    }
}
