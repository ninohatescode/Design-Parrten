using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Patterns.Strategy
{
    public class TitleSearch : ISearchStrategy
    {
        public List<Product> SearchStrategy(string searchString, BookStoreEntities db)
        {
            var result = db.Products.Where(p => p.ProductName.Contains(searchString)).ToList();
            return result;
        }
    }
}