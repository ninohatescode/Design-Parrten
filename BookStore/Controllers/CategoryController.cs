using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;
using BookStore.Patterns.Observer_Pattern;
using BookStore.Patterns.Singleton;
using BookStore.Patterns.Strategy;
using Microsoft.Ajax.Utilities;

namespace BookStore.Controllers
{
    public class CategoryController : Controller
    {
        private BookStoreEntities db = new BookStoreEntities();

        SaleDaySubject subject = new SaleDaySubject();

        IBookObserver book = new AnotherBook();
        IBookObserver scienceBook = new ScienceBookConcrete();
        IBookObserver comicBook = new ComicBook();
        IBookObserver culinaryBook = new CulinaryBook();

        //CategoryConnection categoryConnection = CategoryConnection.GetCategoryConnection();

        public void Add()
        {
            subject.AddBook(book);
            subject.AddBook(scienceBook);
            subject.AddBook(comicBook);
            subject.AddBook(culinaryBook);
        }


        // GET: Category
        public ActionResult Index(int id)
        {
            Add();

            var product = db.Products.Where(n => n.CategoryID == id).ToList();
            var productSale = new List<Product>(product);
            subject.MakeSale(productSale);

            //ViewBag.CategoryProd = db.Categories.FirstOrDefault(n => n.CategoryID == id);

            // Singleton
            ViewBag.CategoryProd = db.Categories.FirstOrDefault(n => n.CategoryID != id);

            ViewBag.IdCategory = id;
            return View(productSale);
        }

        public ActionResult GetAllProduct()
        {
            Add();
            var product = (from item in db.Products orderby item.ProductID descending select item).ToList();
            var productSale = new List<Product>(product);
            subject.MakeSale(productSale);

            return View(productSale);
        }

        public ActionResult Search(string searchString)
        {
            Add();
            ISearchStrategy defaultSearch = new DefaultSearch();
            ISearchStrategy authorSearch = new AuthorSearch();
            ISearchStrategy titleSearch = new TitleSearch();

            SearchContext searchContext = new SearchContext(defaultSearch);

            var result = searchContext.Searching(searchString, db);

            // Kiểm tra tìm kiếm và thay đổi chiến lược tìm kiếm
            if (result.Count == 0) 
            {
                searchContext.SetSeatchType(authorSearch);
                result = searchContext.Searching(searchString, db);

                if (result.Count == 0)
                {
                    searchContext.SetSeatchType(titleSearch);
                    result = searchContext.Searching(searchString, db);

                } if (result.Count == 0)
                {
                    return View(result);
                }
            }

            subject.MakeSale(result);
            return View(result);
        }

    }
}