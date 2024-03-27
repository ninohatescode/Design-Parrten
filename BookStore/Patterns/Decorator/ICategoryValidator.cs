using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Patterns.Decorator_Pattern
{
    public interface ICategoryValidator
    {
        bool IsValidate(Category category);
    }
}
