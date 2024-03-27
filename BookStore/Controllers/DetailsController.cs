using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using BookStore.Models;
using System.Data.Entity;
using BookStore.Patterns.Observer_Pattern;

namespace BookStore.Controllers
{
    public class DetailsController : Controller
    {
        BookStoreEntities db = new BookStoreEntities();

        SaleDaySubject subject = new SaleDaySubject();

        IBookObserver book = new AnotherBook();
        IBookObserver scienceBook = new ScienceBookConcrete();
        IBookObserver comicBook = new ComicBook();
        IBookObserver culinaryBook = new CulinaryBook();

        // GET: Details
        public ActionResult Index(int id)
        {
            subject.AddBook(book);
            subject.AddBook(scienceBook);
            subject.AddBook(comicBook);
            subject.AddBook(culinaryBook);

            var productDetails = db.Products.FirstOrDefault(n => n.ProductID == id);
            subject.MakeSaleForPro(productDetails);
            ViewBag.ProdDetails = productDetails;

            int thisProdCategories = db.Products.FirstOrDefault(n => n.ProductID == id).CategoryID;

            ViewBag.ThisProdCategories = db.Categories.FirstOrDefault(n => n.CategoryID == thisProdCategories);

            // Danh sách sản phẩm liên quan
            var productList = (from p in db.Products where p.CategoryID == thisProdCategories && p.ProductID != id select p).ToList();
            subject.MakeSale(productList);
            ViewBag.ProductList = productList.Take(10);

            //ViewBag.ProductList = (from p in db.Products where p.CategoryID == thisProdCategories && p.ProductID != id select p).ToList().Take(10);

            ViewBag.CommentList = (from c in db.Comments orderby c.id descending where c.ProductID == id select c).ToList();

            return View();
        }

        [HttpPost]
        public ActionResult AddComment(Comment cmt)
        {
            if (ModelState.IsValid)
            {
                db.Comments.Add(cmt);
                db.SaveChanges();
            }
            int productId = cmt.ProductID.GetValueOrDefault();
            return RedirectToAction("Index/" + productId, "Details");
        }

        public ActionResult DeleteComment(int id)
        {
            var cmt = db.Comments.Where(c => c.id == id).FirstOrDefault();
            int idProduct = cmt.ProductID.GetValueOrDefault();
            if (ModelState.IsValid)
            {
                db.Comments.Remove(cmt);
                db.SaveChanges();
            }
            return RedirectToAction("Index/" + idProduct, "Details");
        }

    }
}