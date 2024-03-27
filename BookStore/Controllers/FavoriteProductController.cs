using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;
using BookStore.Patterns.Iterator;
using BookStore.Patterns.Observer_Pattern;

namespace BookStore.Controllers
{
    public class FavoriteProductController : Controller
    {
        BookStoreEntities db = new BookStoreEntities();

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

        // GET: FavoriteProduct
        public ActionResult FavoriteList(int id)
        {
            Add();
            //C1
            //BookCollection bookCollection = new BookCollection();
            ////var product = db.FavoriteProducts.Where(n => n.UserID == id).ToList();
            //foreach (var item in db.FavoriteProducts.Where(n => n.UserID == id).ToList())
            //{
            //    bookCollection.AddBook(item);
            //}
            //ViewBag.ProductInfor = new List<Product>();
            //foreach (var item in bookCollection)
            //{
            //    Product prod = db.Products.FirstOrDefault(p => p.ProductID == item.ProductID);             
            //    ViewBag.ProductInfor.Add(prod);
            //    saleDaySubject.MakeSale(ViewBag.ProductInfor);
            //}

            //C2
            BookIterator bookIterator = new BookIterator(db.FavoriteProducts.Where(n => n.UserID == id).ToList());
            ViewBag.ProductInfor = new List<Product>();
            while (bookIterator.MoveNext())
            {
                FavoriteProduct currentProduct = bookIterator.Current;
                Product product = db.Products.FirstOrDefault(n => n.ProductID == currentProduct.ProductID);
                ViewBag.ProductInfor.Add(product);
                saleDaySubject.MakeSale(ViewBag.ProductInfor);

            }            
            return View(bookIterator);
        }

        [HttpPost]
        public ActionResult InsertListFavorite(FavoriteProduct favoriteProd)
        {
            if (ModelState.IsValid)
            {
                var productAvail = db.FavoriteProducts.FirstOrDefault(p => p.ProductID == favoriteProd.ProductID && p.UserID == favoriteProd.UserID);
                if (productAvail != null)
                    return RedirectToAction("Index/" + favoriteProd.ProductID, "Details");
                else
                {
                    db.FavoriteProducts.Add(favoriteProd);
                    db.SaveChanges();
                    return RedirectToAction("FavoriteList/" + favoriteProd.UserID, "FavoriteProduct");
                }
            }
            return View("Index/" + favoriteProd.ProductID, "Details");
        }

        public ActionResult DeleteProduct(FavoriteProduct favoriteProd)
        {
            if (ModelState.IsValid)
            {
                var prod = db.FavoriteProducts.FirstOrDefault(p => p.ProductID == favoriteProd.ProductID && p.UserID == favoriteProd.UserID);
                db.FavoriteProducts.Remove(prod);
                db.SaveChanges();
            }
            return RedirectToAction("FavoriteList/" + favoriteProd.UserID, "FavoriteProduct");
        }

    }
}