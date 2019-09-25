using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductRough.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductType { get; set; }
        public int Discount { get; set; }
        public string Gender { get; set; }
        public string image { get; set; }
   
    }
}
