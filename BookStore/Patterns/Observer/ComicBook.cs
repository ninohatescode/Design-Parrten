using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Patterns.Observer_Pattern
{
    public class ComicBook : IBookObserver
    {
        public void Update(List<Product> products)
    {
        foreach (var product in products)
        {
            if (product.CategoryID == 2)
            {
                product.Price = (decimal)(product.IntialPrice) * 0.5m;
            }
        }
    }

    public void UpdateForPro(Product product)
    {
        if (product.CategoryID == 2)
        {
            product.Price = (decimal)(product.IntialPrice) * 0.5m;
        }
    }
}
}