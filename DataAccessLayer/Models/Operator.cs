using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProductRough.Models
{
    public class Operator
    {
        [Key]
        public int OperatorId { get; set; }
        public string OperatorName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string PassWord { get; set; }     
             
        public string Roles { get; set; }
       

    }
}
