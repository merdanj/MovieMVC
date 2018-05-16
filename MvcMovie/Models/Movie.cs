/*
 * Author: Merdan Jumanov
 * Update Date: 16.05.18
 * This is Microsoft tutorial on ASP.NET MVC. 
 * I am doing it to refresh my memory on ASP.NET and learn MVC on ASP.NET
 * Movie class manages movies in database. I can add more properties later.
 */

using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}", ApplyFormatInEditMode =true)]
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
        public string Rating { get; set; }
    }

    public class MovieDBContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
    }
}