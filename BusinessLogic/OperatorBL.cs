using ProductRough.ContextFolder;
using ProductRough.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic
{
    public class OperatorBL
    {
        ProductContext obj = new ProductContext();


        ////////Vefirying in login page

        public Operator VerifyLogin(string email/*, string password*/)
        {
           // if (string.IsNullOrEmpty(email)) throw new ArgumentNullException(email);
           // if (string.IsNullOrEmpty(password)) throw new ArgumentNullException(password);

            var op = obj.Operators.SingleOrDefault(o => o.Email == email /*&& o.PassWord == password*/);
           
            return op;
        }
     




        ////verifying the Register Page








    }
}

