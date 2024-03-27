using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Patterns.Strategy
{
    public class SearchContext
    {
        private ISearchStrategy strategy;

        public SearchContext () { }

        public SearchContext (ISearchStrategy strategy) 
        {
            this.strategy = strategy;
        }

        public void SetSeatchType(ISearchStrategy searchStrategy)
        {
            this.strategy = searchStrategy;
        }

        public List<Product> Searching(string searchString, BookStoreEntities db)
        {
            return strategy.SearchStrategy(searchString, db);
        }

    }
}