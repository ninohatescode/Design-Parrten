using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Patterns.Prototype_Pattern
{
    public interface IBookPrototype
    {
        Product Clone(Product product);
    }
}