using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Patterns.Strategy
{
    public class DefaultSearch : ISearchStrategy
    {
        public List<Product> SearchStrategy(string searchString, BookStoreEntities db)
        {
            // Thực hiện chiến lược tìm kiếm mặc định
            var result = new List<Product>();

            var productsByCatetogy = db.Products
                        .Join(db.Categories,
            product => product.CategoryID,
            category => category.CategoryID,
            (product, category) => new { Product = product, Category = category })
        .Where(pc => pc.Category.CategoryName.Contains(searchString))
        .Select(pc => pc.Product)
        .ToList();
            result.AddRange(productsByCatetogy);

            var productsByProductIntroduction = db.Products.Where(p => p.ProductIntroduction.Contains(searchString)).ToList();
            result.AddRange(productsByProductIntroduction);

            return result;
        }
    }
}