/*
 * Author: Merdan Jumanov
 * Update Date: 16.05.18
 * This is Microsoft tutorial on ASP.NET MVC. 
 * I am doing it to refresh my memory on ASP.NET and learn MVC on ASP.NET
 * Movies Controller. Controls flow of data between between Models.Movie.cs and Views.Movies
 */

using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class MoviesController : Controller
    {
        private MovieDBContext db = new MovieDBContext();

        // GET: Movies
        // movieGenre is used for filtering movies by genres
        // searchString is used for searching movies where movie name contains searchString
        public ActionResult Index(string movieGenre, string searchString)
        {
            // Create list to hold movie genres from the database
            var GenreLst = new List<string>();

            // Define LINQ query to select all genres and sort them in ascending order
            var GenreQry = from d in db.Movies
                           orderby d.Genre
                           select d.Genre;

            // Add distinct genres to GenreLst
            GenreLst.AddRange(GenreQry.Distinct());
            // Store list of genres as a SelectList in ViewBag.movieGenre
            ViewBag.movieGenre = new SelectList(GenreLst);

            // Define LINQ query to select all movies from database
            var movies = from m in db.Movies
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                //if searchString is not empty or null select movies that contain searchString
                movies = movies.Where(s => s.Title.Contains(searchString));
            }

            if(!string.IsNullOrEmpty(movieGenre))
            {
                //if movieGenre is not empty or null select movies with specified genre.
                movies = movies.Where(x => x.Genre == movieGenre);
            }

            return View(movies);
        }

        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,ReleaseDate,Genre,Price,Rating")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,ReleaseDate,Genre,Price,Rating")] Movie movie)
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
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
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
