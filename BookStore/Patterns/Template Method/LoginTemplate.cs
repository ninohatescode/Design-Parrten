using BookStore.Controllers;
using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace BookStore.Patterns.Template_Method
{
     public abstract class LoginTemplate
     {
        public bool LoginMethod(Customer customer, UsersController controller) 
        { 
            var result = CheckLogin(customer);
            if (result != null)
            {
                controller.Session["Account"] = result;
                return true;
            }
            return false;            
        }
        protected abstract object CheckLogin(Customer account);  
     }
}