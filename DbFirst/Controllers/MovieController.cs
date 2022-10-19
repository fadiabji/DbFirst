using Microsoft.AspNetCore.Mvc;
using DbFirst.Models;
using System.Net.WebSockets;

namespace DbFirst.Controllers
{
    
    public class MovieController : Controller
    {
        Movie_DBContext db = new Movie_DBContext();
        public IActionResult Index()
        {
            
            //Select * from Movies
            // first syntex
            var movies = db.Movies.ToList();
            // second syntex
            var QSMovies = (from m in db.Movies 
                            select m ).ToList(); 


            //Select top(3) from Movies
            //Order by price desc 
            //First syntex
            var Top3ExpMovies = db.Movies.OrderByDescending(m => m.Price).Take(3).ToList();
            //Second syntex
            var QSTop3ExpMovies = (from m in db.Movies 
                                   select m).OrderByDescending(m => m.Price).Take(3).ToList();


            //top2cheapest
            //First syntex
            var Top2CheapestMovies = db.Movies.OrderBy(m => m.Price).Take(2).ToList();
            //Second syntex
            var QSTop2CheapestMovies = (from m in db.Movies 
                                        select m).OrderBy(m => m.Price).Take(2).ToList();


            //top2Oldest
            //First syntex
            var Top2OldestsMovies = db.Movies.OrderBy(m => m.ReleaseYear).Take(2).ToList();
            //Second syntex
            var QSTop2OldestsMovies = (from m in db.Movies
                                       select m).OrderBy(m => m.ReleaseYear).Take(2).ToList();


            //top2Newest
            //First syntex
            var Top2NewestsMovies = db.Movies.OrderByDescending(m => m.ReleaseYear).Take(2).ToList();
            //Second syntex
            var QsTop2NewestsMovies = (from m in db.Movies
                                       select m).OrderByDescending(m => m.ReleaseYear).Take(2).ToList();


            return View(QsTop2NewestsMovies);
        }

        public IActionResult WhereDemo()
        {
            // movies whose price is below 150;
            var movies = db.Movies.Where(m => m.Price <= 150).ToList();
            //Second syntax SQL syntax
            var QsMovies = (from m in db.Movies 
                            where m.Price < 150
                            select m).ToList();

            var movie = db.Movies.FirstOrDefault(m => m.Title =="Pulp Fiction"); // Here we will get a single value if we put it in view here 
            // will get an error becuase the view expect a list of movies 

            //return View(movie);

            return View(movies);
        }

    }
}
