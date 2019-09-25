using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProductRough.Models
{
    public class ProductItems
    {
        [Key]
        public int ProductItemId { get; set; }
        public string ProductItemName { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
      
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public string Description { get; set; }
        public int SupplierId { get; set; }
        [ForeignKey("SupplierId")]
        public Supplier Supplier { get; set; }
        public string image { get; set; }

    }
}
