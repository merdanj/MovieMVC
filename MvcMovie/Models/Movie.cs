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

        // Setting max and min string length. Tutorial is telling me to set min as 3, 
        // personally I would put 1 as min. 
        // Sometimes movie makers will try to be original and use one letter.
        [StringLength(60, MinimumLength = 3)]
        public string Title { get; set; }

        // Set Display Name, data type, and display format.
        // Tutorial tells that there is bug in Chrome that makes DisplayFormat necessary.
        // I don't know if bug is fixed but I would still leave it.
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}", ApplyFormatInEditMode =true)]
        public DateTime ReleaseDate { get; set; }

        // [Required] makes sure that Genre is not empty and 
        // regEx makes Genre field accept only letters
        [RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$")]
        [Required]
        [StringLength(30)]
        public string Genre { get; set; }

        // Set price range for movie.
        // 1, 100 pretty expensive movie.
        [Range(1,100)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        // Same as Genre, regEx limits allowed characters
        [RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$")]
        [StringLength(5)]   
        public string Rating { get; set; }
    }

    public class MovieDBContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
    }
}