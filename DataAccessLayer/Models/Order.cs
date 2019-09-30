using ProductRough.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Models
{
   public class Order
    {
        [Key]
        public int OrderId { get;set;}

        [ForeignKey("OperatorId")]
        public int OperatorId { get; set; }
        public  Operator Operator { get; set; }

        [ForeignKey("LocationId")]
        public int LocationId { get; set; }
        public  Location Location { get; set; }

        public int TotalPrice { get; set; }
        public String ListOfProducts { get; set; }


    }
}
