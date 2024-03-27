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
    public class LoginAdmin : LoginTemplate
    {
        protected override object CheckLogin(Customer account)
        {
            BookStoreEntities db = new BookStoreEntities();
            var adminAccount = db.AdminAccounts.FirstOrDefault(k => k.Email == account.UserEmail && k.Password == account.UserPassword);
            return adminAccount;
        }
    }
}