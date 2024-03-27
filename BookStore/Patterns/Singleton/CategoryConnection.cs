using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace BookStore.Patterns.Singleton
{
    public class CategoryConnection
    {
        private static CategoryConnection instance;
        private readonly BookStoreEntities categoryEntitites;

        private CategoryConnection() 
        {
            categoryEntitites = new BookStoreEntities();
        }

        public static CategoryConnection GetCategoryConnection()
        {
            if (instance == null)
            {
                instance = new CategoryConnection();
            }
            return instance;
        }

        public DbSet<Category> Connection()
        {
            return categoryEntitites.Categories;
        }

        public void Add(Category category)
        {
            Connection().Add(category);
            categoryEntitites.SaveChanges();
        }

        public void Delete(Category category) 
        {
            Connection().Remove(category);
            categoryEntitites.SaveChanges();
        }

        public void Edit(Category category) 
        {
            try
            {
                //categoryEntitites.Entry(category).State = EntityState.Modified;
                
                categoryEntitites.Set<Category>().AddOrUpdate(category);
                categoryEntitites.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                Console.WriteLine(ex);
            }       
            //categoryEntitites.Set<Category>().AddOrUpdate(category);
            
        }

    }
}