using System.Collections.Generic;
using System.Linq;
using System.Net;
using BasicASP.NETMvc.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;

namespace BasicASP.NETMvc.Controllers
{
    //[Authorize]
    public class MoviesController : Controller
    {
        MovieDBContext db=new MovieDBContext();
        // GET: Movies/Index
        [HttpGet]
        public ActionResult Index(string movieGenre, string searchString)
        {
            var genreLst = new List<string>();
            db.Database.EnsureCreated();
            
            var genreQry = from d in db.Movies
                orderby d.Genre
                select d.Genre;
            //var genreQry=db.Movies.ToList();

            genreLst.AddRange(genreQry.Distinct());
            ViewBag.MovieGenre = new SelectList(genreLst);

            // # homework 3 -- read movies data from loacl-db,please use linq
            var data=from d in db.Movies
                    select d;
            // # homework 7 -- filte movies data by conditions
            if(!String.IsNullOrEmpty(movieGenre))
            {
                data=from d in data
                    where d.Genre==movieGenre
                    select d;
            }
            if(!String.IsNullOrEmpty(searchString))
            {
                data=from d in data
                    where d.Title.Contains(searchString)
                    select d;
            }

            return View(data.ToList());
        }

        [HttpPost]
        public string Index(FormCollection fc, string searchString)
        {
            return "<h3> From [HttpPost]Index: " + searchString + "</h3>";
        }

        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }

            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(include: "ID,Title,ReleaseDate,Genre,Price,Rating")]
            Movie movie)
        {
            // # homework 5 -- save data to loacl-db
            db.Movies.Add(movie);
            db.SaveChanges();
            return View(movie);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            // # homework 8 -- when you on Eidt site , you should see the movie info
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            var data=db.Movies.Find(id);

            return View(data);
        }

        // POST: Movies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(include: "ID,Title,ReleaseDate,Genre,Price,Rating")]
            Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            // # homework 9 -- find data by id 
            // when id is null ,return HttpStatusCode.BadRequest;
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}