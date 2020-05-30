using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Display(Name = "Product Color")]
        public string ProductColor { get; set; }
        [Required]
        [Display(Name = "Avaiable")]
        public bool IsAviable { get; set; }
        [Required]
        // Navication prop Id should be same as it object like ProductTypes and ProductTypesId only different beween Id word
        public int SpecialTagId { get; set; }
        [ForeignKey("SpecialTagId")]
        public virtual SpecialTag SpecialTag { get; set; }
        [Required]
        public int ProductTypesId { get; set; }
        [ForeignKey("ProductTypesId")]
        public virtual ProductTypes ProductTypes { get; set; }
    }
}
