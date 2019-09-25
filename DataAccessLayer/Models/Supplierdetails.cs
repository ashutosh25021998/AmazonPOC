using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models
{
    public class Supplierdetails
    {
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public int ProductItemId { get; set; }
        public string ProductItemName { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public string image { get; set; }
    }
}
