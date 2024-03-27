﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;

namespace BookStore.Areas.Admin.Controllers
{
    public class AdminHomeController : Controller
    {
        BookStoreEntities db = new BookStoreEntities();
        // GET: Admin/AdminHome
        public ActionResult Index()
        {
            ViewBag.CountUser = db.Customers.Count();
            ViewBag.CountProduct = db.Products.Count();
            ViewBag.CountOrder = db.Orders.Count();

            ViewBag.OrderList = (from order in db.Orders orderby order.IdOrder descending select order).ToList().Take(10);

            var orderIds = db.OrderDetails.Select(od => od.IdOrder).Distinct().ToList();
            ViewBag.TotalMoney = db.OrderDetails.Where(od => orderIds.Contains(od.Order.IdOrder) && od.Order.StatusOrder == 2).Sum(s => s.FinalPrice);

            var today = DateTime.Now.Date;
            ViewBag.OrderToday = db.Orders.Where(order => order.DateOrder == today).Count();
            ViewBag.DebtOrder = db.Orders.Where(order => order.StatusOrder == 0).Count();
            ViewBag.PaidOrder = db.Orders.Where(order => order.StatusOrder == 1).Count();

            ViewBag.CancelOrder = db.Orders.Where(order => order.StatusOrder == 2).Count();
            return View();
        }
    }
}