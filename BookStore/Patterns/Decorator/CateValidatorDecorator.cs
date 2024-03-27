using BookStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.Patterns.Decorator_Pattern
{
    public class CateValidatorDecorator : ValidationDecorator
    {      
        public CateValidatorDecorator(ICategoryValidator validator) : base(validator) { }

        public override bool IsValidate(Category category)
        {
            if (!string.IsNullOrEmpty(category.CategoryName))
            {
                if (category.CategoryName.Length > 100)
                {
                    return false;
                }

                if (int.TryParse(category.CategoryName, out _))
                {
                    return false;
                }
            }

            return base.IsValidate(category);
        }
    }
}