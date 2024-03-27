using BookStore.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Patterns.Observer_Pattern
{
    public interface IBookObserver
    {
        void Update(List<Product> products);
        void UpdateForPro(Product product);
    }
}
