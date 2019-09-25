using ProductRough.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Models
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Pin  { get; set; }
        public int OperatorId { get; set; }
        [ForeignKey("OperatorId") ]
        public Operator Operator { get; set; }
    }
}
