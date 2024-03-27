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
    public class BookIterator : IEnumerator<FavoriteProduct>
    {
        private List<FavoriteProduct> products;
        private int position = -1;

        public BookIterator(List<FavoriteProduct> books)
        {
            products = books;
        }

        public FavoriteProduct Current => products[position];

        public bool MoveNext()
        {
            position++;
            return position < products.Count;
        }

        public void Reset()
        {
            position = -1;
        }

    }
}