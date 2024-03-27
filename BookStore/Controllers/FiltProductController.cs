using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;
using BookStore.Patterns.Observer_Pattern;
using BookStore.Patterns.Singleton;

namespace BookStore.Controllers
{
    public class FiltProductController : Controller
    {
        BookStoreEntities db = new BookStoreEntities();

        //Oberserver
        SaleDaySubject subject = new SaleDaySubject();

        IBookObserver book = new AnotherBook();
        IBookObserver scienceBook = new ScienceBookConcrete();
        IBookObserver comicBook = new ComicBook();
        IBookObserver culinaryBook = new CulinaryBook();

        // Singleton
        CategoryConnection categoryConnection = CategoryConnection.GetCategoryConnection();

        public void Add()
        {
            subject.AddBook(book);
            subject.AddBook(scienceBook);
            subject.AddBook(comicBook);
            subject.AddBook(culinaryBook);
        }


        // GET: FiltProduct
        public ActionResult Index()
        {
            return View();
        }

        //dưới 100.000đ
        public ActionResult Under100vndAllProduct(int id)
        {
            if (id == 0)
            {
                Add();
                //var products = (from item in db.Products orderby item.ProductID descending where item.Price <= 100000 select item).ToList();
                var products = db.Products.ToList();
                subject.MakeSale(products);


                //ViewBag.CategoryProd = db.Categories.FirstOrDefault(n => n.CategoryID == id);
                ViewBag.CategoryProd = categoryConnection.Connection().FirstOrDefault(n => n.CategoryID == id);
                ViewBag.IdCategory = id;

                return View(products.Where(item => item.Price <= 100000));
            }
            else
            {
                //var products = (from item in db.Products orderby item.ProductID descending where item.Price <= 100000 && item.CategoryID == id select item).ToList();
                var products = db.Products.ToList();
                subject.MakeSale(products);

                ViewBag.CategoryProd = categoryConnection.Connection().FirstOrDefault(n => n.CategoryID == id);
                ViewBag.IdCategory = id;
                return View(products.Where(item => item.Price <= 100000 && item.CategoryID == id));
            }
        }

        //từ 100.000 đến 250.000
        public ActionResult From100to250vndAllProduct(int id)
        {
            Add();
            if (id == 0)
            {
                //var products = (from item in db.Products orderby item.ProductID descending where item.Price >= 100000 && item.Price <= 250000 select item).ToList();
                var products = db.Products.ToList();
                subject.MakeSale(products);

                ViewBag.CategoryProd = categoryConnection.Connection().FirstOrDefault(n => n.CategoryID == id);

                ViewBag.IdCategory = id;

                return View(products.Where(item => item.Price >= 100000 && item.Price <= 250000));
            }
            else
            {   
                //var products = (from item in db.Products orderby item.ProductID descending where item.Price >= 100000 && item.Price <= 250000 && item.CategoryID == id select item).ToList();
                var products = db.Products.ToList();
                subject.MakeSale(products);

                ViewBag.CategoryProd = categoryConnection.Connection().FirstOrDefault(n => n.CategoryID == id);

                ViewBag.IdCategory = id;

                return View(products.Where(item => item.Price >= 100000 && item.Price <= 250000 && item.CategoryID == id));
            }
        }

        //từ 250.000 đến 500.000
        public ActionResult From250to500vndAllProduct(int id)
        {
            Add();
            if (id == 0)
            {               
                //var products = (from item in db.Products orderby item.ProductID descending where item.Price >= 250000 && item.Price <= 500000 select item).ToList();
                var products = db.Products.ToList();
                subject.MakeSale(products);

                ViewBag.CategoryProd = categoryConnection.Connection().FirstOrDefault(n => n.CategoryID == id);

                ViewBag.IdCategory = id;
                return View(products.Where(item => item.Price >= 250000 && item.Price <= 500000));
            }
            else
            {
                //var products = (from item in db.Products orderby item.ProductID descending where item.Price >= 250000 && item.Price <= 500000 && item.CategoryID == id select item).ToList();
                var products = db.Products.ToList();
                subject.MakeSale(products);

                ViewBag.CategoryProd = categoryConnection.Connection().FirstOrDefault(n => n.CategoryID == id);

                ViewBag.IdCategory = id;
                return View(products.Where(item => item.Price >= 250000 && item.Price <= 500000 && item.CategoryID == id));
            }
        }

        //trên 500.000
        public ActionResult Over500vndAllProduct(int id)
        {
            Add();

            if (id == 0)
            {
                
                //var products = (from item in db.Products orderby item.ProductID descending where item.Price >= 500000 select item).ToList();
                var products = db.Products.ToList();
                subject.MakeSale(products);

                ViewBag.CategoryProd = categoryConnection.Connection().FirstOrDefault(n => n.CategoryID == id);
                ViewBag.IdCategory = id;
                return View(products.Where(item => item.Price >= 500000));
            }
            else
            {
                
                //var products = (from item in db.Products orderby item.ProductID descending where item.Price >= 500000 && item.CategoryID == id select item).ToList();
                var products = db.Products.ToList();
                subject.MakeSale(products);

                ViewBag.CategoryProd = categoryConnection.Connection().FirstOrDefault(n => n.CategoryID == id);
                ViewBag.IdCategory = id;
                return View(products.Where(item => item.Price >= 500000 && item.CategoryID == id));
            }
        }

        //giá thấp -> cao
        public ActionResult IncreaseWithPrice(int id)
        {
            Add();           
            if (id == 0)
            {
                
                //var products = (from item in db.Products orderby item.Price ascending select item).ToList();
                var products = db.Products.ToList();
                subject.MakeSale(products);

                ViewBag.CategoryProd = categoryConnection.Connection().FirstOrDefault(n => n.CategoryID == id);
                ViewBag.IdCategory = id;

                return View(products.OrderBy(item => item.Price));
            }
            else
            {
                
                //var products = (from item in db.Products orderby item.Price ascending where item.CategoryID == id select item).ToList();
                var products = db.Products.ToList();
                subject.MakeSale(products);

                ViewBag.CategoryProd = categoryConnection.Connection().FirstOrDefault(n => n.CategoryID == id);
                ViewBag.IdCategory = id;
                return View(products.OrderBy(item => item.Price).ThenBy(item => item.CategoryID));
            }
        }

        //giá cao -> thấp
        public ActionResult DescreaseWithPrice(int id)
        {
            Add();
            if (id == 0)
            {
                //var products = (from item in db.Products orderby item.Price descending select item).ToList();
                var products = db.Products.ToList();
                subject.MakeSale(products);

                ViewBag.CategoryProd = categoryConnection.Connection().FirstOrDefault(n => n.CategoryID == id);
                ViewBag.IdCategory = id;
                return View(products.OrderByDescending(item => item.Price));
            }
            else
            {
                //var products = (from item in db.Products orderby item.Price descending where item.CategoryID == id select item).ToList();
                var products = db.Products.ToList();
                subject.MakeSale(products);

                ViewBag.CategoryProd = categoryConnection.Connection().FirstOrDefault(n => n.CategoryID == id);
                ViewBag.IdCategory = id;
                return View(products.OrderByDescending(item => item.Price).ThenBy(item => item.CategoryID));
            }
        }

    }
}