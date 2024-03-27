using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;
using BookStore.Patterns.Decorator_Pattern;
using BookStore.Patterns.Singleton;

namespace BookStore.Areas.Admin.Controllers
{
    public class AdminCategoriesController : Controller
    {

        private CategoryConnection categoryConnection = CategoryConnection.GetCategoryConnection();

        // GET: Admin/AdminCategories
        public ActionResult Index()
        {
            return View(categoryConnection.Connection().ToList());
        }

        // GET: Admin/AdminCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Category category = db.Categories.Find(id);
            Category category = categoryConnection.Connection().ToList().Find(n => n.CategoryID == id);

            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Admin/AdminCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category, HttpPostedFileBase ImgCate)
        {
            ICategoryValidator cateValidator = new CateValidator();
            ValidationDecorator validationDecorator = new CateValidatorDecorator(cateValidator);

            if (ModelState.IsValid && validationDecorator.IsValidate(category))
            {
                if (ImgCate != null)
                {
                    var fileName = Path.GetFileName(ImgCate.FileName);
                    var path = Path.Combine(Server.MapPath("~/image"), fileName);
                    category.CategoryImage = fileName;
                    ImgCate.SaveAs(path);
                }

                //db.Categories.Add(category);
                //db.SaveChanges();
                categoryConnection.Add(category);
                return RedirectToAction("Index");
            }
           
            return View(category);
        }

        // GET: Admin/AdminCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Category category = db.Categories.Find(id);
            Category category = categoryConnection.Connection().Find(id);

            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Admin/AdminCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryID,CategoryName,CategoryImage")] Category category, HttpPostedFileBase ImgCate)
        {

            ICategoryValidator cateValidator = new CateValidator();
            ValidationDecorator validationDecorator = new CateValidatorDecorator(cateValidator);

            if (ModelState.IsValid && validationDecorator.IsValidate(category))
            {
                if (ImgCate != null)
                {
                    var fileName = Path.GetFileName(ImgCate.FileName);
                    var path = Path.Combine(Server.MapPath("~/image"), fileName);
                    category.CategoryImage = fileName;
                    ImgCate.SaveAs(path);
                }
                
                //db.Entry(category).State = EntityState.Modified;               
                //db.SaveChanges();
                categoryConnection.Edit(category);
                return RedirectToAction("Index");
            } 

            return View(category);
        }

        // GET: Admin/AdminCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Category category = db.Categories.Find(id);
            Category category = categoryConnection.Connection().Find(id);

            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Admin/AdminCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Category category = db.Categories.Find(id);
            Category category = categoryConnection.Connection().ToList().Find(n => n.CategoryID == id);

            categoryConnection.Delete(category);
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}