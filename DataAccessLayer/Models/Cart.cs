using ProductRough.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }

        [ForeignKey("ProductItemId")]
        public int ProductItemId { get; set; }
        public virtual ProductItems ProductItems { get; set; }
       

        [ForeignKey("OperatorId")]
        public int OperatorId { get; set; }
        public virtual Operator Operator { get; set; }
        


        public int Quantity { get; set; }
        public string Totalprice { get; set; }
       
   

    }
}
