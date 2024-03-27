using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Patterns.Decorator_Pattern
{
    public abstract class ValidationDecorator : ICategoryValidator
    {
        private ICategoryValidator _validator;

        public ValidationDecorator(ICategoryValidator validator)
        {
            this._validator = validator;
        }

        public virtual bool IsValidate(Category category) 
        {          
            return _validator.IsValidate(category);
        }
    }
}