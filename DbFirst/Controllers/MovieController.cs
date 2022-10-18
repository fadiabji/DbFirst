using Microsoft.AspNetCore.Mvc;
using DbFirst.Models;

namespace DbFirst.Controllers
{
    
    public class MovieController : Controller
    {
        Movie_DBContext db = new Movie_DBContext();
        public IActionResult Index()
        {
            
            //Select * from Movies
            // first centext
            var movies = db.Movies.ToList();
            // second cyntext
            //var QSMovies = () 

            //Select top(3) from Movies
            //Order by price desc
            var Top3ExpMovies = db.Movies.OrderByDescending(m => m.Price).Take(3).ToList();

            //top2cheapest
            var Top2CheapestMovies = db.Movies.OrderBy(m => m.Price).Take(2).ToList();


            //top2Oldest
            var Top2OldestsMovies = db.Movies.OrderBy(m => m.ReleaseYear).Take(2).ToList();

            //top2Newest
            var Top2NewestsMovies = db.Movies.OrderByDescending(m => m.ReleaseYear).Take(2).ToList();



            return View(Top2OldestsMovies);
        }
    }
}
