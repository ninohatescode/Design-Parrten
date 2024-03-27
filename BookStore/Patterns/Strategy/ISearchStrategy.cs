using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Patterns.Strategy
{
    public interface ISearchStrategy
    {
        List<Product> SearchStrategy(string searchString, BookStoreEntities db);
    }
}