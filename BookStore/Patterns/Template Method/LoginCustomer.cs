using BookStore.Controllers;
using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BookStore.Patterns.Template_Method
{
    public class LoginCustomer : LoginTemplate
    {
        protected override object CheckLogin(Customer account)
        {
            BookStoreEntities db = new BookStoreEntities();
            var customerAccount = db.Customers.FirstOrDefault(k => k.UserEmail == account.UserEmail && k.UserPassword == account.UserPassword);
            return customerAccount;
        }
    }
}