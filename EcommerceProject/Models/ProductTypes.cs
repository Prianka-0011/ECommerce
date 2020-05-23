﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceProject.Models
{
    public class ProductTypes
    {
        public int Id { get; set; }

        [Required,Display(Name ="Product Type")]
        public string Type { get; set; }
        public List<Product> Products { get; set; }
    }
}
