using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Patterns.Prototype_Pattern
{
    public class Book : IBookPrototype
    {
        public int id;
        public string name;
        public string author;
        public decimal? initialPrice;
        public decimal price;
        public int categoryID;
        public string image;
        public int amout;
        public string introduction;

        // Phương thức nhân bảng một sách
        public Product Clone(Product product)
        {
            Book clone = new Book();
            clone.id = product.ProductID;
            clone.name = product.ProductName;
            clone.author = product.AuthorName;
            clone.initialPrice = product.IntialPrice;
            clone.price = product.Price;
            clone.categoryID = product.CategoryID;
            clone.image = product.Image;
            clone.amout = 0;
            clone.introduction = product.ProductIntroduction;
            
            return clone.CloneFromBook(clone);
        }

        // Phương thức này chuyển từ đối tượng Book sang Product
        public Product CloneFromBook(Book book)
        {
            return new Product
            {
                ProductID = book.id,
                ProductName = book.name,
                AuthorName = book.author,
                IntialPrice = book.initialPrice,
                Price = book.price,
                CategoryID = book.categoryID,
                Image = book.image,
                ProductIntroduction = book.introduction
            };
        }
    }
}