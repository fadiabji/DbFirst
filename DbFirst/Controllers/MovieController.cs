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
            // first context
            var movies = db.Movies.ToList();
            // second context
            var QSMovies = (from m in db.Movies select m ).ToList(); 

            //Select top(3) from Movies
            //Order by price desc 
            //First context
            var Top3ExpMovies = db.Movies.OrderByDescending(m => m.Price).Take(3).ToList();
            //Second context
            var QSTop3ExpMovies = (from m in db.Movies select m).OrderByDescending(m => m.Price).Take(3).ToList();


            //top2cheapest
            //First context
            var Top2CheapestMovies = db.Movies.OrderBy(m => m.Price).Take(2).ToList();
            //Second context
            var QSTop2CheapestMovies = (from m in db.Movies select m).OrderBy(m => m.Price).Take(2).ToList();


            //top2Oldest
            //First context
            var Top2OldestsMovies = db.Movies.OrderBy(m => m.ReleaseYear).Take(2).ToList();
            //Second Context
            var QSTop2OldestsMovies = (from m in db.Movies select m).OrderBy(m => m.ReleaseYear).Take(2).ToList();


            //top2Newest
            //First Context
            var Top2NewestsMovies = db.Movies.OrderByDescending(m => m.ReleaseYear).Take(2).ToList();
            //Second Context
            var QsTop2NewestsMovies = (from m in db.Movies select m).OrderByDescending(m => m.ReleaseYear).Take(2).ToList();


            return View(QsTop2NewestsMovies);
        }
    }
}
