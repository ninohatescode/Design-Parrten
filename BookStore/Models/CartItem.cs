using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookStore.Models;
using BookStore.Patterns.Observer_Pattern;

namespace BookStore.Models
{
    public class CartItem
    {
        BookStoreEntities db = new BookStoreEntities();
        SaleDaySubject subject = new SaleDaySubject();

        IBookObserver book = new AnotherBook();
        IBookObserver scienceBook = new ScienceBookConcrete();
        IBookObserver comicBook = new ComicBook();
        IBookObserver culinaryBook = new CulinaryBook();

        public int ProductID { get; set; }
        public string NamePro { get; set; }
        public string ImagePro { get; set; }
        public decimal Price { get; set; }
        public int Number { get; set; }

        public decimal FinalPrice()
        {
            return Number * Price;
        }

        public CartItem(int ProductID)
        {
            subject.AddBook(book);
            subject.AddBook(scienceBook);
            subject.AddBook(comicBook);
            subject.AddBook(culinaryBook);

            this.ProductID = ProductID;
            var productDB = db.Products.Single(s => s.ProductID == this.ProductID);
            // Thực hiện giảm giá
            subject.MakeSaleForPro(productDB);

            this.NamePro = productDB.ProductName;
            this.ImagePro = productDB.Image;
            this.Price = productDB.Price;
            this.Number = 1;
        }

    }
}
