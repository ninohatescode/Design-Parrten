using BookStore.Models;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;

namespace BookStore.Patterns.Observer_Pattern
{
    public class AnotherBook : IBookObserver
    {

        public void Update(List<Product> products)
        {          
            foreach (var product in products) 
            {
                if (product.CategoryID == 3 && product.CategoryID < 4)
                {
                    product.Price = (decimal)(product.IntialPrice) * 0.9m;
                }                
            }
        }

        public void UpdateForPro(Product product)
        {
            if (product.CategoryID == 3 && product.CategoryID < 4)
            {
                product.Price = (decimal)(product.IntialPrice) * 0.9m;
            }
        }
    }
}