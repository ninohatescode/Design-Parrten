using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Patterns.Decorator_Pattern
{
    // Component
    public class CateValidator : ICategoryValidator
    {
        public bool IsValidate(Category category)
        {
            return true;
        }
    }
}