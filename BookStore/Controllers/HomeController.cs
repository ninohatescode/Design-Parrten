using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;
using BookStore.Patterns.Iterator;
using BookStore.Patterns.Observer_Pattern;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        private BookStoreEntities db = new BookStoreEntities();

        SaleDaySubject saleDaySubject = new SaleDaySubject();

        IBookObserver book = new AnotherBook();
        IBookObserver scienceBook = new ScienceBookConcrete();
        IBookObserver comicBook = new ComicBook();
        IBookObserver culinaryBook = new CulinaryBook();

        public void Add()
        {
            saleDaySubject.AddBook(book);
            saleDaySubject.AddBook(scienceBook);
            saleDaySubject.AddBook(comicBook);
            saleDaySubject.AddBook(culinaryBook);
        }

        public ActionResult Index()
        {
            saleDaySubject.SetDateSale(2024, 3, 22);
            Add();

            ViewBag.CategoriesList = db.Categories.ToList();

            //------------Cập nhật danh sách sách vào ngày giảm giả
            var productsList = (from item in db.Products orderby item.ProductID descending select item).ToList();
            saleDaySubject.MakeSale(productsList);

            ViewBag.ProductsList = productsList.Take(10);

            int firstCate = db.Categories.First().CategoryID;
            int secondCate = db.Categories.FirstOrDefault(c => c.CategoryID != firstCate).CategoryID;
            int thirdCate = db.Categories.FirstOrDefault(c => c.CategoryID != secondCate).CategoryID;

            ViewBag.FirstCate = db.Categories.FirstOrDefault(c => c.CategoryID == firstCate);
            ViewBag.SecondCate = db.Categories.FirstOrDefault(c => c.CategoryID == secondCate);

            //------------Cập nhật danh sách sách cho thể loại Khoa học vào ngày giảm giả
            var productsList_1 = db.Products.Where(p => p.CategoryID == firstCate).ToList();
            saleDaySubject.MakeSale(productsList_1);
            ViewBag.ProductsList_1 = productsList_1.Take(10);

            //------------Cập nhật danh sách sách cho thể loại Khoa học vào ngày giảm giả
            var productsList_2 = db.Products.Where(p => p.CategoryID == secondCate).ToList();
            saleDaySubject.MakeSale(productsList_2);
            ViewBag.ProductsList_2 = productsList_2.Take(10); ;

            return View();
        }



        public ActionResult ProductCategory(int id)
        {
            var product = (from item in db.Products orderby item.ProductID descending where item.CategoryID == id select item).ToList();
            ViewBag.CategoryProd = db.Categories.FirstOrDefault(n => n.CategoryID == id);
            ViewBag.IdCategory = id;
            return View(product);
        }
    }
}