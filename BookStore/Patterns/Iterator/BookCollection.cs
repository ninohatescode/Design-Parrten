using BookStore.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Patterns.Iterator
{
    public class BookCollection: IEnumerable<FavoriteProduct>
    {
        private List<FavoriteProduct> products;

        public BookCollection()
        {
            products = new List<FavoriteProduct>();
        }

        public void AddBook(FavoriteProduct book)
        {
            products.Add(book);
        }

        public IEnumerator<FavoriteProduct> GetEnumerator()
        {
            return new BookIterator(products);
        }
    }
}